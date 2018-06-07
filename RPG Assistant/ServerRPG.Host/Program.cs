using ServerRPG.BusinessLogic;
using ServerRPG.DAL;
using ServerRPG.Model;
using ServerRPG.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.Host
{
    public class Program
    {

        static void Main(string[] args)
        {

            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            ServiceHost userHost = new ServiceHost(typeof(UserService));
            ServiceHost adventureHost = new ServiceHost(typeof(AdventureService));
            ServiceHost characterHost = new ServiceHost(typeof(CharacterService));
            ServiceHost rumorHost = new ServiceHost(typeof(RumorService));
            userHost.Open();
            adventureHost.Open();
            characterHost.Open();
            rumorHost.Open();

            Console.WriteLine("Hosting the service...");
            Console.ReadLine();
            userHost.Close();
            adventureHost.Close();
            characterHost.Close();
            rumorHost.Close();
            ((IDisposable)userHost).Dispose();
            ((IDisposable)adventureHost).Dispose();
            ((IDisposable)characterHost).Dispose();
            ((IDisposable)rumorHost).Dispose();








            //    using (ServiceHost host = new ServiceHost(typeof(UserService)))
            //    {
            //        host.Open();
            //        //checks the certificate when connecting to the server.
            //        Console.ReadLine();
            //    }
            //}

        }
    }
}
