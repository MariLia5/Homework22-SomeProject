using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomeProject
{
    public partial class SubForm2 : Form
    {
        public SubForm2()
        {
            InitializeComponent();
            LoadDailyStatistics();
        }

        private void LoadDailyStatistics()
        {
            try
            {
                // Получаем статистику
                var stats = DBWorker.GetDailyStatistics(Form1.filename);

                // Получаем список продуктов
                var products = DBWorker.GetDailyProducts(Form1.filename);

                // Отображаем статистику
                lblTotalProteins.Text = stats["Proteins"].ToString();
                //lblTotalFats.Text = stats["Fats"].ToString();
                lblTotalCarbs.Text = stats["Carbs"].ToString();
                lblTotalCalories.Text = stats["Calories"].ToString();

                // Отображаем список продуктов
                listBoxProducts.Items.Clear();
                foreach (var product in products)
                {
                    listBoxProducts.Items.Add(
                        $"{product.ProductName} - Б: {product.Proteins} Ж: {product.Fats} У: {product.Carbs} К: {product.Calories}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статистики: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDailyStatistics();
        }
    }
}