using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolmRakendust_Tiora
{
    public partial class Form2 : Form
    {
        TableLayoutPanel table;
        string[] tehed = new string[4] { "+", "-", "*", "/" };
        Label textb,timelabel;
        int pluss1, pluss2, miinus1, miinus2, korr1, korr2, jaga1, jaga2, aeglabi;
        Random rnd = new Random();
        Button btn;
        Timer aeg;
        public Form2()
        {
            this.Text = "Math Mäng";
            this.Width = 600;
            this.Height = 500;
            this.BackColor = Color.FromArgb(0, 141, 115);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            textb = new Label()
            {
                Font = new Font(Font.FontFamily, 18),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(140, 30),
            };
            timelabel = new Label()
            {
                Font = new Font(Font.FontFamily, 16),
                Text = "Timeleft",
                AutoSize = true,
                Location = new Point(400, 50),
            };
            btn = new Button
            {
                Text = "Start",
                Font = new Font(Font.FontFamily, 14),
                AutoSize = true,
                TabIndex = 0,
            };
            btn.Click += Btn_Click;
            aeg = new Timer()
            {
                Interval = 1000
            };
            aeg.Tick += Timer_Tick;

            table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 20),
                    new ColumnStyle(SizeType.Percent, 20),
                    new ColumnStyle(SizeType.Percent, 20),
                    new ColumnStyle(SizeType.Percent, 20),
                    new ColumnStyle(SizeType.Percent, 20),
                },
                RowStyles =
                {
                    new RowStyle(SizeType.Percent, 10),
                    new RowStyle(SizeType.Percent, 20),
                    new RowStyle(SizeType.Percent, 20),
                    new RowStyle(SizeType.Percent, 20),
                    new RowStyle(SizeType.Percent, 20),
                    new RowStyle(SizeType.Percent, 10),
                }
            };
            for (int i = 1; i < 5; i++)
            {
                Label num1 = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = "?",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(60, 60),
                };
                Label mark = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = tehed[i - 1].ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(60, 60),
                };
                Label num2 = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = "?",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(60, 60),
                };
                Label vordub = new Label
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Text = "=",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(60, 60),
                };
                NumericUpDown numeric = new NumericUpDown
                {
                    Font = new Font(FontFamily.GenericSansSerif, 18),
                    Width = 100,
                    TabIndex = i + 1,
                };
                table.Controls.Add(num1, 0, i);
                table.Controls.Add(mark, 1, i);
                table.Controls.Add(num2, 2, i);
                table.Controls.Add(vordub, 3, i);
                table.Controls.Add(numeric, 4, i);
            }
            table.Controls.Add(textb, 3, 0);
            table.SetColumnSpan(timelabel, 2);
            table.SetColumnSpan(textb, 2);
            table.Controls.Add(timelabel, 1, 0);
            table.SetColumnSpan(btn, 2);
            table.Controls.Add(btn, 2, 5);
            Controls.Add(table);
        }
        
        private void Btn_Click(object sender, EventArgs e)
        {
            AlustaMangu();
            btn.Enabled = false;
        }
        //
        private void Timer_Tick(object sender, EventArgs e)
        {
            NumericUpDown numeric = (NumericUpDown)table.GetControlFromPosition(4, 1);
            NumericUpDown miinus = (NumericUpDown)table.GetControlFromPosition(4, 2);//miinus
            NumericUpDown korruta = (NumericUpDown)table.GetControlFromPosition(4, 3);//korrutada
            NumericUpDown jaga = (NumericUpDown)table.GetControlFromPosition(4, 4);//jagama
            if (LabiVaatus())
            {
                //StartTime();
                aeg.Stop();
                MessageBox.Show("Kõik vastused on õiged!", "Võit!");
                btn.Enabled = true;
            }
            else if (aeglabi > 0)
            {
                aeglabi = aeglabi - 1;
                textb.Text = aeglabi + " sekundit";
            }
            else
            {
                //kui sa ei lõpeta 30 sekundiga, siis sa kaotad
                aeg.Stop();
                textb.Text = "Aeg on läbi!";
                MessageBox.Show("Te ei lõpetanud õigeks ajaks.", "Kaotus!");
                numeric.Value = pluss1 + pluss2;
                miinus.Value = miinus1 - miinus2;
                korruta.Value = korr1 * korr2;
                jaga.Value = jaga1 / jaga2;
                btn.Enabled = true;
            }
        }
        private bool LabiVaatus()
        {
            NumericUpDown numeric = (NumericUpDown)table.GetControlFromPosition(4, 1);
            NumericUpDown miinus = (NumericUpDown)table.GetControlFromPosition(4, 2);
            NumericUpDown korruta = (NumericUpDown)table.GetControlFromPosition(4, 3);
            NumericUpDown jaga = (NumericUpDown)table.GetControlFromPosition(4, 4);
            if ((pluss1 + pluss2 == numeric.Value)
                && (miinus1 - miinus2 == miinus.Value)
                && (korr1 * korr2 == korruta.Value)
                && (jaga1 / jaga2 == jaga.Value))
                return true;
            else
                return false;
        }
        public void AlustaMangu()
        {
            for (int row = 1; row < 5; row++)
            {
                Label num1 = (Label)table.GetControlFromPosition(0, row);
                Label symbol = (Label)table.GetControlFromPosition(1, row);
                Label num2 = (Label)table.GetControlFromPosition(2, row);
                NumericUpDown numeric = (NumericUpDown)table.GetControlFromPosition(4, row);
                int[] getnums = getNums(symbol.Text);
                num1.Text = getnums[0].ToString();
                num2.Text = getnums[1].ToString();
                numeric.Value = 0;
            }
            aeglabi = 30;
            textb.Text = "30 sekundit";
            aeg.Start();
            //StartTime();
        }
        public int[] getNums(string sym)
        {
            int num1 = 0;
            int num2 = 0;

            if (sym == "+")
            {
                num1 = rnd.Next(51);
                num2 = rnd.Next(51);
                pluss1 = num1;
                pluss2 = num2;
            }
            else if (sym == "-")
            {
                num1 = rnd.Next(1, 101);
                num2 = rnd.Next(1, num1);
                miinus1 = num1;
                miinus2 = num2;
            }
            else if (sym == "*")
            {
                num1 = rnd.Next(2, 11);
                num2 = rnd.Next(2, 11);
                korr1 = num1;
                korr2 = num2;
            }
            else if (sym == "/")
            {
                num2 = rnd.Next(2, 11);
                int temp = rnd.Next(2, 11);
                num1 = num2 * temp;
                jaga1 = num1;
                jaga2 = num2;
            }
            return new int[2] { num1, num2 };
        }
        /*private async void StartTime()
        {
            int time = 30;
            while (time != 0)
            {
                timelabel.Text = time.ToString() + " sekundit";
                time -= 1;
                await Task.Delay(1000);
            }
            timelabel.Text = "";
            this.Enabled = false;
        }*/
    }
}
