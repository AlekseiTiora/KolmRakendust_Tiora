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
        TextBox login, pass;
        public Login()
        {
            this.Text = "Menu App";
            this.Size = new Size(600, 500);
            this.BackColor = Color.FromArgb(0, 141, 115);

            Label text = new Label()
            {
                Text = "sisselogimine",
                Location = new Point(210, 70),
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
            login = new TextBox()
            {
                Location = new Point(200, 140),
                Height=100,
                Font = new Font("Arial", 15),
                Width =150,
            };
            pass = new TextBox()
            {
                Location = new Point(200, 210),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 150,
                UseSystemPasswordChar = true
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
        string loginpass = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Aleksei Tiora TARpv20\KolmRakendust_Tiora\KolmRakendust_Tiora\Login.mdf;Integrated Security=True";
        private async void Btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection loginandpass = new SqlConnection(loginpass);
            int a = 0;
            loginandpass.Open();
            SqlCommand sqlcmd = loginandpass.CreateCommand();
            sqlcmd.CommandText = "select * from login where kasutajanimi = '" + login.Text + "'and parool= '" + pass.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
            sda.Fill(dt);
            a = Convert.ToInt32(dt.Rows.Count.ToString());
            if (a == 0)
            {
                MessageBox.Show("login või parool pole õige või olemas");
            }
            else
            {
                this.Hide();
                Start start = new Start();
                start.Show();
            }
            loginandpass.Close();
        }
    }
}
