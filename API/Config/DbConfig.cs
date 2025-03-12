namespace API.Config
{
    public class DbConfig
    {
        public string ConnectionString { get; }

        public DbConfig()
        {
            DotNetEnv.Env.Load();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            string dbServer = configuration["DB_SERVER"] ?? "localhost";
            string dbPort = configuration["DB_PORT"] ?? "1234";
            string dbName = configuration["DB_NAME"] ?? "base";
            string dbUser = configuration["DB_USER"] ?? "is";
            string dbPassword = configuration["DB_PASSWORD"] ?? "JAJS";

            ConnectionString = $"Server={dbServer},{dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=True;";
        }
    }
}
