using System;
using System.Configuration;
using Npgsql;

namespace Estoque.Helpers
{
    public static class SupabaseConnectionSettings
    {
        public static string GetConnectionString()
        {
            var appSetting = ConfigurationManager.AppSettings["Supabase_Url"];

            if (!string.IsNullOrWhiteSpace(appSetting))
            {
                return Normalize(appSetting);
            }

            var connectionString = ConfigurationManager.ConnectionStrings["EstoqueContext"];

            if (connectionString == null || string.IsNullOrWhiteSpace(connectionString.ConnectionString))
            {
                throw new InvalidOperationException("Connection string EstoqueContext nao foi configurada.");
            }

            return Normalize(connectionString.ConnectionString);
        }

        private static string Normalize(string value)
        {
            value = value.Trim();

            if (value.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase) ||
                value.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase))
            {
                return ConvertPostgresUri(value);
            }

            return value;
        }

        private static string ConvertPostgresUri(string uri)
        {
            var schemeEnd = uri.IndexOf("://", StringComparison.Ordinal);
            var withoutScheme = uri.Substring(schemeEnd + 3);
            var atIndex = withoutScheme.LastIndexOf('@');

            if (atIndex <= 0)
            {
                throw new FormatException("Supabase_Url invalida. Use o formato postgresql://usuario:senha@host:porta/banco.");
            }

            var userInfo = withoutScheme.Substring(0, atIndex);
            var hostInfo = withoutScheme.Substring(atIndex + 1);
            var colonIndex = userInfo.IndexOf(':');

            if (colonIndex <= 0)
            {
                throw new FormatException("Supabase_Url invalida. Usuario e senha nao foram encontrados.");
            }

            var username = Uri.UnescapeDataString(userInfo.Substring(0, colonIndex));
            var password = Uri.UnescapeDataString(userInfo.Substring(colonIndex + 1));
            var slashIndex = hostInfo.IndexOf('/');
            var hostPort = slashIndex >= 0 ? hostInfo.Substring(0, slashIndex) : hostInfo;
            var database = slashIndex >= 0 ? hostInfo.Substring(slashIndex + 1) : "postgres";
            var questionIndex = database.IndexOf('?');

            if (questionIndex >= 0)
            {
                database = database.Substring(0, questionIndex);
            }

            var host = hostPort;
            var port = 5432;
            var portIndex = hostPort.LastIndexOf(':');

            if (portIndex > 0 && int.TryParse(hostPort.Substring(portIndex + 1), out var parsedPort))
            {
                host = hostPort.Substring(0, portIndex);
                port = parsedPort;
            }

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = host,
                Port = port,
                Database = Uri.UnescapeDataString(database),
                Username = username,
                Password = password,
                SslMode = SslMode.Require,
                TrustServerCertificate = true,
                Pooling = true,
                MinPoolSize = 0,
                MaxPoolSize = 20,
                Timeout = 15,
                CommandTimeout = 30
            };

            return builder.ConnectionString;
        }
    }
}
