﻿using System.ComponentModel.DataAnnotations;

namespace SuperMarketManagement.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }     
    }
}
