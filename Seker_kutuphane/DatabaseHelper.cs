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

        // Kitap arama: GET /kitaplar
        public async Task<dynamic> SearchBooksAsync(string searchTerm = "", string filterType = "")
        {
            try
            {
                var queryParams = new List<string>();
                if (!string.IsNullOrEmpty(searchTerm))
                    queryParams.Add($"q={Uri.EscapeDataString(searchTerm)}");
                if (!string.IsNullOrEmpty(filterType))
                    queryParams.Add($"filter={Uri.EscapeDataString(filterType)}");

                var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
                var response = await client.GetAsync($"{apiBaseUrl}/kitaplar{queryString}");
                
                if (!response.IsSuccessStatusCode)
                {
                    // API'den veri gelmezse örnek veriler döndür
                    return GetSampleBooks(searchTerm);
                }
                
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject(json);
            }
            catch (Exception ex)
            {
                // Hata durumunda örnek veriler döndür
                return GetSampleBooks(searchTerm);
            }
        }

        // Örnek kitap verileri
        private dynamic GetSampleBooks(string searchTerm = "")
        {
            var allBooks = new List<object>
            {
                new { KitapAdi = "Suç ve Ceza", Yazar = "Fyodor Dostoyevski", Yayinevi = "İş Bankası Kültür Yayınları", Yil = 1866, Stok = 5, Durum = "Mevcut" },
                new { KitapAdi = "1984", Yazar = "George Orwell", Yayinevi = "Can Yayınları", Yil = 1949, Stok = 3, Durum = "Mevcut" },
                new { KitapAdi = "Küçük Prens", Yazar = "Antoine de Saint-Exupéry", Yayinevi = "Can Yayınları", Yil = 1943, Stok = 8, Durum = "Mevcut" },
                new { KitapAdi = "Dönüşüm", Yazar = "Franz Kafka", Yayinevi = "İş Bankası Kültür Yayınları", Yil = 1915, Stok = 2, Durum = "Mevcut" },
                new { KitapAdi = "Fareler ve İnsanlar", Yazar = "John Steinbeck", Yayinevi = "Remzi Kitabevi", Yil = 1937, Stok = 4, Durum = "Mevcut" },
                new { KitapAdi = "Hayvan Çiftliği", Yazar = "George Orwell", Yayinevi = "Can Yayınları", Yil = 1945, Stok = 6, Durum = "Mevcut" },
                new { KitapAdi = "Şeker Portakalı", Yazar = "José Mauro de Vasconcelos", Yayinevi = "Can Yayınları", Yil = 1968, Stok = 3, Durum = "Mevcut" },
                new { KitapAdi = "Kürk Mantolu Madonna", Yazar = "Sabahattin Ali", Yayinevi = "Yapı Kredi Yayınları", Yil = 1943, Stok = 7, Durum = "Mevcut" },
                new { KitapAdi = "Simyacı", Yazar = "Paulo Coelho", Yayinevi = "Can Yayınları", Yil = 1988, Stok = 4, Durum = "Mevcut" },
                new { KitapAdi = "Küçük Kara Balık", Yazar = "Samed Behrengi", Yayinevi = "Can Yayınları", Yil = 1968, Stok = 6, Durum = "Mevcut" },
                new { KitapAdi = "Yabancı", Yazar = "Albert Camus", Yayinevi = "Can Yayınları", Yil = 1942, Stok = 3, Durum = "Mevcut" }
            };

            // Eğer arama terimi varsa filtrele
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var filteredBooks = allBooks.Where(book =>
                {
                    var bookDict = new Dictionary<string, object>();
                    foreach (var prop in book.GetType().GetProperties())
                    {
                        bookDict[prop.Name] = prop.GetValue(book);
                    }

                    return bookDict.Values.Any(value => 
                        value?.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true);
                }).ToList();

                return filteredBooks;
            }

            return allBooks;
        }
    }
} 