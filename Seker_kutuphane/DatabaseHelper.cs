using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            var content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiBaseUrl}/register", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(json);
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
    }
} 