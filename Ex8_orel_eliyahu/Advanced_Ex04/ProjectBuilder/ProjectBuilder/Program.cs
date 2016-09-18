using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Project> projects = new List<Project>();
            var p1 = new Project(1);
            var p2 = new Project(2);
            var p3 = new Project(3);
            var p4 = new Project(4, new List<Project>() { p1 });
            var p5 = new Project(5, new List<Project>() { p2, p3 });
            var p6 = new Project(6, new List<Project>() { p4, p3 });
            var p7 = new Project(7, new List<Project>() { p6, p5 });
            var p8 = new Project(8, new List<Project>() { p5 });

           
            projects.Add(p3);
            projects.Add(p4);
            projects.Add(p5);
            projects.Add(p7);
            projects.Add(p1);
            projects.Add(p2);
            projects.Add(p8);
            projects.Add(p6);

            // uncomment the methods in Project class that match to the excercise
            Builder builder = new Builder();
            builder.BuildProjects(projects);



        }
    }
}
