using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Knapsack knapsack;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox4.Text.Length > 50)
            {
                MessageBox.Show("Please enter plain text to encrypt less than 50 characters");
                
            }
            else
            {
                textBox7.Text = "";
                string plainText = textBox4.Text;
                int n = Convert.ToInt32(textBox6.Text);
                int m = Convert.ToInt32(textBox5.Text);
                string superIncreasing = textBox3.Text;
                string[] superIncreasingArr = superIncreasing.Split(',');
                knapsack = new Knapsack();
                string publicKey = knapsack.getPublicKey(n, m, superIncreasingArr);
                int mod = plainText.Length % superIncreasingArr.Length;
                int rest = superIncreasingArr.Length - mod;

                if (radioButton6.Checked == true)
                {
                    string binary = knapsack.convertToBinary(plainText);

                    Console.WriteLine("Ostatak je" + mod);
                    Console.WriteLine("broj nula je" + rest);
                    for (int i = 0; i < rest; i++)
                    {
                        binary += "0";
                    } //problem je u dodavanju nula ovde negde
                    Console.WriteLine("konacni binary" + binary);


                    string cipher = knapsack.getcipher(publicKey, binary);

                    foreach (char p in publicKey)
                    {
                        Console.WriteLine(p);
                    }
                    Console.WriteLine("ispod");
                    foreach (char c in cipher)
                    {
                        textBox7.Text += c;
                    }
                } else if (radioButton5.Checked == true)
                {
                    string binary = knapsack.convertToBinaryTurkish(plainText);

                    Console.WriteLine("Ostatak je" + mod);
                    Console.WriteLine("broj nula je" + rest);
                    for (int i = 0; i < rest; i++)
                    {
                        binary += "0";
                    } //problem je u dodavanju nula ovde negde
                    Console.WriteLine("konacni binary" + binary);


                    string cipher = knapsack.getcipher(publicKey, binary);

                    foreach (char p in publicKey)
                    {
                        Console.WriteLine(p);
                    }
                    Console.WriteLine("ispod");
                    foreach (char c in cipher)
                    {
                        textBox7.Text += c;
                    }
                }
                else { MessageBox.Show("Please select language"); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            knapsack = new Knapsack();
            textBox11.Text = "";
            string cipher = textBox8.Text;
            string superIncreasing = textBox12.Text;
            string[] cipherArr = cipher.Split(',');
            string[] superIncreasingArr = superIncreasing.Split(',');
            int n = Convert.ToInt32(textBox9.Text);
            int m = Convert.ToInt32(textBox10.Text);
            int inverse = knapsack.solve(n, m);
            if (inverse == 0) { MessageBox.Show("There is no inverse therefore no solution to this encryption"); }
            else
            {
                string plain = knapsack.calculatePlain(cipherArr, inverse, m);
                Console.WriteLine("Calculate plain" + plain);
                string binaryArr = knapsack.calculateBinary(plain, superIncreasing);
                Console.WriteLine("Calculate binary" + binaryArr);
                if (radioButton8.Checked == true)
                {
                    string binaryToDec = knapsack.binaryToDec(binaryArr);
                    Console.WriteLine("binary to Dec" + binaryToDec);
                    Console.WriteLine(knapsack.decToChar(binaryToDec));
                    textBox11.Text = knapsack.decToChar(binaryToDec);
                } else if (radioButton7.Checked == true)
                {
                    string binaryToDec = knapsack.binaryToDecTurkish(binaryArr);
                    Console.WriteLine("binary to Dec" + binaryToDec);
                    Console.WriteLine(knapsack.decToCharTurkish(binaryToDec));
                    textBox11.Text = knapsack.decToCharTurkish(binaryToDec);
                }
                else { MessageBox.Show("Please select language"); }
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
