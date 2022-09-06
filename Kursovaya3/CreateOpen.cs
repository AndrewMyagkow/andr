using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DocumentFormat.OpenXml.Bibliography;

namespace Kursovaya3
{
    public partial class CreateOpen : Form
    {
        Root OpenQuest = new Root();

        public CreateOpen()
        {
            InitializeComponent();

            OpenQuest.questions = new List<Openquestion>();
        }

        private void CreateTask_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

        private void button1_Click(object sender, EventArgs e) 
        {
            string json = JsonConvert.SerializeObject(OpenQuest, Formatting.Indented);
            richTextBox1.Text = json;
            File.WriteAllText("OpenQuestions.json", json);
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            OpenQuest.questions.Add(new Openquestion()
            {
                Q = textBox1.Text,
                A = textBox2.Text
            });
            printList();
        }

        void printList()
        {
            richTextBox1.Text += $"Q:{textBox1.Text}\nA:{textBox2.Text}\n\n";
        }
    }
}
