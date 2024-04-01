using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PZ13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear(); 
            string firstName = firstNameTextBox.Text;
            string lastName = lastNamTextBox.Text;
            string birthDateText = birthDatatextBox.Text;
            DateTime birthDate;


            if (!DateTime.TryParse(birthDateText, out birthDate))
            {
                errorProvider1.SetError(birthDatatextBox,"Введіть дату народження у форматі dd.MM.yyyy.");
                return;
            }

            if (firstName.Length < 1 || firstName.Length > 20 || lastName.Length < 1 || lastName.Length > 20)

            {
                MessageBox.Show("Ім'я та прізвище повинні містити від 1 до 20 літер.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (birthDate.Year < 1930 || birthDate.Year > 2020)
            {
               MessageBox.Show ("Рік народженн має діапазон з 1930 по 2020", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            MessageBox.Show("Успішна валідація", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
