using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Tp_Final_Fred.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public override string ToString()
            => $"{Name}\nLat: {Latitude}\nLon: {Longitude}";
    }
}
