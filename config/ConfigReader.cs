namespace Bardakbot.config
{
    internal class ConfigReader
    {
        private readonly string KEY_TOKEN = "TOKEN";
        private readonly string KEY_PREFIX = "PREFIX";

        public string? token { get; set; }
        public string? prefix { get; set; }

        public ConfigReader()
        {
            ReadConfig();
        }

        public void ReadConfig()
        {
            using (var stream = File.OpenRead("../../../.env"))
            {
                DotNetEnv.Env.Load(stream);
            }

            string? token = Environment.GetEnvironmentVariable(KEY_TOKEN);
            string? prefix = Environment.GetEnvironmentVariable(KEY_PREFIX);

            if (token == null || prefix == null)
            {
                throw new System.Exception("Failed retrieving bot config");
            }

            this.token = token;
            this.prefix = prefix;
        }
    }
}