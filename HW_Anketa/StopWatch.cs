using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HW_Anketa
{
    public partial class StopWatch : Form
    {
        private Stopwatch stopwatch = new Stopwatch();
        public StopWatch()
        {
            InitializeComponent();
            bt_stop.Enabled = false;            
            timer1.Tick += new EventHandler(ShowTimer);
            timer2.Tick += new EventHandler(Countdown);
        }
        private void ShowTimer(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            stopwatch.Reset();
            if (numericUpDown1.Value != 0)
                numericUpDown1.Value -= 1;
            bt_stop.Enabled = false;
            MessageBox.Show("Время вышло", "Timer");
        }
        private void Countdown(object sender, EventArgs e)
        {
            numericUpDown1.Value -= 1;
            Thread.Sleep(1000);
            timer2.Start();
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Установите время");                
                return;
            }
            else
            {
                bt_start.Enabled = true;
                bt_stop.Enabled = true;
                timer1.Interval = Decimal.ToInt32(numericUpDown1.Value) * 1000;
                timer1.Start();
                stopwatch.Start();
                timer2.Start();
            }
           
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            stopwatch.Stop();
            bt_stop.Enabled = false;
            MessageBox.Show("Вы остановили таймер.\n" +
                "осталось " + (timer1.Interval / 1000 - Math.Round(stopwatch.Elapsed.TotalSeconds, 2)).ToString() + "сек.", "TIMER");
            stopwatch.Reset();
        }
    }
}
