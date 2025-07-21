using Microsoft.Data.SqlClient;
using System;
using System.Data;

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
} 