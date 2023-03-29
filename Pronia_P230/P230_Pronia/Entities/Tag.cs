using System.ComponentModel.DataAnnotations;
namespace P230_Pronia.Entities
{
    public class Tag:BaseEntity
    {
        [Required(ErrorMessage = "Zehmet olmasa inputu doldurun")]
        public string Name { get; set; }

        public List<PlantTag> PlantTags { get; set; }
    }
}
