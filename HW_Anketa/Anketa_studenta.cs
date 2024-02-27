using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HW_Anketa
{
    public partial class Anketa_studenta : Form
    {
        public Anketa_studenta()
        {
            InitializeComponent();
        }

        public class Anketa
        {
            public string Name { get; set; }
            public string Midlename { get; set; }
            public string Surname { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Phone { get; set; }
            public string Birthday { get; set; }
            public string Gender { get; set; }
            public Anketa()
            {
                Name = string.Empty;
                Midlename = string.Empty;
                Surname = string.Empty;
                Country = string.Empty;
                City = string.Empty;
                Phone = string.Empty;
                Birthday = string.Empty;
                Gender = string.Empty;
            }
            public Anketa(string name, string midlename, string surname, string country, string city, string phone, string birthday, string gender)
            {
                this.Name = name;
                this.Midlename = midlename;
                this.Surname = surname;
                this.Country = country;
                this.City = city;
                this.Phone = phone;
                this.Birthday = birthday;
                this.Gender = gender;
            }
        }


        private void comboBox_country_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_country.SelectedIndex == 0)
            {
                List<string> ru = new List<string>() { "Москва", "Санкт-Петербург", "Владивосток" };
                comboBox_city.Items.Clear();
                foreach (string s in ru)
                {
                    comboBox_city.Items.Add(s);
                }
            }
            else if (comboBox_country.SelectedIndex == 1)
            {
                List<string> br = new List<string>() { "Минск", "Брест", "Гомель" };
                comboBox_city.Items.Clear();
                foreach (string s in br)
                {
                    comboBox_city.Items.Add(s);
                }
            }
            else if (comboBox_country.SelectedIndex == 2)
            {
                List<string> jp = new List<string>() { "Токио", "Осака", "Киото" };
                comboBox_city.Items.Clear();
                foreach (string s in jp)
                {
                    comboBox_city.Items.Add(s);
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tb_midleName.Text == "" || tb_name.Text == "" || tb_surname.Text == "" || comboBox_country.Text == "" || comboBox_city.Text == "" || maskedTextBox1.Text == "")
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                string gender = "";
                string msg = $"ФИО: {tb_midleName.Text} {tb_name.Text} {tb_surname.Text}\n" +
                    $"Страна: {comboBox_country.Text}, город: {comboBox_city.Text}\n" +
                    $"Телефон: {maskedTextBox1.Text}\n" +
                    $"Дата рождения: {dateTimePicker1.Value.ToShortDateString()}\nПол:";
                if (rb_male.Checked == true)
                {
                    msg += $"{rb_male.Text}";
                    gender = rb_male.Text;
                }
                else
                {
                    msg += $"{rb_female.Text}";
                    gender = rb_female.Text;
                }
                MessageBox.Show($"Анкета студента: {msg}");
                Anketa anketa = new Anketa(tb_name.Text, tb_midleName.Text, tb_surname.Text, comboBox_country.Text, comboBox_city.Text,
                    maskedTextBox1.Text, dateTimePicker1.Value.ToShortDateString(), gender);
                XmlSerializer serial = new XmlSerializer(typeof(Anketa));
                using (FileStream fs = new FileStream("Anketa.xml", FileMode.Create))
                {
                    serial.Serialize(fs, anketa);
                    MessageBox.Show("Файл сохранен в директорию проекта");
                }
                Hide();
                StopWatch timer = new StopWatch();
                timer.Show();

            }

        }

    }
}
