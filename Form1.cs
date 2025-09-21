using System;
using System.Windows.Forms;

namespace SomeProject
{
    public partial class Form1 : Form
    {
        private SubForm1 subform1;
        public static string filename = "DietApp.db";

        public Form1()
        {
            InitializeComponent();
            try
            {
                DBWorker.InitDBSQLite(filename);
                ShowSubForm1();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации базы данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowSubForm1()
        {
            if (subform1 != null && !subform1.IsDisposed)
            {
                if (!subform1.Visible)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowSubForm1();
        }
    }
}