namespace MandaeClient
{
    public class Credential
    {
        public string Token { get; private set; }
            
        public Credential(string token)
        {
            Token = token;
        }
    }
}
