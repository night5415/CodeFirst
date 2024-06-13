﻿using System.ComponentModel.DataAnnotations;

namespace Code_First.Entities
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
    }
}
