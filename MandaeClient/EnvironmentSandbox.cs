namespace MandaeClient
{
    public class EnvironmentSandbox : IEnvironment
    {
        public string GetUrl() => "https://sandbox.api.mandae.com.br/";
    }
}
