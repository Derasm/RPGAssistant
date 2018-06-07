using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerRPG.BusinessLogic;
using ServerRPG.Model;

namespace ServerRPG.Server
{
    public class AdventureService : IAdventure
    {
        CtrAdventure ctrAdventure = new CtrAdventure();
        public void Create(Adventure entity)
        {
            ctrAdventure.Create(entity);
        }

        public bool Delete(Adventure entity)
        {
            return ctrAdventure.Delete(entity);
        }

        public Adventure Find(string searcher)
        {
            return ctrAdventure.Find(searcher);
        }

        public List<Adventure> GetAll()
        {
            return ctrAdventure.GetAll().ToList();
        }

        public int Update(Adventure entity)
        {
            return ctrAdventure.Update(entity);
        }
    }
}
