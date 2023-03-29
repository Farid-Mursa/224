namespace P230_Pronia.Entities
{
    public class PlantCategory:BaseEntity
    {
        public Plant Plant { get; set; }
        public Categories Category { get; set; }
    }
}
