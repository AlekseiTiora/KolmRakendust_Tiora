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
    public partial class Form3 : Form
    {
        Random random = new Random();
        TableLayoutPanel tlp;
        Label esimeneClk = null;
        Label teineClk = null;
        Timer time;
        List<string> icons = new List<string>()
        {
            "l", "l", "m", "m", ",", ",", "k", "k",
            "b", "b", "n", "n", "i", "i", "g", "g"
        };
        //
        public Form3()
        {
            Text = "Leida sarnaseid pilte";
            this.Size = new Size(600, 600);
            this.BackColor = Color.FromArgb(0, 153, 153);
            MaximizeBox = false;
            tlp = new TableLayoutPanel
            {
                BackColor = ColorTranslator.FromHtml("#78eaed"),
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Label lb = new Label
                    {
                        BackColor = ColorTranslator.FromHtml("#78eaed"),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings", 48, FontStyle.Bold),
                        Size = new Size(48, 48),
                        Text = "c"
                    };
                    lb.Click += label1_Click;
                    tlp.Controls.Add(lb, i, j);
                }
            }
            time = new Timer();
            time.Interval = 750;
            time.Tick += Tm_Tick;
            Controls.AddRange(new Control[] { tlp, });
            AssignIconsToSquares();
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            time.Stop();
            esimeneClk.ForeColor = esimeneClk.BackColor;
            teineClk.ForeColor = teineClk.BackColor;
            esimeneClk = null;
            teineClk = null;
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tlp.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (time.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (esimeneClk == null)
                {
                    esimeneClk = clickedLabel;
                    esimeneClk.ForeColor = Color.Black;
                    return;
                }

                teineClk = clickedLabel;
                teineClk.ForeColor = Color.Black;

                CheckForWinner();

                if (esimeneClk.Text == teineClk.Text)
                {
                    esimeneClk = null;
                    teineClk = null;
                    return;
                }

                time.Start();
            }
        }
        private void CheckForWinner()
        {
            foreach (Control control in tlp.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("Sa sobitasid kõik ikoonid!", "Palju õnne!");
            Close();
        }
    }
}