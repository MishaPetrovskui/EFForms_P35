using EFForms_P35.Models;
using Microsoft.EntityFrameworkCore;

namespace EFForms_P35
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateNotesGrid()
        {
            using (var context = new NotesContext())
            {
                context.Database.EnsureCreated();
                var notes = context.Notes.ToList();
                dataGridView1.DataSource = notes;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateNotesGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty || textBox1.Text == string.Empty)
            {
                MessageBox.Show("Не всі поля заповненні", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var context = new NotesContext())
            {
                context.Database.EnsureCreated();
                context.Notes.Add(new Note { Name= textBox1.Text, Description = textBox2.Text });
                context.SaveChanges();
            }
            UpdateNotesGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
        }
    }
}