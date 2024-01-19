using System.Text.Json.Serialization;

namespace Informer.Infrastructure.Models
{
    public class RefreshToken
    {
        public string UserName { get; set; } = string.Empty;    

        public string TokenString { get; set; } = string.Empty;

        public DateTime ExpireAt { get; set; }
    }
}