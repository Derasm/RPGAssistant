using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRPG.MVC.Models.CharacterModel
{
    public class CreateCharacter
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string BackGroundStory { get; set; }
        [Required]
        public bool Active { get; set; }

    }
}