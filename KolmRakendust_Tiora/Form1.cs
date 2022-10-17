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
    public partial class Form1 : Form
    {
        TableLayoutPanel table;
        PictureBox picture;
        OpenFileDialog openFile = new OpenFileDialog
        {
            Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*",
        };
        ColorDialog colorDialog = new ColorDialog { };
        CheckBox box;
        public Form1()
        {
            this.Size = new Size(600, 500);
            table = new TableLayoutPanel
            {

                Dock = DockStyle.Fill,
                ColumnStyles = { new ColumnStyle(SizeType.Percent, 15), new ColumnStyle(SizeType.Percent, 100) },
                RowStyles = { new RowStyle(SizeType.Percent, 90), new RowStyle(SizeType.Percent,35) }

            };
            picture = new PictureBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D
            };

            box = new CheckBox { Text = "Stretch" };
            box.CheckedChanged += Box_CheckedChanged;


            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();


            Button btn1 = new Button { Text = "Close", AutoSize = true, };
            Button btn2 = new Button { Text = "Set BG", AutoSize = true };
            Button btn3 = new Button { Text = "Clear the picture", AutoSize = true };
            Button btn4 = new Button { Text = "Show a picture", AutoSize = true };

            flowLayoutPanel.Controls.Add(btn1);
            flowLayoutPanel.Controls.Add(btn2);
            flowLayoutPanel.Controls.Add(btn3);
            flowLayoutPanel.Controls.Add(btn4);
            flowLayoutPanel.Controls.Add(box);
            

            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn4.Click += Btn4_Click;

            table.Controls.Add(picture);
            table.SetColumnSpan(picture, 2);
            table.Controls.Add(flowLayoutPanel);
            table.SetCellPosition(flowLayoutPanel, new TableLayoutPanelCellPosition(1, 2));
            this.Controls.Add(table);
            


        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picture.Load(openFile.FileName);
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            picture.Image = null;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                picture.BackColor = colorDialog.Color;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Start st = new Start();
            st.Show();
            this.Hide();
        }

        private void Box_CheckedChanged(object sender, EventArgs e)
        {
            if (box.Checked)
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                picture.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}
