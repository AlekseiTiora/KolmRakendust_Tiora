using KolmRakendust_Tiora.Properties;
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
    public partial class Start : Form
    {
        Label text;
        public Start()
        {
            this.Text = "Menu App";
            this.Size = new Size(600, 500);
            this.BackColor = Color.FromArgb(0, 141, 115);

            text = new Label()
            {
                Text = "Vali rakendus",
                Location = new Point(220, 80),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };

            Button rakendus1 = new Button()
            {
                Text= "Pildi vaatamise programm",
                Size = new Size(120, 60), 
                Location = new Point(50, 200),
                BackColor = Color.FromArgb(0, 141, 0),
            };
            rakendus1.Click += Start_Click1;

            Button rakendus2 = new Button()
            {
                Text = "Matemaatiline äraarvamismäng",
                Size = new Size(120, 60),
                Location = new Point(220, 200),
                BackColor = Color.FromArgb(0, 141, 0),
            };
            rakendus2.Click += Rakendus2_Click;

            Button rakendus3 = new Button()
            {
                Text = "Sarnaste piltide leidmise mäng",
                Size = new Size(120, 60),
                Location = new Point(400, 200),
                BackColor = Color.FromArgb(0, 141, 0),
            };
            rakendus3.Click += Rakendus3_Click;

            Button logout = new Button()
            {
                Text = "loogi välja",
                Size = new Size(120, 60),
                Location = new Point(220, 350),
                BackColor = Color.FromArgb(0, 141, 0),
            };
            logout.Click += Logout_Click;
            this.Controls.Add(rakendus1);
            this.Controls.Add(rakendus2);
            this.Controls.Add(rakendus3);   
            this.Controls.Add(logout);
            this.Controls.Add(text);


        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Login logout = new Login();
            logout.Show();
            this.Hide();
        }

        private void Rakendus3_Click(object sender, EventArgs e)
        {
            Form3 rakendus3 = new Form3();
            rakendus3.Show();
            this.Hide();
        }

        private void Rakendus2_Click(object sender, EventArgs e)
        {
            Form2 rakendus1 = new Form2();
            rakendus1.Show();
            this.Hide();
        }

        private void Start_Click1(object sender, EventArgs e)
        {
            Form1 rakendus1 = new Form1();
            rakendus1.Show();
            this.Hide();
        }
    }
}
