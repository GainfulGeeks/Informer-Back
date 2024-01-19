using System.Text.Json.Serialization;

namespace Informer.Infrastructure.Models
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; } = string.Empty;

        public RefreshToken RefreshToken { get; set; } = new();
    }
}