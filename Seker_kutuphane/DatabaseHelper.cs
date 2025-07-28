using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic; // Added for List

namespace Seker_kutuphane
{
    public class ApiHelper
    {
        private readonly string apiBaseUrl = "http://10.100.74.48:5000";
        private readonly string username = "sbuhs";
        private readonly string password = "sekerstajekip";
        private readonly HttpClient client;
        private string? sessionId;

        public ApiHelper()
        {
            client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        // Login işlemi: POST /login
        public async Task<(string sessionId, dynamic user)> LoginAsync(string tc, string sifre)
        {
            var payload = new { tc, sifre };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiBaseUrl}/login-tc", content); // endpoint değişti
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            
            dynamic obj = JsonConvert.DeserializeObject(json);
            sessionId = obj.sessionId;
            
            // Session-ID header'ı ekle
            client.DefaultRequestHeaders.Remove("Session-ID");
            client.DefaultRequestHeaders.Add("Session-ID", sessionId);
            
            return (sessionId, obj.user);
        }

        // Kayıt olma işlemi: POST /register
        public async Task<dynamic> RegisterAsync(object userData)
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(userData);
                System.Windows.Forms.MessageBox.Show($"Gönderilen JSON: {jsonData}", "Debug Info");
                
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                
                // Sadece /register endpoint'ini kullan
                var response = await client.PostAsync($"{apiBaseUrl}/register", content);
                
