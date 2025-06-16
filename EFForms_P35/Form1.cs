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

        private void UpdateStudentsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                Group? group = dataGridView1.CurrentRow.DataBoundItem as Group;
                if (group == null) group = new Group { Id = 0 };
                var notes = context.Students.Include(s => s.Group).Where(s => s.Group.Id == group.Id).ToList();
                dataGridView2.DataSource = notes;
            }
        }

        private void UpdateGroupsGrid()
        {
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                var notes = context.Groups.ToList();
                dataGridView1.DataSource = notes;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateGroupsGrid();
            UpdateStudentsGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateStudentsGrid();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.startGroup = dataGridView1.CurrentRow.DataBoundItem as Group;
            form2.ShowDialog();
            UpdateStudentsGrid();
        }
    }
}