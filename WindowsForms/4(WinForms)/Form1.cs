//https://ivinsky.livejournal.com/3266.html



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_WinForms_
{
    public partial class Form1 : Form
    {
        
        Timer vTimer;
        Timer vTime;
        public Form1()
        {
            InitializeComponent();
            vTimer = new Timer();
            buttonStop.Enabled = false;
            vTimer.Tick += new EventHandler(ShowTimer);

            labelTime.Text = DateTime.Now.ToShortTimeString();
            vTime = new Timer();
            vTime.Tick += new EventHandler(UpdateTime);
            vTime.Interval = 500;
            vTime.Start();
            
        }
        private void UpdateTime(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToShortTimeString();
        }
        private void ShowTimer(object sender, EventArgs e)
        {
            vTimer.Stop();
            buttonStop.Enabled = false;
            MessageBox.Show("Таймер закончил работу", "Timer!");
        }
        
        private void Loader(object sender, EventArgs e)
        {
            MessageBox.Show("Ku");
        }

        private string CoordinateToString(MouseEventArgs e)
        {
            return $"mouse coordinates: x:{e.X} y:{e.Y};";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(ModifierKeys.HasFlag(Keys.Control))
            {
                this.Close();
            }
            var message = "";
            if(e.Button==MouseButtons.Left)
            {
                message = "Left mouse button";
            }
            if(e.Button==MouseButtons.Right)
            {
                message = "Right mouse button";
            }
            message += $"\n{CoordinateToString(e)}";
            var caption = "Mouse click";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = CoordinateToString(e);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            // проверка
            if(numericSeconds.Value<=0)
            {
                MessageBox.Show("Значение должно быть больше нуля", "Huh, Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            buttonStop.Enabled = true;
            // умнажаем на 100 т.к. интервал в милисекундах
            vTimer.Interval = Decimal.ToInt32(numericSeconds.Value)*1000;
            // запуск таймера
            vTimer.Start();
            
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            vTimer.Stop();
            MessageBox.Show("Таймер не закончил работу!", "Timer!");
            buttonStop.Enabled = false;
        }



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var a = 'a';
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
