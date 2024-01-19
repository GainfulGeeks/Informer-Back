using System.Text.Json.Serialization;

namespace Informer.Infrastructure.Models
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; } = string.Empty;

    }
}
