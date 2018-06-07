using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerRPG.BusinessLogic;
using System.ServiceModel;
using ServerRPG.Model;
using System.Runtime.Serialization;

namespace ServerRPG.Server
{
    public class Skill : IGenericCRUD<Model.Skill>
    {
        CtrSkill skillController = new CtrSkill();
        public void Create(Model.Skill entity)
        {
            skillController.Create(entity);
        }

        public bool Delete(Model.Skill entity)
        {
            return skillController.Delete(entity);
        }

        public Model.Skill Find(string searcher)
        {
            Model.Skill skill = null;
            skill = skillController.Find(searcher);
            return skill;
        }

        public IEnumerable<Model.Skill> GetAll()
        {
            List<Model.Skill> listOfSkills = skillController.GetAll().ToList<Model.Skill>();
            return listOfSkills;
        }

        public int Update(Model.Skill entity)
        {
            return skillController.Update(entity);
        }
    }
}
