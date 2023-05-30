using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programming_Assignment_1.Models;


namespace Programming_Assignment_1.NewFolder
{
    internal class ProjectService
    {

        private static ProjectService? instance;
        private static object _lock = new object();
  public static ProjectService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectService();
                    }
                    return instance;
                }               
            }
        }

    private List<Project> projects;

        private ProjectService()
        {

            projects = new List<Project>();
        }

        public Project? Get(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);

        }

        public void Add(Project p) { projects.Add(p); }
        public void Remove(Project project) { projects.Remove(project); }

      

        public void Read()
        {
           projects.ForEach(Console.WriteLine);
        }

    }
}
