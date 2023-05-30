using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programming_Assignment_1.Models;


namespace Programming_Assignment_1.NewFolder
{
    internal class ClientService
    {

        private static ClientService? instance;
        private static object _lock = new object();
        public static ClientService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientService();
                    }
                    return instance;
                }
            }
        }

        private List<Client> clients;

        private ClientService()
        {

            clients = new List<Client>();
        }

        public Client? Get(int id)
        {
            return clients.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Client c)
        {
            clients.Add(c);
        }

        public void Remove(Client c) 
        { 
            clients.Remove(c); 
        }

        public int Count() { return clients.Count; }

        public void Read()
        {
            clients.ForEach(Console.WriteLine);
        }
    }
}

