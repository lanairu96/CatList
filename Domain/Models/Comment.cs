using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Comment : AuditableBaseEntity
    {
        [Required, StringLength(1000)]
        public string Message { get; set; }
        
        [Required]
        public int CatId { get; set; }

        [JsonIgnore]
        public Cat Cat { get; set; }

        [Required]
        public string UserId { get; set; }

        [JsonIgnore]
        public IdentityUser User { get; set; }
    }
}
