using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{

    public class MailManager
    {
        public EventHandler<MailArrivedEventArgs> MailArrived;

        protected virtual void OnMailArrived (string  title, string body)
        {
            MailArrived(this, new MailArrivedEventArgs(title,body));
        }

        public void SimulateMailArrived()
        {
            OnMailArrived("title", "body");
        }

    }
}
