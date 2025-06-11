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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            UpdateNotesGrid();
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
            if (textBox2.Text == string.Empty || textBox1.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Не всі поля заповненні", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var context = new NotesContext())
            {
                context.Database.EnsureCreated();
                context.Notes.Add(new Note { Name = textBox1.Text, Description = textBox2.Text, Status = comboBox1.Text });
                context.SaveChanges();
            }
            UpdateNotesGrid();
            textBox1.Clear();
            textBox2.Clear();
            if (comboBox1.SelectedIndex == -1)
                return;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // MessageBox.Show($"dataGridView1.CurrentCell = {dataGridView1.CurrentCell}\ndataGrinView1_CellContentClic");
            Note? note = dataGridView1.CurrentRow.DataBoundItem as Note;
            if (note == null) return;
            textBox1.Text = note.Name;
            textBox2.Text = note.Description;
            textBox3.Text = Convert.ToString(note.Id);
            comboBox1.Text = note.Status;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty || textBox1.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Не всі поля заповненні", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var context = new NotesContext())
            {
                context.Database.EnsureCreated();
                Note note = context.Notes.Find(Convert.ToInt32(textBox3.Text));
                if (note == null) return;
                note.Name = textBox1.Text;
                note.Description = textBox2.Text;
                note.Status = comboBox1.Text;
                context.SaveChanges();
            }
            UpdateNotesGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty || textBox1.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("Не всі поля заповненні", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var context = new NotesContext())
            {
                context.Database.EnsureCreated();
                var note = Convert.ToInt32(textBox3.Text);
                if (note == null) return;
                var a = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.OKCancel);
                if (a == DialogResult.Cancel) return;
                context.Notes.Remove(context.Notes.Find(note));
                context.SaveChanges();
            }
            UpdateNotesGrid();
        }
    }
}