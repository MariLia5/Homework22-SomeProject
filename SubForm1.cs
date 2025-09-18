using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SomeProject
{
    public partial class SubForm1 : Form
    {
        public SubForm1()
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProdName.Text))
            {
                MessageBox.Show("Введите название продукта!");
                return false;
            }

            Regex integerRegex = new Regex(@"^\d+$");
            if (!integerRegex.IsMatch(txtProts.Text) ||
                !integerRegex.IsMatch(txtFats.Text) ||
                !integerRegex.IsMatch(txtCarbs.Text) ||
                !integerRegex.IsMatch(txtCalories.Text))
            {
                MessageBox.Show("Белки, жиры, углеводы и калории должны быть целыми числами!");
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                string name = txtProdName.Text;
                int prot = int.Parse(txtProts.Text);
                int fats = int.Parse(txtFats.Text);
                int carbs = int.Parse(txtCarbs.Text);
                int calories = int.Parse(txtCalories.Text);

                Product newProduct = new Product(name, prot, fats, carbs, calories);
                DBWorker.AddProduct(newProduct, Form1.filename);

                MessageBox.Show("Продукт успешно добавлен!");

                // Очистка полей
                txtProdName.Text = "";
                txtProts.Text = "";
                txtFats.Text = "";
                txtCarbs.Text = "";
                txtCalories.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
