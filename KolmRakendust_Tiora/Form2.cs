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
        public Form2()
        {
            this.Text = "math Quiz";
            this.Size = new Size(600, 500);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            
            table = new TableLayoutPanel();
            {
                AutoSize = true;
            }

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
                    else if (j == 3) { text = "="; }
                    else if (j == 4) { text = "vastus"; }
                    else { text = "?"; }//l_nimi
                    Label l = new Label { Text = text };
                    table.Controls.Add(l, j, i);
                }

            }
            
            this.Controls.Add(table);

        }

    }
}
