﻿using System.ComponentModel.DataAnnotations;

namespace WebAppFinalProj.Models
{
    public class UserInfo
    {
        [Key]
        public int ID { get; set; }
        public int MyProperty { get; set; }
        public DateTime Birthdate { get; set; }
        public string Major { get; set; }
        public int Year { get; set; }
    }
}
