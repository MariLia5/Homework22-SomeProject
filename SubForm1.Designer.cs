namespace SomeProject
{
    partial class SubForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtProdName = new TextBox();
            txtProts = new TextBox();
            txtFats = new TextBox();
            txtCarbs = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtCalories = new TextBox();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtProdName
            // 
            txtProdName.Font = new Font("Segoe UI", 16F);
            txtProdName.Location = new Point(231, 87);
            txtProdName.Name = "txtProdName";
            txtProdName.Size = new Size(182, 36);
            txtProdName.TabIndex = 0;
            // 
            // txtProts
            // 
            txtProts.Font = new Font("Segoe UI", 16F);
            txtProts.Location = new Point(231, 144);
            txtProts.Name = "txtProts";
            txtProts.Size = new Size(182, 36);
            txtProts.TabIndex = 1;
            // 
            // txtFats
            // 
            txtFats.Font = new Font("Segoe UI", 16F);
            txtFats.Location = new Point(231, 207);
            txtFats.Name = "txtFats";
            txtFats.Size = new Size(182, 36);
            txtFats.TabIndex = 2;
            // 
            // txtCarbs
            // 
            txtCarbs.Font = new Font("Segoe UI", 16F);
            txtCarbs.Location = new Point(231, 267);
            txtCarbs.Name = "txtCarbs";
            txtCarbs.Size = new Size(182, 36);
            txtCarbs.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(33, 89);
            label1.Name = "label1";
            label1.Size = new Size(166, 30);
            label1.TabIndex = 4;
            label1.Text = "Имя продукта";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.Location = new Point(33, 150);
            label2.Name = "label2";
            label2.Size = new Size(78, 30);
            label2.TabIndex = 5;
            label2.Text = "Белки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.Location = new Point(33, 210);
            label3.Name = "label3";
            label3.Size = new Size(81, 30);
            label3.TabIndex = 6;
            label3.Text = "Жиры";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.Location = new Point(33, 270);
            label4.Name = "label4";
            label4.Size = new Size(117, 30);
            label4.TabIndex = 7;
            label4.Text = "Углеводы";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label5.Location = new Point(33, 331);
            label5.Name = "label5";
            label5.Size = new Size(107, 30);
            label5.TabIndex = 9;
            label5.Text = "Калории";
            // 
            // txtCalories
            // 
            txtCalories.Font = new Font("Segoe UI", 16F);
            txtCalories.Location = new Point(231, 328);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(182, 36);
            txtCalories.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(516, 77);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(482, 287);
            dataGridView1.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label6.Location = new Point(516, 23);
            label6.Name = "label6";
            label6.Size = new Size(210, 30);
            label6.TabIndex = 11;
            label6.Text = "Список продуктов";
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnAdd.Location = new Point(23, 405);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(158, 61);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // SubForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1065, 505);
            Controls.Add(btnAdd);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            Controls.Add(label5);
            Controls.Add(txtCalories);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCarbs);
            Controls.Add(txtFats);
            Controls.Add(txtProts);
            Controls.Add(txtProdName);
            Name = "SubForm1";
            Text = "SubForm1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProdName;
        private TextBox txtProts;
        private TextBox txtFats;
        private TextBox txtCarbs;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtCalories;
        private DataGridView dataGridView1;
        private Label label6;
        private Button btnAdd;
    }
}