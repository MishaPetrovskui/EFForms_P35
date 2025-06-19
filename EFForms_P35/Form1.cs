using EFForms_P35.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EFForms_P35
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
                dataGridView2.DataSource = notes;
            }
        }

        private void UpdateOrdersGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.Orders.Include(s => s.Сlients).ToList();
                dataGridView3.DataSource = notes;
            }
        }

        private void UpdateOrderDetailsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.OrderDetails.Include(s => s.Orders).Include(s => s.Goods).ToList();
                dataGridView5.DataSource = notes;
            }
        }

        private void UpdatePaymentGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.Payment.Include(s => s.Orders).ToList();
                dataGridView4.DataSource = notes;
            }
        }

        private void LoadFilterCategories()
        {
            using (var context = new UniversityContext())
            {
                var categories = context.Goods.Select(g => g.Category).ToList();
                comboBox2.Items.Clear();
                comboBox2.Items.Add("");
                comboBox2.Items.AddRange(categories.ToArray());
            }
        }

        private void HideAllControls()
        {
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label12.Visible = false;

            textBox1.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;

            dateTimePicker1.Visible = false;

            comboBox2.Visible = false;
            comboBox1.Visible = false;

            button2.Visible = false;
            button3.Visible = false;
        }

        private void SetupGoodsUI()
        {
            HideAllControls();
            label6.Text = "Пошук за назвою"; label6.Visible = true;
            label7.Text = "Категорія"; label7.Visible = true;
            label8.Text = "Макс. ціна"; label8.Visible = true;
            label9.Text = "Мін. ціна"; label9.Visible = true;
            label10.Text = "Сортувати за"; label10.Visible = true;
            

            textBox1.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;

            LoadFilterCategories();
            comboBox2.Visible = true;
            comboBox1.Visible = true;

            button2.Visible = true;
            button3.Visible = true;
        }

        private void SetupClientsUI()
        {
            HideAllControls();
            label10.Text = "Сортувати за"; label10.Visible = true;
            label6.Text = "Пошук за назвою"; label6.Visible = true;

            textBox1.Visible = true;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("");
            comboBox1.Items.AddRange(new string[] { "Ім'я" });
            comboBox1.Visible = true;

            button2.Visible = true;
            button3.Visible = true;
        }

        private void SetupOrdersUI()
        {
            HideAllControls();
            label6.Text = "Пошук за статусом"; label6.Visible = true;
            label12.Text = "Дата реєстрації"; label12.Visible = true;
            label10.Text = "Сортувати за"; label10.Visible = true;

            textBox1.Visible = true;

            dateTimePicker1.Visible = true;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("");
            comboBox1.Items.AddRange(new string[] { "Дата", "Ім'я клієнта", "Статус" });
            comboBox1.Visible = true;

            button2.Visible = true;
            button3.Visible = true;
        }

        private void SetupOrderDetailsUI()
        {
            HideAllControls();
            label8.Text = "Макс. ціна"; label8.Visible = true;
            label9.Text = "Мін. ціна"; label9.Visible = true;
            label10.Text = "Сортувати за"; label10.Visible = true;

            textBox3.Visible = true;
            textBox4.Visible = true;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("");
            comboBox1.Items.AddRange(new string[] { "Товар", "Зростання ціни", "Спадання ціни" });
            comboBox1.Visible = true;

            button2.Visible = true;
            button3.Visible = true;
        }

        private void SetupPaymentUI()
        {
            HideAllControls();
            label8.Text = "Макс. ціна"; label8.Visible = true;
            label9.Text = "Мін. ціна"; label9.Visible = true;
            label10.Text = "Сортувати за"; label10.Visible = true;
            label12.Text = "Дата оплати"; label12.Visible = true;

            textBox3.Visible = true;
            textBox4.Visible = true;

            dateTimePicker1.Visible = true;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("");
            comboBox1.Items.AddRange(new string[] { "Дата", "Зростання ціни", "Спадання ціни" });
            comboBox1.Visible = true;

            button2.Visible = true;
            button3.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGoodsGrid();
            UpdateOrdersGrid();
            UpdatePaymentGrid();
            UpdateOrderDetailsGrid();
            UpdateСlientsGrid();
            LoadFilterCategories();
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            HideAllControls();
            /*using (var context = new UniversityContext())
            {
                // Додаємо клієнтів
                var client1 = new Сlients { Name = "Ivan", Surname = "Ivanov", ContactNumber = "+380991112233" };
                var client2 = new Сlients { Name = "Anna", Surname = "Petrova", ContactNumber = "+380503334455" };

                // Додаємо товари
                var good1 = new Goods { Name = "Laptop", Price = 25000, Category = "Electronics", QuantityInStock = 10 };
                var good2 = new Goods { Name = "Phone", Price = 12000, Category = "Electronics", QuantityInStock = 15 };

                // Додаємо замовлення
                var order1 = new Orders { Сlients = client1, DateOfRegistration = DateTime.Now, Status = "New" };
                var order2 = new Orders { Сlients = client2, DateOfRegistration = DateTime.Now, Status = "Paid" };

                // Деталі замовлення
                var orderDetail1 = new OrderDetails { Orders = order1, Goods = good1, TotalAmount = good1.Price };
                var orderDetail2 = new OrderDetails { Orders = order2, Goods = good2, TotalAmount = good2.Price };

                // Оплати
                var payment1 = new Payment { Orders = order2, Sum = good2.Price, PaymentMethod = "Credit Card", DateOfPayment = DateTime.Now };

                // Додаємо у базу
                context.Сlients.AddRange(client1, client2);
                context.Goods.AddRange(good1, good2);
                context.Orders.AddRange(order1, order2);
                context.OrderDetails.AddRange(orderDetail1, orderDetail2);
                context.Payment.Add(payment1);

                // Зберігаємо
                context.SaveChanges();

                Console.WriteLine("Базу даних успішно заповнено!");
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            UpdateGoodsGrid();
            UpdateOrdersGrid();
            UpdatePaymentGrid();
            UpdateOrderDetailsGrid();
            UpdateСlientsGrid();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    using (var context = new UniversityContext())
                    {
                        var goodsList = context.Goods.ToList();

                        string search = textBox1.Text.Trim();
                        if (!string.IsNullOrWhiteSpace(search))
                        {
                            goodsList = goodsList.Where(g => g.Name.Contains(search)).ToList();
                        }

                        string selectedCategory = comboBox2.SelectedItem?.ToString();
                        if (!string.IsNullOrWhiteSpace(selectedCategory))
                        {
                            goodsList = goodsList.Where(g => g.Category == selectedCategory).ToList();
                        }

                        if (double.TryParse(textBox4.Text, out double minPrice))
                        {
                            goodsList = goodsList.Where(g => g.Price >= minPrice).ToList();
                        }

                        if (double.TryParse(textBox3.Text, out double maxPrice))
                        {
                            goodsList = goodsList.Where(g => g.Price <= maxPrice).ToList();
                        }

                        switch (comboBox1.SelectedItem?.ToString())
                        {
                            case "Назва":
                                goodsList = goodsList.OrderBy(g => g.Name).ToList();
                                break;
                            case "Зростання ціни":
                                goodsList = goodsList.OrderBy(g => g.Price).ToList();
                                break;
                            case "Спадання ціни":
                                goodsList = goodsList.OrderByDescending(g => g.Price).ToList();
                                break;
                            case "Кількість":
                                goodsList = goodsList.OrderByDescending(g => g.QuantityInStock).ToList();
                                break;
                        }

                        dataGridView1.DataSource = goodsList;
                    }
                    break;

                case 1:
                    using (var context = new UniversityContext())
                    {
                        var clientList = context.Сlients.ToList();

                        string search = textBox1.Text.Trim();
                        if (!string.IsNullOrWhiteSpace(search))
                        {
                            clientList = clientList.Where(c => c.Name.Contains(search)).ToList();
                        }

                        switch (comboBox1.SelectedItem?.ToString())
                        {
                            case "Ім'я":
                                clientList = clientList.OrderBy(c => c.Name).ToList();
                                break;
                        }

                        dataGridView2.DataSource = clientList;
                    }
                    break;
                case 2:
                    using (var context = new UniversityContext())
                    {
                        var orders = context.Orders.Include(o => o.Сlients).ToList();

                        string search = textBox1.Text.Trim();
                        if (!string.IsNullOrWhiteSpace(search))
                        {
                            orders = orders.Where(o => o.Status.Contains(search)).ToList();
                        }

                        if (dateTimePicker1.Visible)
                        {
                            var selectedDate = dateTimePicker1.Value.Date;
                            orders = orders.Where(o => o.DateOfRegistration.Date == selectedDate).ToList();
                        }

                        switch (comboBox1.SelectedItem?.ToString())
                        {
                            case "Дата":
                                orders = orders.OrderBy(o => o.DateOfRegistration).ToList();
                                break;
                            case "Ім'я клієнта":
                                orders = orders.OrderBy(o => o.Сlients.Name).ToList();
                                break;
                            case "Статус":
                                orders = orders.OrderBy(o => o.Status).ToList();
                                break;
                        }

                        dataGridView3.DataSource = orders;
                    }
                    break;
                case 3:
                    using (var context = new UniversityContext())
                    {
                        var details = context.OrderDetails.Include(d => d.Goods).Include(d => d.Orders).ToList();

                        if (!string.IsNullOrWhiteSpace(textBox4.Text))
                            if (double.TryParse(textBox4.Text, out double minPrice))
                                details = details.Where(g => g.TotalAmount >= minPrice).ToList();

                        if (!string.IsNullOrWhiteSpace(textBox3.Text))
                            if (double.TryParse(textBox3.Text, out double maxPrice))
                                details = details.Where(g => g.TotalAmount <= maxPrice).ToList();

                        switch (comboBox1.SelectedItem?.ToString())
                        {
                            case "Зростання ціни":
                                details = details.OrderBy(d => d.TotalAmount).ToList();
                                break;
                            case "Спадання ціни":
                                details = details.OrderByDescending(d => d.TotalAmount).ToList();
                                break;
                            case "Товар":
                                details = details.OrderBy(d => d.Goods.Name).ToList();
                                break;
                        }

                        dataGridView5.DataSource = details;
                    }
                    break;
                case 4:
                    using (var context = new UniversityContext())
                    {
                        var payments = context.Payment.Include(p => p.Orders).ToList();

                        if (!string.IsNullOrWhiteSpace(textBox4.Text))
                            if (double.TryParse(textBox4.Text, out double minPrice))
                                payments = payments.Where(g => g.Sum >= minPrice).ToList();

                        if (!string.IsNullOrWhiteSpace(textBox3.Text))
                            if (double.TryParse(textBox3.Text, out double maxPrice))
                                payments = payments.Where(g => g.Sum <= maxPrice).ToList();

                        if (dateTimePicker1.Visible)
                        {
                            var selectedDate = dateTimePicker1.Value.Date;
                            payments = payments.Where(o => o.DateOfPayment.Date == selectedDate).ToList();
                        }

                        switch (comboBox1.SelectedItem?.ToString())
                        {
                            case "Зростання ціни":
                                payments = payments.OrderBy(d => d.Sum).ToList();
                                break;
                            case "Спадання ціни":
                                payments = payments.OrderByDescending(d => d.Sum).ToList();
                                break;
                            case "Дата":
                                payments = payments.OrderBy(p => p.DateOfPayment).ToList();
                                break;
                        }

                        dataGridView4.DataSource = payments;
                    }
                    break;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox2.SelectedIndex = -1;
            textBox4.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;

            UpdateGoodsGrid();
            UpdateOrdersGrid();
            UpdatePaymentGrid();
            UpdateOrderDetailsGrid();
            UpdateСlientsGrid();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox2.SelectedIndex = -1;
            textBox4.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            switch (comboBox3.SelectedIndex)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}