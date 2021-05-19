using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paises.Models
{
    public class Country 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Capital { get; set; }
        public decimal Latitude { get; set; }
        public decimal Length { get; set; }
        public decimal Size { get; set; }
        public int Population { get; set; }
    }
}