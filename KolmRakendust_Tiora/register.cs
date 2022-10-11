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
    public partial class register : Form
    {
        public register()
        {
            this.Text = "Menu App";
            this.Size = new Size(550, 600);
            this.BackColor = Color.FromArgb(0, 141, 115);
            Label text = new Label()
            {
                Text = "registreerimine",
                Location = new Point(200, 70),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };
            Label txtlogin = new Label()
            {
                Text = "Kasutajanimi:",
                Location = new Point(70, 140),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };
            Label txtemail = new Label()
            {
                Text = "email:",
                Location = new Point(135, 190),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };
            Label txtsugu = new Label()
            {
                Text = "sugu:",
                Location = new Point(140, 240),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };
            Label txtvanus = new Label()
            {
                Text = "vanus:",
                Location = new Point(130, 290),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };
            Label txtpass = new Label()
            {
                Text = "parool:",
                Location = new Point(127, 340),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };

            TextBox login = new TextBox()
            {
                Location = new Point(200, 140),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 150,
            };
            TextBox email = new TextBox()
            {
                Location = new Point(200, 190),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 150,
            };
            TextBox sugu = new TextBox()
            {
                Location = new Point(200, 240),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 150,
            };

            NumericUpDown vanus = new NumericUpDown()
            {
                Location = new Point(200, 290),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 150,
            };

            TextBox pass = new TextBox()
            {
                Location = new Point(200, 340),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 150,
                UseSystemPasswordChar = true
            };

            Button btn_register = new Button()
            {
                Text = "Registreeri",
                Size = new Size(90, 40),
                Location = new Point(220, 400),
                BackColor = Color.FromArgb(0, 141, 0),
            };
            Button btn_tagasi = new Button()
            {
                Text = "Mul on kasutaja",
                Size = new Size(90, 40),
                Location = new Point(220, 460),
                BackColor = Color.FromArgb(0, 141, 0),
            };
            btn_tagasi.Click += Btn_tagasi_Click;

            this.Controls.Add(text);
            this.Controls.Add(txtlogin);
            this.Controls.Add(txtemail);
            this.Controls.Add(txtsugu);
            this.Controls.Add(txtvanus);
            this.Controls.Add(txtpass);
            this.Controls.Add(login);
            this.Controls.Add(email);
            this.Controls.Add(sugu);
            this.Controls.Add(vanus);
            this.Controls.Add(pass);
            this.Controls.Add(btn_register);
            this.Controls.Add(btn_tagasi);
        }

        private void Btn_tagasi_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            lgn.Show();
            this.Hide();
        }
    }
}
