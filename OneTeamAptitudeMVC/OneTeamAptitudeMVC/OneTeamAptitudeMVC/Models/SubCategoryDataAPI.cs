using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OneTeamAptitudeMVC.Models
{
    public class SubCategoryDataAPI
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }


        [Required(ErrorMessage = "SubCategoryName Required")]
        public string SubCategoryName { get; set; }


        [Required(ErrorMessage = "CategoryName Required")]
        public string CategoryName { get; set; }
    }
}