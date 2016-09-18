using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Project
    {
        public int ID { get; private set; }
        public List<Project> Dependence { get; private set; } = new List<Project>();
        public bool IsBuilt { get; private set; } = false;

        public Project(int id, List<Project> dependence)
        {
            ID = id;
            Dependence = dependence;
        }
        public Project(int id)
        {
            ID = id;
        }
        public void Build()
        {
            if (CanBuild())
            {
                Thread.Sleep(1000);
                Console.WriteLine("Build " +ID);
                IsBuilt = true;
            }

        }
        public bool CanBuild()
        {
            foreach (var item in Dependence)
            {
                if (item.IsBuilt == false)
                    return false;
            }
            return true;

        }
    }
}
