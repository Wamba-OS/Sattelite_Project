using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace satelite_tracker_jense
{
    public partial class Form1 : Form
    {

        private UDLChecker udlChecker = new UDLChecker();

        public Form1()
        {
            InitializeComponent();
            SetAllTextBoxes();
            udlChecker.UDL_Get(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            udlChecker.SetMaxResults(Int32.Parse(comboBox1.Text));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetAllTextBoxes();
            udlChecker.SetSatelliteNumber(comboBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            udlChecker.UDL_Get(this);
        }

        //challenge 3 - added 2 new textboxs displaying the data and creator of each satellite
        private void button2_Click(object sender, EventArgs e)
        {
            udlChecker.SetSatCreationDate(textBox4.Text);
            udlChecker.SetSatCreatedBy(textBox4.Text);
            udlChecker.SelectSpecificSatelliteToDisplay();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetAllTextBoxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            organizeComboBox2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public void ResetAllTextBoxes()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;

        }

        public void SetAllTextBoxes()
        {
            textBox1.Text = "This is a test";
            textBox2.Text = "This is a test";
            textBox3.Text = "This is a test";
            textBox4.Text = "This is a test";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void comboBox2Update(string newValue)
        {
            comboBox2.Items.Add(newValue);
        }

        public void updateTextBox(string newValue, TextBox textBoxToUpdate)
        {
            textBoxToUpdate.AppendText(newValue);
            textBoxToUpdate.AppendText(Environment.NewLine);
            textBoxToUpdate.Refresh(); 
        }

        // challenge 3 added button to organize the dropdown satellite numbers by their creation date
        public void organizeComboBox2()
        {
            udlChecker.SatelliteNumberCreationOrder();
        }

        // challenge #3 added a way to type in the satellite number directly into textbox instead of drop down menu
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            udlChecker.SetSatelliteNumber(textBox7.Text);
        }
    }
}
