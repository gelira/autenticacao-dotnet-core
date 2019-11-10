namespace Autenticacao.Helpers
{
    public class DatabaseConfig
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConnectionString 
        {
            get => string.Format(
                "Host={0};Port={1};Database={2};Username={3};Password={4}",
                Host, Port, Database, Username, Password);
        }
    }
}
