using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        static AutoResetEvent autoEvent = new AutoResetEvent(false);
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken;
        public Form1()
        {
            InitializeComponent();
            cancellationToken = cancellationTokenSource.Token;
            cancellationToken.Register(() =>
            {
                
            });
        }

        private void calculatButton_Click(object sender, EventArgs e)
        {
            var synchronizationContext = SynchronizationContext.Current;
           
            Task.Run(() =>
           {
               Thread.Sleep(2000);
               synchronizationContext.Send(_ =>
               {
                   var primeGenerator = new PrimeGenerator();
                   int from, to;
                   if (int.TryParse(fromTextBox.Text, out from) == false)
                   {
                       MessageBox.Show("Value in 'from' must be a number");
                       return;
                   }
                   if (int.TryParse(toTextBox.Text, out to) == false)
                   {
                       MessageBox.Show("Value in 'to' must be a number");
                       return;
                   }
                   if (to < from)
                   {
                       MessageBox.Show("Value in 'from' must be smaller then value in 'to' ");
                       return;
                   }
                   if (autoEvent.WaitOne(0))
                   {

                       MessageBox.Show("Cancelled - autoEvent.WaitOne(0)");
                       return;
                   }
                   if (cancellationToken.IsCancellationRequested)
                   {
                       cancellationTokenSource = new CancellationTokenSource();
                       cancellationToken = cancellationTokenSource.Token;
                       MessageBox.Show("Cancelled - cancellationToken");
                       return;
                   }
                   numbersListBox.DataSource = primeGenerator.CulcPrime(from, to);
               }, null);
           }, cancellationToken);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            autoEvent.Set();
        }

        private void cancelButton2_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }
}
