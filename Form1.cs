using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gragdrop
{
    public partial class Form1 : Form
    {
        private Point p;

        int current_panel; //номер текущей активной панели

        ColorDialog MyDialog = new ColorDialog();

        Panel[] panels;

        public Form1()
        {
            InitializeComponent();
            panels = new Panel[] { panel1, panel2, panel3, panel4 };
            current_panel = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyDialog.ShowDialog();
            foreach (Control c in panels[current_panel].Controls)
                c.BackColor = MyDialog.Color;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in panels[current_panel].Controls)
                c.Enabled = false;
            foreach (Control c in panels[Convert.ToInt32( (sender as RadioButton).Tag)].Controls)
                c.Enabled = true;
            current_panel = Convert.ToInt32((sender as RadioButton).Tag);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            p = e.Location;
            if (e.Button == MouseButtons.Left)
             DoDragDrop(sender, DragDropEffects.All);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Panel pnl = sender as Panel;
            Label src = e.Data.GetData(typeof(Label)) as Label;
            src.Location = pnl.PointToClient(new Point(e.X, e.Y));
            pnl.Controls.Add(src);
        }


    }
}
