using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolmRakendust_Tiora.Properties
{
    public partial class Login : Form
    {
        static string conn_login = @"C:\Users\opilane\source\repos\Aleksei Tiora TARpv20\KolmRakendust_Tiora\KolmRakendust_Tiora\Login.mdf";

        SqlConnection connect_login = new SqlConnection(conn_login);
        SqlCommand command;
        SqlDataAdapter adapter;
        //
        public Login()
        {
            this.Text = "Menu App";
            this.Size = new Size(600, 500);
            this.BackColor = Color.FromArgb(0, 141, 115);

            Label text = new Label()
            {
                Text = "sisselogimine või registreerimine",
                Location = new Point(140, 70),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };
            Label login1 = new Label()
            {
                Text = "Kasutajanimi:",
                Location = new Point(76, 144),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };
            Label pass1 = new Label()
            {
                Text = "Рarool:",
                Location = new Point(130, 214),
                Font = new Font("Arial", 15),
                AutoSize = true,
            };
            TextBox login = new TextBox()
            {
                Location = new Point(200, 140),
                Height=100,
                Font = new Font("Arial", 15),
                Width =150,
            };
            TextBox pass = new TextBox()
            {
                Location = new Point(200, 210),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 150,
            };
            Button btn_login = new Button()
            {
                Text = "Logi sisse",
                Size = new Size(90, 40),
                Location = new Point(225, 270),
                BackColor = Color.FromArgb(0, 141, 0),
            };
            btn_login.Click += Btn_login_Click;
            Button btn_register = new Button()
            {
                Text = "Registreeri",
                Size = new Size(90, 40),
                Location = new Point(225, 325),
                BackColor = Color.FromArgb(0, 141, 0),
            };
            btn_register.Click += Btn_register_Click;

            this.Controls.Add(text);
            this.Controls.Add(login);
            this.Controls.Add(pass);
            this.Controls.Add(login1);
            this.Controls.Add(pass1);
            this.Controls.Add(btn_login);
            this.Controls.Add(btn_register);
        }
        
        private void Btn_register_Click(object sender, EventArgs e)
        {
            register Reg = new register();
            Reg.Show();
            this.Hide();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            
        }
    }
}
