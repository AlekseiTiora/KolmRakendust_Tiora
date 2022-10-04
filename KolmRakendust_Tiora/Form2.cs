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
        string[] lehed = new string[4] { "+", "-", "*", "/" };
        string text;
        Label textb,timelabel;
        NumericUpDown nup;
        Button btn;
        public Form2()
        {
            this.Text = "math Quiz";
            this.Size = new Size(600,400);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;


            table = new TableLayoutPanel()
            {
                Location = new Point(15, 100),
                AutoSize = true,

            };


            nup = new NumericUpDown
            {
            
            };

            textb = new Label()
            {
                Text = "Time Left",
                Location = new Point(290, 10),
                Font = new Font("Arial", 15),
                AutoSize = true,

            };
            timelabel = new Label()
            {
                Name="TimeLable",
                BorderStyle= BorderStyle.FixedSingle,
                Width=120,
                Height=30,
                Location = new Point(390, 10)
            };
            btn = new Button()
            {
                Text = "Start",
                Size = new Size(50, 35),
                Location = new Point(250, 260),
                AutoSize = true,
                TabIndex = 0,

            };

            var l_nimed = new string[5, 4];
            for (int i = 0; i < 4; i++)
            {
                table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
                for (int j = 0; j < 5; j++)
                {
                    table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                    var l_nimi = "L" + j.ToString() + i.ToString();
                    l_nimed[j, i] = l_nimi;
                    if (j == 1) { text = lehed[i]; }//tehed = new string [4] {"+", "-", "*","/"};
                    else if (j == 2) { text = "?"; }
                    else if (j == 3) { text = "="; }
                    else if ( j == 4 ) {
                        nup = new NumericUpDown
                        {
                            Width = 100,
                            Font = new Font("Calibri",16, FontStyle.Bold),
                        };
                        table.Controls.Add(nup, j, i);
                        //table.SetCellPosition(nup, new TableLayoutPanelCellPosition(i - 1, j));
                    }
                    else
                    {
                        text ="?";  
                    }
                    if (j != 4) { 
                    Label l = new Label { Text = text };
                    table.Controls.Add(l, j, i);
                    }

                }

            }

            this.Controls.Add(table);
            this.Controls.Add(textb);
            this.Controls.Add(timelabel);
            this.Controls.Add(btn);

        }

    }
}
