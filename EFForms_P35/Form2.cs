using EFForms_P35.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EFForms_P35
{
    public partial class Form2 : Form
    {
        private void UpdateGoodsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.Goods.ToList();
                dataGridView1.DataSource = notes;
            }
        }

        private void UpdateСlientsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.Сlients.ToList();
                dataGridView1.DataSource = notes;
            }
        }

        private void UpdateOrdersGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.Orders.Include(s => s.Сlients).ToList();
                dataGridView1.DataSource = notes;
            }
        }

        private void UpdateOrderDetailsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.OrderDetails.Include(s => s.Orders).Include(s => s.Goods).ToList();
                dataGridView1.DataSource = notes;
            }
        }

        private void UpdatePaymentGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.Payment.Include(s => s.Orders).ToList();
                dataGridView1.DataSource = notes;
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                var con = comboBox1.SelectedIndex;
                switch (con)
                {
                    case 0:
                        UpdateGoodsGrid();
                        label2.Text = "Назва"; label2.Visible = true; label3.Text = "Ціна"; label3.Visible = true; label4.Text = "Категорія"; label4.Visible = true; label5.Text = "Кількість у складі"; label5.Visible = true; label9.Visible = false; label10.Visible = false; label6.Visible = false; label7.Visible = false;
                        dateTimePicker1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false;
                        textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true;
                        break;
                    case 1:
                        UpdateСlientsGrid();
                        textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = false; dateTimePicker1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false;
                        label2.Text = "Імя"; label2.Visible = true; label3.Text = "Прізвище"; label3.Visible = true; label4.Text = "Номер телефону"; label4.Visible = true; label5.Text = "Кількість у складі"; label5.Visible = false; label9.Visible = false; label10.Visible = false; label6.Visible = false; label7.Visible = false;
                        break;
                    case 2:
                        UpdateOrdersGrid();
                        
                        break;
                    case 3:
                        UpdateOrderDetailsGrid();
                        label2.Text = "Статус"; label2.Visible = true; label3.Visible = false; label4.Visible = false; label5.Visible = false; label9.Visible = false; label10.Visible = false; label6.Visible = false; label7.Visible = false;
                        dateTimePicker1.Visible = false; comboBox2.Visible = false; comboBox3.Visible = false; comboBox4.Visible = false;
                        textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true;
                        break;
                    case 4:
                        UpdatePaymentGrid();
                        
                        break;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
