using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFForms_P35.Models;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EFForms_P35
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Query1()
        {
            using (var context = new UniversityContext())
            {
                var result = context.Goods
                    .Where(g => g.Price > 500)
                    .ToList();
                dataGridView1.DataSource = result;
            }
        }

        private void Query2()
        {
            using (var context = new UniversityContext())
            {
                var result = context.Payment
                    .Include(p => p.Orders)
                    .ThenInclude(o => o.Сlients)
                    .GroupBy(p => p.Orders.Сlients)
                    .Select(g => new
                    {
                        Client = g.Key.Name + " " + g.Key.Surname,
                        TotalSum = g.Sum(p => p.Sum)
                    }).ToList();

                dataGridView1.DataSource = result;
            }
        }

        private void Query3()
        {
            using (var context = new UniversityContext())
            {
                var result = context.Goods
                    .Where(g => g.QuantityInStock < 5)
                    .ToList();
                dataGridView1.DataSource = result;
            }
        }

        private void Query4()
        {
            using (var context = new UniversityContext())
            {
                var result = context.OrderDetails
                    .Include(d => d.Goods)
                    .GroupBy(d => d.Goods)
                    .Select(g => new
                    {
                        Product = g.Key.Name,
                        TotalSold = g.Sum(x => x.TotalAmount)
                    })
                    .OrderByDescending(g => g.TotalSold)
                    .Take(1)
                    .ToList();

                dataGridView1.DataSource = result;
            }
        }

        private void Query5()
        {
            using (var context = new UniversityContext())
            {
                var result = context.Orders
                    .Include(o => o.Сlients)
                    .GroupBy(o => o.Сlients)
                    .Where(g => g.Count() >= 3)
                    .Select(g => new
                    {
                        Client = g.Key.Name + " " + g.Key.Surname,
                        OrderCount = g.Count()
                    }).ToList();

                dataGridView1.DataSource = result;
            }
        }

        private void Query6()
        {
            using (var context = new UniversityContext())
            {
                var result = context.OrderDetails
                    .Include(d => d.Orders)
                    .Include(d => d.Goods)
                    .Select(d => new
                    {
                        OrderID = d.Orders.Id,
                        Product = d.Goods.Name,
                        TotalAmount = d.TotalAmount
                    }).ToList();

                dataGridView1.DataSource = result;
            }
        }

        private void Query7()
        {
            using (var context = new UniversityContext())
            {
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                var result = context.Payment
                    .Where(p => p.DateOfPayment >= lastMonth)
                    .Include(p => p.Orders)
                    .ToList();

                dataGridView1.DataSource = result;
            }
        }

        private void Query8()
        {
            using (var context = new UniversityContext())
            {
                var result = context.Payment
                    .GroupBy(p => p.Orders.Id)
                    .Select(g => new
                    {
                        OrderID = g.Key,
                        Average = g.Sum(p => p.Sum) / g.Count()
                    }).ToList();

                dataGridView1.DataSource = result;
            }
        }

        private void Query9()
        {
            using (var context = new UniversityContext())
            {
                var result = context.Сlients
                    .Where(c => !context.Orders.Any(o => o.Сlients.Id == c.Id))
                    .Select(c => new
                    {
                        Name = c.Name + " " + c.Surname,
                        c.ContactNumber
                    }).ToList();

                dataGridView1.DataSource = result;
            }
        }

        private void Query10()
        {
            using (var context = new UniversityContext())
            {
                var result = context.Orders
                    .Where(o => o.Status != "Delivered")
                    .Include(o => o.Сlients)
                    .Select(o => new
                    {
                        OrderID = o.Id,
                        Client = o.Сlients.Name + " " + o.Сlients.Surname,
                        Status = o.Status,
                        Date = o.DateOfRegistration
                    }).ToList();

                dataGridView1.DataSource = result;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: Query1(); break;
                case 1: Query2(); break;
                case 2: Query3(); break;
                case 3: Query4(); break;
                case 4: Query5(); break;
                case 5: Query6(); break;
                case 6: Query7(); break;
                case 7: Query8(); break;
                case 8: Query9(); break;
                case 9: Query10(); break;
                default:
                    MessageBox.Show("Оберіть запит із списку.");
                    break;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.BackColor = Color.Black;
            comboBox1.Items.AddRange(new string[]
            {
                "1. Товари > 500 грн",
                "2. Загальна сума замовлень клієнтів",
                "3. Товари < 5 шт.",
                "4. Найпопулярніший товар",
                "5. Клієнти з ≥3 замовленнями",
                "6. Замовлення + товари",
                "7. Оплати за місяць",
                "8. Середня вартість замовлень",
                "9. Клієнти без замовлень",
                "10. Недоставлені замовлення"
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
