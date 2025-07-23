using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Seker_kutuphane
{
    public class DatabaseHelper
    {
        // Bağlantı dizesini kendi sunucu ve şifrenize göre güncelleyin
        private string connectionString = "Server=10.100.74.48,1433;Database=seker_kutuphane;User Id=sa;Password=admin123;TrustServerCertificate=True;";

        // Kullanıcıyı email ile getirir
        public DataTable KullaniciGetir(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM KULLANICILAR WHERE email = @email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Kullanıcının rolünü getirir (örnek JOIN ile)
        public string KullaniciRolGetir(int kullaniciId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT r.rol_adi FROM KULLANICI_ROLLERI kr
                                 JOIN ROLLER r ON kr.rol_id = r.rol_id
                                 WHERE kr.kullanici_id = @kullaniciId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? string.Empty;
            }
        }
    }

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

        // Kayıt olma işlemi: POST /register
        public async Task<dynamic> RegisterAsync(object userData)
        {
            var content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiBaseUrl}/register", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(json);
        }
    }
} 