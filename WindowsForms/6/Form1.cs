﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private bool _isValidName = false;
        private bool _isValidePhone = false;
        int count = 0;
        string pos = "";
        public Form1()
        {
            InitializeComponent();
            MouseClick += Form1_MouseClick;
            MouseMove += Form1_MouseMove;
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = pos + $" X: {e.X}, Y: {e.Y}";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < 10 || e.Y < 10 || e.Y > this.Height - 10 || e.X > this.Width - 10)
            {
                pos = "out";
                this.Text = pos + $" X: {e.X}, Y: {e.Y}";
            }
            else
            if(e.X == 10 || e.Y == 10 || e.Y == this.Height - 10 || e.X == this.Width - 10)
            {
                pos = "on border";
                this.Text = pos + $" X: {e.X}, Y: {e.Y}";
            }
            else
            {
                pos = "in";
                this.Text = pos + $" X: {e.X}, Y: {e.Y}";
            }

            if(ModifierKeys.HasFlag(Keys.Control) && e.Button == MouseButtons.Left)
            {
                this.Close();
            }

            if(e.Button == MouseButtons.Right)
            {
                MessageBox.Show($"Width: {this.Width}\r\nHeight: {this.Height}");
            }
        }

        private void ShowResultsButton_Click(object sender, EventArgs e)
        {
            if (!_isValidePhone && !_isValidName)
            {
                MessageBox.Show("invalid name and phone!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_isValidName)
            {
                MessageBox.Show("invalid name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_isValidePhone)
            {
                MessageBox.Show("invalid phone!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var data = $"SNF: {textBoxSurename.Text} {textBoxName.Text} {textBoxFathername.Text}\n";
            data += $"Leave place: {textBoxCountry.Text} {textBoxCity.Text}\n";
            data += $"Phone number: {maskedTextBoxPhoneNumber.Text}\n";
            data += $"Date of birth: {dateTimePicker1.Value.ToLongDateString()}\n";
            data += $"Gender: ";
            if (radioButtonMale.Checked)
                data += $"Male\n";
            else if (radioButtonFemale.Checked)
                data += $"Female\n";
            else
                data += $"None\n";
            data += $"Your day of week of birth = {dateTimePicker1.Value.DayOfWeek}\n";
            DateTime a = Convert.ToDateTime(maskedTextBoxWeekDay.Text);
            switch(a.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    data += "Понедельник\n";
                    break;
                case DayOfWeek.Tuesday:
                    data += "Вторник\n";
                    break;
                case DayOfWeek.Wednesday:
                    data += "Среда\n";
                    break;
                case DayOfWeek.Thursday:
                    data += "Четверг\n";
                    break;
                case DayOfWeek.Friday:
                    data += "Пятница\n";
                    break;
                case DayOfWeek.Saturday:
                    data += "Субота\n";
                    break;
                case DayOfWeek.Sunday:
                    data += "Воскресение\n";
                    break;
                default:
                    data += "Nothing Special\n";
                    break;
            }

            
            MessageBox.Show(
                data,
                "Ankete data",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void textBoxName_KeyUp(object sender, KeyEventArgs e)
        {
            if ((sender as Control).Text.Length > 0)
            {
                _isValidName = true;
            }
            else
            {
                _isValidName = false;
            }
        }

        private void textBoxPhone_KeyUp(object sender, KeyEventArgs e)
        {
            if ((sender as Control).Text.Length == 15)
            {
                _isValidePhone = true;
            }
            else
            {
                _isValidePhone = false;
            }
        }
        
        private void textBoxDateResult_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                if (maskedTextBoxDate1.Text.Length == 10 && maskedTextBoxDate2.Text.Length == 10)
                {
                    DateTime a = Convert.ToDateTime(maskedTextBoxDate1.Text);
                    DateTime b = Convert.ToDateTime(maskedTextBoxDate2.Text);
                    TimeSpan res = a.Subtract(b);
                    if (checkBoxDay.Checked)
                    {
                        textBoxDateResult.Text = res.TotalDays.ToString();
                    }
                    else if (checkBoxMonth.Checked)
                    {
                        textBoxDateResult.Text = $"~{res.TotalDays / 30}";
                    }
                    else if (checkBoxYear.Checked)
                    {
                        textBoxDateResult.Text = $"~{res.TotalDays / 365}";
                    }
                    else
                    {
                        MessageBox.Show("Check one of checkboxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect dates", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult a;
            do
            {
                count++;
                a = MessageBox.Show($"Is this {new Random().Next(2001)} ?", $"Count: {count}", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }
            while (a == DialogResult.No);
            MessageBox.Show($"Count: {count}");
            count = 0;
        }
    }
}
