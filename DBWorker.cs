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

        // READ - Получение всех продуктов
        public static List<Product> GetAllProducts(string filename)
        {
            var products = new List<Product>();
            string connString = $"Data Source={GetDbPath(filename)};";
            string query = "SELECT * FROM Product ORDER BY ProductName;";

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

        // READ - Получение продукта по ID
        public static Product GetProductById(int id, string filename)
        {
            string connString = $"Data Source={GetDbPath(filename)};";
            string query = "SELECT * FROM Product WHERE id = @id;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Product(
                                    id: Convert.ToInt32(reader["id"]),
                                    name: reader["ProductName"].ToString(),
                                    prot: Convert.ToInt32(reader["Proteins"]),
                                    fats: Convert.ToInt32(reader["Fats"]),
                                    carbs: Convert.ToInt32(reader["Carbs"]),
                                    calories: Convert.ToInt32(reader["Calories"])
                                );
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка загрузки продукта: {ex.Message}");
            }
        }
        public static void UpdateProduct(Product product, string filename)
        {
            string connString = $"Data Source={GetDbPath(filename)};";
            string query = "UPDATE Product SET ProductName = @name, Proteins = @prot, " +
                           "Fats = @fats, Carbs = @carbs, Calories = @calories WHERE id = @id;";

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
                        cmd.Parameters.AddWithValue("@id", product.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка обновления продукта: {ex.Message}");
            }
        }

        public static void DeleteProduct(int id, string filename)
        {
            string connString = $"Data Source={GetDbPath(filename)};";
            string query = "DELETE FROM Product WHERE id = @id;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка удаления продукта: {ex.Message}");
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
                    Calories INT NOT NULL);";
        }
    }
}