using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssesmentC_
{
    public partial class Form1 : Form
    {
        private ArrayList wordsList = new ArrayList();
        private ArrayList concatenatedWordsList = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
        }
        private void InitializeUI()
        {
            label6.Font = new System.Drawing.Font("Arial", 24);
            label6.BackColor = System.Drawing.Color.White;
            label6.Dock = DockStyle.Bottom;

            button2.Text = "Concatenate Words";
            radioButton1.Checked = true;

            UpdateComboBoxes();
        }
        private void UpdateComboBoxes()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            foreach (string word in wordsList)
            {
                comboBox1.Items.Add(word);
                comboBox2.Items.Add(word);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string newWord = textBox1.Text.Trim();

            if (newWord == "")
            {
                MessageBox.Show("Please enter a word.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (wordsList.Contains(newWord))
            {
                MessageBox.Show("This word has already been added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            wordsList.Add(newWord);
            MessageBox.Show("Word added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateComboBoxes();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabel();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ConcatenateWords();
            }
            else
            {
                RemoveWord();
            }

            UpdateLabel();
        }
        private void ConcatenateWords()
        {
            string word1 = comboBox1.SelectedItem as string;
            string word2 = comboBox2.SelectedItem as string;

            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
            {
                MessageBox.Show("Please select two words to concatenate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (word1.Equals(word2))
            {
                MessageBox.Show("Please select different words for concatenation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string concatenatedWord = word1 + word2;
            concatenatedWordsList.Add(concatenatedWord);

            MessageBox.Show("Words concatenated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RemoveWord()
        {
            string selectedWordToRemove = comboBox1.SelectedItem?.ToString() ?? comboBox2.SelectedItem?.ToString();

            if (selectedWordToRemove == null)
            {
                MessageBox.Show("Please select a word to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            wordsList.Remove(selectedWordToRemove);
            concatenatedWordsList.Remove(selectedWordToRemove);

            MessageBox.Show($"Word '{selectedWordToRemove}' removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateComboBoxes();
        }

        private void UpdateLabel()
        {
            label6.Text = " " + string.Join(", ", concatenatedWordsList.ToArray());
        }
        private void UpdateComboBoxItem()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                int selectedIndex = comboBox1.SelectedIndex;
                string newValue = textBox1.Text;

                comboBox1.Items[selectedIndex] = newValue;
                label5.Text = comboBox1.Text;

                MessageBox.Show("Item updated in ComboBox: " + newValue);
            }
            else
            {
                MessageBox.Show("Please select an item to change.");
            }
        }

        private void AddItemToComboBox()
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !comboBox1.Items.Contains(textBox1.Text))
            {
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
                label5.Text = comboBox1.Text;

                MessageBox.Show("Item added to ComboBox: " + textBox1.Text);
            }
            else if (comboBox1.Items.Contains(textBox1.Text))
            {
                MessageBox.Show("This item already exists in the ComboBox.");
            }
            else
            {
                MessageBox.Show("Please enter a valid item.");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button1.Text = "Add Word";
            }
            else
            {
                button2.Text = "Concatenate Words";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                button2.Text = "Remove Word";
            }
            else
            {
                button2.Text = "Concatenate Words";
            }
        }
    }
}
