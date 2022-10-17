using KolmRakendust_Tiora.Properties;
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

namespace KolmRakendust_Tiora
{
    public partial class register : Form
    {
        TextBox login, email, sugu, pass;
        NumericUpDown vanus;
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

            login = new TextBox()
            {
                Location = new Point(200, 140),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 190,
            };
            email = new TextBox()
            {
                Location = new Point(200, 190),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 190,
            };
            sugu = new TextBox()
            {
                Location = new Point(200, 240),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 190,
            };

            vanus = new NumericUpDown()
            {
                Location = new Point(200, 290),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 190,
            };

            pass = new TextBox()
            {
                Location = new Point(200, 340),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 190,
                UseSystemPasswordChar = true
            };

            Button btn_register = new Button()
            {
                Text = "Registreeri",
                Size = new Size(90, 40),
                Location = new Point(220, 400),
                BackColor = Color.FromArgb(0, 141, 0),
            };
            btn_register.Click += Btn_register_Click;
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

        
        private async void Btn_register_Click(object sender, EventArgs e)
        {
            string registr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Aleksei Tiora TARpv20\KolmRakendust_Tiora\KolmRakendust_Tiora\Login.mdf";
            SqlConnection registreeti = new SqlConnection(registr);
            int a = 0;
            registreeti.Open();
            if(login.Text !="" && email.Text != "" && sugu.Text != "" && vanus.Text != "" && pass.Text!= "")
            {

                SqlCommand sqlcmd = registreeti.CreateCommand();
                sqlcmd.CommandText = "INSERT INTO login(kasutajanimi,email,sugu,vanus,parool) VALUES('" + login.Text + "','" + email.Text + "', '" + sugu.Text + "', '" + vanus.Text + "','" + pass.Text + "')";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
                sda.Fill(dt);
                a = Convert.ToInt32(dt.Rows.Count.ToString());
                MessageBox.Show("konto loodud","palju õnne");
                Login ln = new Login();
                ln.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sa jätsid tühjad read");

            }

            registreeti.Close();
        }
        

        private void Btn_tagasi_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            lgn.Show();
            this.Hide();
        }
    }
}
