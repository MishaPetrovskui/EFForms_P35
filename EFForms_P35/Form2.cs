using EFForms_P35.Models;
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
        public Group? startGroup { get; set; } = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (var context = new UniversityContext())
            {
                var groups = context.Groups.ToArray();
                if (groups == null) return;
                comboBox1.Items.AddRange(groups);

                if (startGroup != null) { comboBox1.SelectedIndex = groups.ToList().FindIndex(group => group.Id == startGroup.Id); }
            }
            comboBox1.SelectedItem = startGroup;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || comboBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Не всі поля заповненні", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var context = new UniversityContext())
            {
                context.Database.EnsureCreated();
                Group? group = comboBox1.SelectedItem as Group;
                if (group == null) group = new Group { Id = 0 };
                context.Students.Add(new Student { Name = textBox1.Text, Group = context.Groups.Find(group.Id), AVG = Convert.ToInt32(textBox2.Text) });
                context.SaveChanges();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
