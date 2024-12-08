using System.ComponentModel.DataAnnotations;

namespace WebAppFinalProj.Models
{
    public class FavoriteCar
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
    }

}