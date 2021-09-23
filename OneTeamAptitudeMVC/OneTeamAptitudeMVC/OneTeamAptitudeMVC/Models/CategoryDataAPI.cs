using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OneTeamAptitudeMVC.Models
{
    public class CategoryDataAPI
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "CategoryName Required")]
        public string CategoryName { get; set; }
    }
}