using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Builder
    {
        public void BuildProjects (List<Project> projects)
        {
            foreach (var item in projects)
            {
                Build(item);
            }
        }
        public void Build(Project project)
        {
            #region ex4
            project.Build().Wait();
            #endregion
            #region ex3
            //if (!project.IsBuilt)
            //{
            //    foreach (var item in project.Dependence)
            //        Build(item);
            //    project.Build();
            //}
            #endregion
        }


    }
}
