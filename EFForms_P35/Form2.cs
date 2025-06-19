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

        private async void LoadClientsForDropdown()
        {
            using (var context = new UniversityContext())
            {
                try
                {
                    var clients = context.Сlients.ToList();
                    comboBox2.DataSource = clients;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading clients: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void LoadGoodsForDropdown()
        {
            using (var context = new UniversityContext())
            {
                try
                {
                    var goods = context.Goods.ToList();
                    comboBox3.DataSource = goods;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading goods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void LoadOrdersForDropdown()
        {
            using (var context = new UniversityContext())
            {
                try
                {
                    var orders = context.Orders.Include(o => o.Сlients).ToList();
                    var dropdownSource = comboBox2.Visible ? comboBox2 : comboBox3;
                    dropdownSource.DataSource = orders;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void HideAllControls()
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            dateTimePicker1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
        }

        private void SetupGoodsUI()
        {
            HideAllControls();
            label2.Text = "Назва"; label2.Visible = true;
            label3.Text = "Ціна"; label3.Visible = true;
            label4.Text = "Категорія"; label4.Visible = true;
            label5.Text = "Кількість у складі"; label5.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
        }

        private void SetupClientsUI()
        {
            HideAllControls();
            label2.Text = "Ім'я"; label2.Visible = true;
            label3.Text = "Прізвище"; label3.Visible = true;
            label4.Text = "Номер телефону"; label4.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
        }

        private void SetupOrdersUI()
        {
            HideAllControls();

            label10.Text = "Клієнт"; label10.Visible = true;
            label9.Text = "Дата реєстрації"; label9.Visible = true;
            label2.Text = "Статус"; label2.Visible = true;

            comboBox2.Visible = true;
            dateTimePicker1.Visible = true;
            textBox1.Visible = true;

            LoadClientsForDropdown();
        }

        private void SetupOrderDetailsUI()
        {
            HideAllControls();
            
            label7.Text = "Товар"; label7.Visible = true;
            label10.Text = "Замовлення"; label10.Visible = true;
            label2.Text = "Загальна сума"; label2.Visible = true;

            comboBox2.Visible = true;
            comboBox3.Visible = true;
            textBox1.Visible = true;

            LoadGoodsForDropdown();
            LoadOrdersForDropdown();
        }

        private void SetupPaymentUI()
        {
            HideAllControls();
            label10.Text = "Замовлення"; label10.Visible = true;
            label2.Text = "Сума"; label2.Visible = true;
            label3.Text = "Спосіб оплати"; label3.Visible = true;
            label9.Text = "Дата оплати"; label9.Visible = true;

            comboBox2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            dateTimePicker1.Visible = true;

            LoadOrdersForDropdown();
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
                        SetupGoodsUI();
                        UpdateGoodsGrid();
                        break;
                    case 1:
                        SetupClientsUI();
                        UpdateСlientsGrid();
                        break;
                    case 2:
                        SetupOrdersUI();
                        UpdateOrdersGrid();
                        break;
                    case 3:
                        SetupOrderDetailsUI();
                        UpdateOrderDetailsGrid();
                        break;
                    case 4:
                        SetupPaymentUI();
                        UpdatePaymentGrid();
                        break;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0].DataBoundItem;

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        if (selectedRow is Goods goods)
                        {
                            textBox1.Text = goods.Name;
                            textBox2.Text = goods.Price.ToString();
                            textBox3.Text = goods.Category;
                            textBox4.Text = goods.QuantityInStock.ToString();
                        }
                        break;

                    case 1:
                        if (selectedRow is Сlients client)
                        {
                            textBox1.Text = client.Name;
                            textBox2.Text = client.Surname;
                            textBox3.Text = client.ContactNumber;
                        }
                        break;

                    case 2:
                        if (selectedRow is Orders order)
                        {
                            comboBox2.SelectedValue = order.Сlients.Id;
                            dateTimePicker1.Value = order.DateOfRegistration;
                            textBox1.Text = order.Status;
                        }
                        break;

                    case 3:
                        if (selectedRow is OrderDetails detail)
                        {
                            comboBox3.SelectedValue = detail.Goods.Id;
                            comboBox2.SelectedValue = detail.Orders.Id;
                            textBox1.Text = detail.TotalAmount.ToString();
                        }
                        break;

                    case 4:
                        if (selectedRow is Payment payment)
                        {
                            comboBox2.SelectedValue = payment.Orders.Id;
                            textBox1.Text = payment.Sum.ToString();
                            textBox2.Text = payment.PaymentMethod;
                            dateTimePicker1.Value = payment.DateOfPayment;
                        }
                        break;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        var newGood = new Goods
                        {
                            Name = textBox1.Text,
                            Price = double.Parse(textBox2.Text),
                            Category = textBox3.Text,
                            QuantityInStock = int.Parse(textBox4.Text)
                        };
                        context.Goods.Add(newGood);
                        context.SaveChanges();
                        UpdateGoodsGrid();
                        break;

                    case 1:
                        var newClient = new Сlients
                        {
                            Name = textBox1.Text,
                            Surname = textBox2.Text,
                            ContactNumber = textBox3.Text
                        };
                        context.Сlients.Add(newClient);
                        context.SaveChanges();
                        UpdateСlientsGrid();
                        break;

                    case 2:
                        var clientId = (int)comboBox2.SelectedValue;
                        var client = context.Сlients.Find(clientId);
                        var newOrder = new Orders
                        {
                            Сlients = client,
                            DateOfRegistration = dateTimePicker1.Value,
                            Status = textBox1.Text
                        };
                        context.Orders.Add(newOrder);
                        context.SaveChanges();
                        UpdateOrdersGrid();
                        break;

                    case 3:
                        var goodId = comboBox3.SelectedValue;
                        var orderId = comboBox2.SelectedValue;

                        if (goodId == null || orderId == null)
                        {
                            MessageBox.Show("Оберіть товар та замовлення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var good = context.Goods.Find((int)goodId);
                        var order = context.Orders.Find((int)orderId);

                        if (good == null || order == null)
                        {
                            MessageBox.Show("Обраний товар або замовлення не знайдено в базі.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var detail = new OrderDetails
                        {
                            Goods = good,
                            Orders = order,
                            TotalAmount = double.Parse(textBox1.Text)
                        };

                        context.OrderDetails.Add(detail);
                        context.SaveChanges();
                        UpdateOrderDetailsGrid();
                        break;


                    case 4:
                        var pOrder = context.Orders.Find((int)comboBox2.SelectedValue);
                        var payment = new Payment
                        {
                            Orders = pOrder,
                            Sum = double.Parse(textBox1.Text),
                            PaymentMethod = textBox2.Text,
                            DateOfPayment = dateTimePicker1.Value
                        };
                        context.Payment.Add(payment);
                        context.SaveChanges();
                        UpdatePaymentGrid();
                        break;
                }
            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            using (var context = new UniversityContext())
            {
                var selectedRow = dataGridView1.SelectedRows[0].DataBoundItem;

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        if (selectedRow is Goods goods)
                        {
                            var item = context.Goods.Find(goods.Id);
                            if (item != null)
                            {
                                item.Name = textBox1.Text;
                                item.Price = double.Parse(textBox2.Text);
                                item.Category = textBox3.Text;
                                item.QuantityInStock = int.Parse(textBox4.Text);
                                context.SaveChanges();
                                UpdateGoodsGrid();
                            }
                        }
                        break;

                    case 1:
                        if (selectedRow is Сlients client)
                        {
                            var item = context.Сlients.Find(client.Id);
                            if (item != null)
                            {
                                item.Name = textBox1.Text;
                                item.Surname = textBox2.Text;
                                item.ContactNumber = textBox3.Text;
                                context.SaveChanges();
                                UpdateСlientsGrid();
                            }
                        }
                        break;

                    case 2:
                        if (selectedRow is Orders order)
                        {
                            var item = context.Orders.Include(o => o.Сlients).FirstOrDefault(o => o.Id == order.Id);
                            if (item != null)
                            {
                                item.Сlients = context.Сlients.Find((int)comboBox2.SelectedValue);
                                item.DateOfRegistration = dateTimePicker1.Value;
                                item.Status = textBox1.Text;
                                context.SaveChanges();
                                UpdateOrdersGrid();
                            }
                        }
                        break;

                    case 3:
                        if (selectedRow is OrderDetails detail)
                        {
                            var item = context.OrderDetails.Include(d => d.Goods).Include(d => d.Orders).FirstOrDefault(d => d.Id == detail.Id);
                            if (item != null)
                            {
                                item.Goods = context.Goods.Find((int)comboBox2.SelectedValue);
                                item.Orders = context.Orders.Find((int)comboBox3.SelectedValue);
                                item.TotalAmount = double.Parse(textBox1.Text);
                                context.SaveChanges();
                                UpdateOrderDetailsGrid();
                            }
                        }
                        break;

                    case 4:
                        if (selectedRow is Payment payment)
                        {
                            var item = context.Payment.Include(p => p.Orders).FirstOrDefault(p => p.Id == payment.Id);
                            if (item != null)
                            {
                                item.Orders = context.Orders.Find((int)comboBox2.SelectedValue);
                                item.Sum = double.Parse(textBox1.Text);
                                item.PaymentMethod = textBox2.Text;
                                item.DateOfPayment = dateTimePicker1.Value;
                                context.SaveChanges();
                                UpdatePaymentGrid();
                            }
                        }
                        break;
                }
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var confirm = MessageBox.Show("Ви дійсно хочете видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var context = new UniversityContext())
            {
                var selectedRow = dataGridView1.SelectedRows[0].DataBoundItem;

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        if (selectedRow is Goods goods)
                        {
                            var item = context.Goods.Find(goods.Id);
                            context.Goods.Remove(item);
                            context.SaveChanges();
                            UpdateGoodsGrid();
                        }
                        break;

                    case 1:
                        if (selectedRow is Сlients client)
                        {
                            var item = context.Сlients.Find(client.Id);
                            context.Сlients.Remove(item);
                            context.SaveChanges();
                            UpdateСlientsGrid();
                        }
                        break;

                    case 2:
                        if (selectedRow is Orders order)
                        {
                            var item = context.Orders.Find(order.Id);
                            context.Orders.Remove(item);
                            context.SaveChanges();
                            UpdateOrdersGrid();
                        }
                        break;

                    case 3:
                        if (selectedRow is OrderDetails detail)
                        {
                            var item = context.OrderDetails.Find(detail.Id);
                            context.OrderDetails.Remove(item);
                            context.SaveChanges();
                            UpdateOrderDetailsGrid();
                        }
                        break;

                    case 4:
                        if (selectedRow is Payment payment)
                        {
                            var item = context.Payment.Find(payment.Id);
                            context.Payment.Remove(item);
                            context.SaveChanges();
                            UpdatePaymentGrid();
                        }
                        break;
                }
            }
            this.Close();
        }
    }
}
