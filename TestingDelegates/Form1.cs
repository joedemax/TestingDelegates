using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TestingDelegates
{
    public delegate void LabelDelegate(int y);
    public delegate void TimerTick(int i);

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            TimerTick tick = new TimerTick(UpdateLabel);
            CounterClass counterClass = new CounterClass(tick);
            tick += test2;
            Console.WriteLine("wtf");
        }


        private void UpdateLabel(int y)
        {
            if(label1.InvokeRequired)
            {
                LabelDelegate labelDelegate = new LabelDelegate(UpdateLabel);
                label1.Invoke(labelDelegate, y);
            }
            label1.Text = y.ToString();
        }

        private void test(int i)
        {
            Console.WriteLine("Test {0}", i);
        }

        private void test2(int i)
        {
            Console.WriteLine("Test 2 {0}", i);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
