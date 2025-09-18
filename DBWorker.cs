using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SomeProject
{
    internal class DBWorker
    {
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void InitDBSQLite(string filename)
        {
            string connString = $"Data Source={GetDbPath(filename)};";
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = GetInitDBScript();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка инициализации базы данных: {ex.Message}");
            }
        }

        // CREATE - Добавление продукта
        public static void AddProduct(Product product, string filename)
        {
            string connString = $"Data Source={GetDbPath(filename)};";
            string query = "INSERT INTO Product (ProductName, Proteins, Fats, Carbs, Calories) " +
                           "VALUES (@name, @prot, @fats, @carbs, @calories);";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", product.ProductName);
                        cmd.Parameters.AddWithValue("@prot", product.Proteins);
                        cmd.Parameters.AddWithValue("@fats", product.Fats);
                        cmd.Parameters.AddWithValue("@carbs", product.Carbs);
                        cmd.Parameters.AddWithValue("@calories", product.Calories);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка добавления продукта: {ex.Message}");
            }
        }

        // READ - Получение всех продуктов за день
        public static List<Product> GetDailyProducts(string filename)
        {
            var products = new List<Product>();
            string connString = $"Data Source={GetDbPath(filename)};";

            // Берем продукты только за сегодня
            string query = "SELECT * FROM Product WHERE date(CreatedDate) = date('now');";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product(
                                id: Convert.ToInt32(reader["id"]),
                                name: reader["ProductName"].ToString(),
                                prot: Convert.ToInt32(reader["Proteins"]),
                                fats: Convert.ToInt32(reader["Fats"]),
                                carbs: Convert.ToInt32(reader["Carbs"]),
                                calories: Convert.ToInt32(reader["Calories"])
                            ));
                        }
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки продуктов: {ex.Message}");
            }
        }

        // Получение статистики за день
        public static Dictionary<string, int> GetDailyStatistics(string filename)
        {
            var stats = new Dictionary<string, int>();
            string connString = $"Data Source={GetDbPath(filename)};";

            string query = @"SELECT 
                SUM(Proteins) as TotalProteins,
                SUM(Fats) as TotalFats, 
                SUM(Carbs) as TotalCarbs,
                SUM(Calories) as TotalCalories,
                COUNT(*) as ProductCount
                FROM Product WHERE date(CreatedDate) = date('now');";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stats.Add("Proteins", reader["TotalProteins"] != DBNull.Value ? Convert.ToInt32(reader["TotalProteins"]) : 0);
                            stats.Add("Fats", reader["TotalFats"] != DBNull.Value ? Convert.ToInt32(reader["TotalFats"]) : 0);
                            stats.Add("Carbs", reader["TotalCarbs"] != DBNull.Value ? Convert.ToInt32(reader["TotalCarbs"]) : 0);
                            stats.Add("Calories", reader["TotalCalories"] != DBNull.Value ? Convert.ToInt32(reader["TotalCalories"]) : 0);
                            stats.Add("Count", reader["ProductCount"] != DBNull.Value ? Convert.ToInt32(reader["ProductCount"]) : 0);
                        }
                    }
                }
                return stats;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка получения статистики: {ex.Message}");
            }
        }

        private static string GetDbPath(string filename)
        {
            return System.IO.Path.Combine(path, filename);
        }

        private static string GetInitDBScript()
        {
            return @"CREATE TABLE IF NOT EXISTS Product
                    (id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProductName VARCHAR(30) NOT NULL,
                    Proteins INT NOT NULL,
                    Fats INT NOT NULL,
                    Carbs INT NOT NULL,
                    Calories INT NOT NULL,
                    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP);";
        }
    }
}