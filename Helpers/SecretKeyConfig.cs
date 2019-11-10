using System.Text;

namespace Autenticacao.Helpers
{
    public class SecretKeyConfig
    {
        public string SecretKey { get; set; }

        public byte[] SecretKeyBytes 
        {
            get => Encoding.ASCII.GetBytes(SecretKey);
        }
    }
}
