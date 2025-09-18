namespace SomeProject
{
    partial class SubForm2
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
            dataGridView1 = new DataGridView();
            txtName = new TextBox();
            txtProt = new TextBox();
            txtFats = new TextBox();
            txtCarbs = new TextBox();
            txtCals = new TextBox();
            btnRefresh = new Button();
            Delete = new Button();
            lblTotalProteins = new Label();
            lblTotalCarbs = new Label();
            lblTotalCalories = new Label();
            listBoxProducts = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(584, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(340, 338);
            dataGridView1.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(214, 34);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // txtProt
            // 
            txtProt.Location = new Point(214, 91);
            txtProt.Name = "txtProt";
            txtProt.Size = new Size(100, 23);
            txtProt.TabIndex = 2;
            // 
            // txtFats
            // 
            txtFats.Location = new Point(214, 148);
            txtFats.Name = "txtFats";
            txtFats.Size = new Size(100, 23);
            txtFats.TabIndex = 3;
            // 
            // txtCarbs
            // 
            txtCarbs.Location = new Point(214, 194);
            txtCarbs.Name = "txtCarbs";
            txtCarbs.Size = new Size(100, 23);
            txtCarbs.TabIndex = 4;
            // 
            // txtCals
            // 
            txtCals.Location = new Point(214, 257);
            txtCals.Name = "txtCals";
            txtCals.Size = new Size(100, 23);
            txtCals.TabIndex = 5;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(21, 352);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            Delete.Location = new Point(133, 352);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 7;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            // 
            // lblTotalProteins
            // 
            lblTotalProteins.AutoSize = true;
            lblTotalProteins.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalProteins.Location = new Point(21, 27);
            lblTotalProteins.Name = "lblTotalProteins";
            lblTotalProteins.Size = new Size(160, 30);
            lblTotalProteins.TabIndex = 8;
            lblTotalProteins.Text = "Всего белков:";
            // 
            // lblTotalCarbs
            // 
            lblTotalCarbs.AutoSize = true;
            lblTotalCarbs.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalCarbs.Location = new Point(21, 91);
            lblTotalCarbs.Name = "lblTotalCarbs";
            lblTotalCarbs.Size = new Size(157, 30);
            lblTotalCarbs.TabIndex = 9;
            lblTotalCarbs.Text = "Всего жиров:";
            // 
            // lblTotalCalories
            // 
            lblTotalCalories.AutoSize = true;
            lblTotalCalories.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalCalories.Location = new Point(21, 148);
            lblTotalCalories.Name = "lblTotalCalories";
            lblTotalCalories.Size = new Size(176, 30);
            lblTotalCalories.TabIndex = 10;
            lblTotalCalories.Text = "Всего калорий:";
            //lblTotalCalories.Click += label1_Click;
            // 
            // listBoxProducts
            // 
            listBoxProducts.FormattingEnabled = true;
            listBoxProducts.ItemHeight = 15;
            listBoxProducts.Location = new Point(348, 27);
            listBoxProducts.Name = "listBoxProducts";
            listBoxProducts.Size = new Size(120, 94);
            listBoxProducts.TabIndex = 11;
            // 
            // SubForm2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LawnGreen;
            ClientSize = new Size(1054, 547);
            Controls.Add(listBoxProducts);
            Controls.Add(lblTotalCalories);
            Controls.Add(lblTotalCarbs);
            Controls.Add(lblTotalProteins);
            Controls.Add(Delete);
            Controls.Add(btnRefresh);
            Controls.Add(txtCals);
            Controls.Add(txtCarbs);
            Controls.Add(txtFats);
            Controls.Add(txtProt);
            Controls.Add(txtName);
            Controls.Add(dataGridView1);
            Name = "SubForm2";
            Text = "SubForm2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtName;
        private TextBox txtProt;
        private TextBox txtFats;
        private TextBox txtCarbs;
        private TextBox txtCals;
        private Button btnRefresh;
        private Button Delete;
        private Label lblTotalProteins;
        private Label lblTotalCarbs;
        private Label lblTotalCalories;
        private ListBox listBoxProducts;
    }
}