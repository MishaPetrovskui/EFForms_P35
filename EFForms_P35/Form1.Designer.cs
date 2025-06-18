namespace EFForms_P35
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            dataGridView4 = new DataGridView();
            dataGridView5 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(222, 199);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 239);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Add Student";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.Location = new Point(240, 12);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(222, 199);
            dataGridView2.TabIndex = 13;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView3.Location = new Point(468, 12);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(222, 199);
            dataGridView3.TabIndex = 14;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView4.Location = new Point(468, 239);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new Size(222, 199);
            dataGridView4.TabIndex = 15;
            // 
            // dataGridView5
            // 
            dataGridView5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView5.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView5.Location = new Point(240, 239);
            dataGridView5.Name = "dataGridView5";
            dataGridView5.Size = new Size(222, 199);
            dataGridView5.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, -1);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 17;
            label1.Text = "Товари";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(331, -1);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 18;
            label2.Text = "Клієнти";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(548, -1);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 19;
            label3.Text = "Замовлення";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(298, 218);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 20;
            label4.Text = "Деталі замовлень";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(548, 218);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 21;
            label5.Text = "Оплати";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dataGridView5);
            Controls.Add(dataGridView4);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DataGridView dataGridView4;
        private DataGridView dataGridView5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}