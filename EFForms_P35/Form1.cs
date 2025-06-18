using EFForms_P35.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGoodsGrid();
            UpdateOrdersGrid();
            UpdatePaymentGrid();
            UpdateOrderDetailsGrid();
            UpdateСlientsGrid();
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
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}