                var responseContent = await response.Content.ReadAsStringAsync();
                System.Windows.Forms.MessageBox.Show($"API Response Status: {response.StatusCode}\nResponse Content: {responseContent}", "API Response");
                
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"HTTP {response.StatusCode}: {responseContent}");
                }
                
                return JsonConvert.DeserializeObject(responseContent);
            }
            catch (HttpRequestException ex)
            {
                System.Windows.Forms.MessageBox.Show($"HTTP Error: {ex.Message}", "Error");
                throw;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"General Error: {ex.Message}", "Error");
                throw;
            }
        }

        // Kullanıcıları getir: GET /kullanicilar
        public async Task<dynamic> GetAllUsersAsync()
        {
            var response = await client.GetAsync($"{apiBaseUrl}/kullanicilar");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(json);
        }

        // Roller: GET /roller
        public async Task<dynamic> GetRolesAsync()
        {
            var response = await client.GetAsync($"{apiBaseUrl}/roller");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(json);
        }

        // TC doğrulama: POST /verify-tc
        public async Task<bool> VerifyTCAsync(string tc)
        {
            try
            {
                var payload = new { tc };
                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{apiBaseUrl}/verify-tc", content);
                var json = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    return false;
                dynamic obj = JsonConvert.DeserializeObject(json);
                return obj.verified == true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Hata");
                return false;
            }
        }

        // API endpoint'lerini test et
        public async Task<string> TestEndpointsAsync()
        {
            var endpoints = new[] { "/register", "/kayit", "/user", "/users", "/kullanici" };
            var results = new List<string>();
            
            foreach (var endpoint in endpoints)
            {
                try
                {
                    var response = await client.GetAsync($"{apiBaseUrl}{endpoint}");
                    results.Add($"{endpoint}: {response.StatusCode}");
                }
                catch (Exception ex)
                {
                    results.Add($"{endpoint}: Error - {ex.Message}");
                }
            }
            
            return string.Join("\n", results);
        }

        // Şifre sıfırlama: POST /reset-password
        public async Task<bool> ResetPasswordAsync(string tc, string newPasswordHash)
        {
            var payload = new { tc, sifre = newPasswordHash };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiBaseUrl}/reset-password", content);
            if (!response.IsSuccessStatusCode)
                return false;
            var json = await response.Content.ReadAsStringAsync();
            dynamic obj = JsonConvert.DeserializeObject(json);
            return obj.success == true;
        }

        // Kullanıcının ödünç aldığı kitapları getir: GET /kullanici-odunc/{userId}
        public async Task<dynamic> GetKitaplarimAsync(int kullaniciId)
        {
            try
            {
                // Yeni API dokümantasyonuna göre endpoint
                var response = await client.GetAsync($"{apiBaseUrl}/kullanici-odunc/{kullaniciId}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // 404 hatası durumunda boş liste döndür
                    return new { kitaplar = new List<object>() };
                }
                
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject(json);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show($"Kitaplarınız yüklenirken hata oluştu: Hata oluştu.", "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                // Hata durumunda boş liste döndür
                return new { kitaplar = new List<object>() };
            }
        }

        // Tüm kitapları getir: GET /kitaplar
        public async Task<dynamic> GetAllBooksAsync()
        {
            try
            {
                var fullUrl = $"{apiBaseUrl}/kitaplar";
                
                // Debug: URL'yi yazdır
                Console.WriteLine($"GetAllBooks URL: {fullUrl}");
                
                var response = await client.GetAsync(fullUrl);
                
                Console.WriteLine($"GetAllBooks Response Status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // 404 hatası durumunda boş liste döndür
                    Console.WriteLine("GetAllBooks 404 Not Found - Boş liste döndürülüyor");
                    return new List<object>();
                }
                
                if (!response.IsSuccessStatusCode)
                {
                    // API'den veri gelmezse boş liste döndür
                    Console.WriteLine($"GetAllBooks API Error: {response.StatusCode} - Boş liste döndürülüyor");
                    return new List<object>();
                }
                
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"GetAllBooks API Response: {json}");
                
                var result = JsonConvert.DeserializeObject(json);
                Console.WriteLine($"GetAllBooks Parsed Result Type: {result?.GetType()}");
                
                return result;
            }
            catch (Exception ex)
            {
                // Hata durumunda boş liste döndür
                Console.WriteLine($"GetAllBooks Error: {ex.Message}");
                return new List<object>();
            }
        }

        // Kitap arama: GET /kitap-bul
        public async Task<dynamic> SearchBooksAsync(string searchTerm = "", string filterType = "")
        {
            try
            {
                var queryParams = new List<string>();
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    // Filter türüne göre parametre adını belirle
                    string paramName = filterType switch
                    {
                        "kitap_adi" => "kitap_adi",
                        "yazar" => "yazar",
                        "yil" => "yil",
                        "yayinevi" => "yayinevi",
                        _ => "q" // Varsayılan genel arama
                    };
                    queryParams.Add($"{paramName}={Uri.EscapeDataString(searchTerm)}");
                }
                if (!string.IsNullOrEmpty(filterType) && filterType != "q")
                {
                    queryParams.Add($"filter={Uri.EscapeDataString(filterType)}");
                }

                var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
                var fullUrl = $"{apiBaseUrl}/kitap-bul{queryString}";
                
                // Debug: URL'yi yazdır
                Console.WriteLine($"SearchBooksAsync - Filter Type: {filterType}");
                Console.WriteLine($"SearchBooksAsync - Search Term: {searchTerm}");
                Console.WriteLine($"API URL: {fullUrl}");
                
                var response = await client.GetAsync(fullUrl);
                
                Console.WriteLine($"Response Status: {response.StatusCode}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // 404 hatası durumunda boş liste döndür
                    Console.WriteLine("404 Not Found - Boş liste döndürülüyor");
                    return new List<object>();
                }
                
                if (!response.IsSuccessStatusCode)
                {
                    // API'den veri gelmezse boş liste döndür
                    Console.WriteLine($"API Error: {response.StatusCode} - Boş liste döndürülüyor");
                    return new List<object>();
                }
                
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response: {json}");
                
                var result = JsonConvert.DeserializeObject(json);
                Console.WriteLine($"Parsed Result Type: {result?.GetType()}");
                
                return result;
            }
            catch (Exception ex)
            {
                // Hata durumunda boş liste döndür
                Console.WriteLine($"SearchBooksAsync Error: {ex.Message}");
                return new List<object>();
            }
        }
    }
} 