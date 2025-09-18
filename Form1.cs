using System;
using System.Windows.Forms;

namespace SomeProject
{
    public partial class Form1 : Form
    {
        private SubForm1 subform1;
        private SubForm2 subform2;
        public static string filename = "DietApp.db";

        public Form1()
        {
            InitializeComponent();
            DBWorker.InitDBSQLite(filename);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (subform1 != null && !subform1.IsDisposed)
            {
                if (subform1.Visible)
                {
                    subform1.Hide();
                }
                else
                {
                    subform1.Show();
                }
            }
            else
            {
                subform1 = new SubForm1();
                subform1.TopLevel = false;
                MainPanel.Controls.Add(subform1);
                subform1.FormBorderStyle = FormBorderStyle.None;
                subform1.Dock = DockStyle.Fill;
                subform1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (subform2 != null && !subform2.IsDisposed)
            {
                if (subform2.Visible)
                {
                    subform2.Hide();
                }
                else
                {
                    subform2.Show();
                }
            }
            else
            {
                subform2 = new SubForm2();
                subform2.TopLevel = false;
                MainPanel.Controls.Add(subform2);
                subform2.FormBorderStyle = FormBorderStyle.None;
                subform2.Dock = DockStyle.Fill;
                subform2.Show();
            }
        }
    }
}