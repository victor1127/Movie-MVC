using Npgsql;

namespace MovieMVC.Services
{
    public class ConnectionService
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            var dataBaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            return string.IsNullOrEmpty(dataBaseUrl) ? defaultConnectionString : BuildConnectionString(dataBaseUrl);
        }

        private static string BuildConnectionString(string dataBaseUrl)
        {
            var dataBaseUri = new Uri(dataBaseUrl);
            var userInfo = dataBaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = dataBaseUri.Host,
                Port = dataBaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = dataBaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }
    }
}
