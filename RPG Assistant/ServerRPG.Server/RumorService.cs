using System.Collections.Generic;
using System.Linq;
using ServerRPG.BusinessLogic;
using ServerRPG.Model;

namespace ServerRPG.Server
{

    public class RumorService : IRumor
    {
        CtrRumor rumorController = new CtrRumor();
        public void Create(Rumor entity)
        {
            rumorController.Create(entity);
        }

        public bool Delete(Rumor entity)
        {
            return rumorController.Delete(entity);
        }

        public Rumor Find(string searcher)
        {
            Rumor rumor = null;
            rumor = rumorController.Find(searcher);
            return rumor;
        }

        public List<Rumor> GetAll()
        {
            List<Rumor> lisOfRumors = rumorController.GetAll().ToList<Rumor>();
            return lisOfRumors;
        }

        public int Update(Rumor entity)
        {
            return rumorController.Update(entity);
        }
    }
}
