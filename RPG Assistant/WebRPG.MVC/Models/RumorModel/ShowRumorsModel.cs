using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRPG.MVC.Models.RumorModel
{
    public class ShowRumorsModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }



    }
}