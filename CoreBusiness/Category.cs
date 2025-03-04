﻿using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }    
        
        public List<Product>? Products { get; set; }
    }
}
