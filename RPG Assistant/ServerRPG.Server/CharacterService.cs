using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServerRPG.BusinessLogic;
using ServerRPG.Model;

namespace ServerRPG.Server
{
    public class CharacterService : ICharacter
    {
        CtrCharacter chaController = new CtrCharacter();

        public void Create(Character entity)
        {
            chaController.Create(entity);
        }

        public bool Delete(Character entity)
        {
            return chaController.Delete(entity);
        }

        public Character Find(string searcher)
        {
            Character character = chaController.Find(searcher);
            return character;
        }

        public List<Character> GetAll()
        {
            return chaController.GetAll().ToList<Model.Character>();
        }

        public int Update(Character entity)
        {
            return chaController.Update(entity);
        }
    }
}
