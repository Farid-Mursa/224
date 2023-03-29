﻿using System.ComponentModel.DataAnnotations;

namespace P230_Pronia.Entities
{
    public class Categories : BaseEntity
    {
        [Required(ErrorMessage="Zehmet olmasa inputu doldurun")]
        public string Name { get; set; }
        public List<PlantCategory> PlantCategories{ get; set; }
    }
}
