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
            this.Size = new Size(600, 500);
            this.BackColor = Color.FromArgb(0, 141, 115);
            Label text = new Label()
            {
                Text = "registreerimine",
                Location = new Point(140, 70),
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
            TextBox pass = new TextBox()
            {
                Location = new Point(200, 210),
                Height = 100,
                Font = new Font("Arial", 15),
                Width = 150,
            };

            this.Controls.Add(text);
            this.Controls.Add(login);
            this.Controls.Add(pass);
        }
    }
}
