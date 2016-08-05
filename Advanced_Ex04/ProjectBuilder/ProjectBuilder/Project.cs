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
        private Task _buildTask = null;

        public Project(int id, List<Project> dependence)
        {
            ID = id;
            Dependence = dependence;
        }
        public Project(int id)
        {
            ID = id;
        }
        #region Build for ex4
        public Task Build()
        {
            if (_buildTask != null) // Concurrent builds may still occur, but for simplicity reasons I've chosen to ignore this case.
                return _buildTask;
            if (Dependence.Count == 0)
                return Task.Run(() =>
                {
                    if (!IsBuilt)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Build " + ID);
                        IsBuilt = true;
                    }
                });
            var dependenciesTask = Dependence.Select(dependency => dependency.Build()).ToArray();
            _buildTask= Task.Factory.ContinueWhenAll(dependenciesTask, tasks => {
                if (!IsBuilt)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Build " + ID);
                    IsBuilt = true;
                }
            });
            return _buildTask;
        }
        #endregion

        #region Build for ex3
        /*
        public void Build()
        {
            if (CanBuild())
            {
                Thread.Sleep(1000);
                Console.WriteLine("Build " + ID);
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
        */
        #endregion

    }
}
