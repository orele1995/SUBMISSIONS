using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    class CodeReviewAttribute : Attribute
    {
        public string Reviewer { get; set; }
        public string ReviewDate { get; set; }
        public bool Approved { get; set; }
       
        public CodeReviewAttribute (string reviewer, string revieweDate, bool approved)
        {
            Reviewer = reviewer;
            ReviewDate = revieweDate;
            Approved = approved;
        }

    }
}
