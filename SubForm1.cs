using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SomeProject
{
    public partial class SubForm1 : Form
    {
        private List<Product> productsList;
        private Product selectedProduct;

        public SubForm1()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadProducts();
        }

        private void ConfigureDataGridView()
        {
            // Настраиваем DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            // Добавляем колонки
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ProductName",
                DataPropertyName = "ProductName",
                HeaderText = "Название продукта",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Proteins",
                DataPropertyName = "Proteins",
                HeaderText = "Белки",
                Width = 60
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Fats",
                DataPropertyName = "Fats",
                HeaderText = "Жиры",
                Width = 60
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Carbs",
                DataPropertyName = "Carbs",
                HeaderText = "Углеводы",
                Width = 70
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Calories",
                DataPropertyName = "Calories",
                HeaderText = "Калории",
                Width = 70
            });
        }

        private void LoadProducts()
        {
            try
            {
                productsList = DBWorker.GetAllProducts(Form1.filename);
                dataGridView1.DataSource = productsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProdName.Text))
            {
                MessageBox.Show("Введите название продукта!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtProdName.Text.Length > 30)
            {
                MessageBox.Show("Название продукта не должно превышать 30 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Regex integerRegex = new Regex(@"^\d+$");
            string[] numericFields = { txtProts.Text, txtFats.Text, txtCarbs.Text, txtCalories.Text };
            string[] fieldNames = { "Белки", "Жиры", "Углеводы", "Калории" };

            for (int i = 0; i < numericFields.Length; i++)
            {
                if (!integerRegex.IsMatch(numericFields[i]))
                {
                    MessageBox.Show($"{fieldNames[i]} должны быть целым положительным числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void ClearFields()
        {
            txtProdName.Text = "";
            txtProts.Text = "";
            txtFats.Text = "";
            txtCarbs.Text = "";
            txtCalories.Text = "";
            selectedProduct = null;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                Product newProduct = new Product(
                    txtProdName.Text,
                    int.Parse(txtProts.Text),
                    int.Parse(txtFats.Text),
                    int.Parse(txtCarbs.Text),
                    int.Parse(txtCalories.Text)
                );

                DBWorker.AddProduct(newProduct, Form1.filename);
                MessageBox.Show("Продукт успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                selectedProduct = productsList.Find(p => p.Id == selectedId);

                if (selectedProduct != null)
                {
                    txtProdName.Text = selectedProduct.ProductName;
                    txtProts.Text = selectedProduct.Proteins.ToString();
                    txtFats.Text = selectedProduct.Fats.ToString();
                    txtCarbs.Text = selectedProduct.Carbs.ToString();
                    txtCalories.Text = selectedProduct.Calories.ToString();

                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите продукт для обновления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                selectedProduct.ProductName = txtProdName.Text;
                selectedProduct.Proteins = int.Parse(txtProts.Text);
                selectedProduct.Fats = int.Parse(txtFats.Text);
                selectedProduct.Carbs = int.Parse(txtCarbs.Text);
                selectedProduct.Calories = int.Parse(txtCalories.Text);

                DBWorker.UpdateProduct(selectedProduct, Form1.filename);
                MessageBox.Show("Продукт успешно обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите продукт для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Удалить продукт '{selectedProduct.ProductName}'?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DBWorker.DeleteProduct(selectedProduct.Id, Form1.filename);
                    MessageBox.Show("Продукт успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearFields();
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}