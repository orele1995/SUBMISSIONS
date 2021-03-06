﻿using System;
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
       
        PrimeGenerator primeGenerator = new PrimeGenerator();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void calculatButton_Click(object sender, EventArgs e)
        {
            var synchronizationContext = SynchronizationContext.Current;
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

            Task.Run(() =>
           {
               var result = primeGenerator.CulcPrime(from, to);

               synchronizationContext.Send(_ =>
               {
                   numbersListBox.DataSource = result;
                   
               }, null);
           });


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            primeGenerator.AutoEvent.Set();
        }

        private void cancelButton2_Click(object sender, EventArgs e)
        {
            primeGenerator.cancellationTokenSource.Cancel();
        }
    }
}
