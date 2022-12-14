using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Kursovaya3
{
    public partial class CreateTest : Form
    {
        Root_2 test = new Root_2();
        public CreateTest()
        {
            InitializeComponent();

            test.Testquestions = new List<Testquestion>();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            test.Testquestions.Add(
                new Testquestion()
                {
                    Q = string.IsNullOrWhiteSpace(textBox1.Text) ? "" : textBox1.Text,
                    A1 = string.IsNullOrWhiteSpace(textBox2.Text) ? "" : textBox2.Text,
                    A2 = string.IsNullOrWhiteSpace(textBox3.Text) ? "" : textBox3.Text,
                    A3 = string.IsNullOrWhiteSpace(textBox4.Text) ? "" : textBox4.Text,
                    A4 = string.IsNullOrWhiteSpace(textBox5.Text) ? "" : textBox5.Text,
                    Right = string.IsNullOrWhiteSpace(textBox6.Text) ? "" : textBox6.Text
                });
            printQuest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(test, Formatting.Indented);
            File.WriteAllText("TestQuestions.json", json);
        }

        private void CreateTest_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

        void printQuest()
        {
            richTextBox1.Text += textBox1.Text + '\n';
        }
    }
}
