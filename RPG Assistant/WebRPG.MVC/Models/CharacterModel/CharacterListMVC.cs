using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRPG.MVC.Models.CharacterModel
{
    public class CharacterListMVC
    {
        public List<UserServiceReference.Character> Characters { get; set; }
        [Required]
        public string Name { get; set; }

        public int Level { get; set; }

        public string Class { get; set; }

        public string BackGroundStory { get; set; }

        public bool Active { get; set; }

    }
}