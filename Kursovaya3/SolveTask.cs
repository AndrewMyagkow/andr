using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Kursovaya3
{
    public partial class SolveTask : Form
    {
        Root OpenQ = new Root();
        Root_2 TestQ = new Root_2();
        bool checkSolve = true;
        string lastSelect;
        int index;

        public SolveTask()
        {
            InitializeComponent();

            string OpenQuest = File.ReadAllText("OpenQuestions.json");
            string TestQuest = File.ReadAllText("TestQuestions.json");

            OpenQ = JsonConvert.DeserializeObject<Root>(OpenQuest);
            TestQ = JsonConvert.DeserializeObject<Root_2>(TestQuest);

            setListBox();

            label4.Text = $"0/{OpenQ.questions.Count + TestQ.Testquestions.Count}";
        }

        private void setListBox()
        {
            foreach (var question in OpenQ.questions)
                listBox1.Items.Add(question.Q);
            foreach (var question in TestQ.Testquestions)
                listBox2.Items.Add(question.Q);
        }

        private void SolveTask_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkSolve)
            {
                MessageBox.Show("Вы уже решаете вопрос");
                return;
            }
            try
            {
                label2.Text = radioButton1.Checked ? OpenQ.questions[listBox1.SelectedIndex].Q : TestQ.Testquestions[listBox2.SelectedIndex].Q;
                if (radioButton1.Checked)
                {
                    listBox1.Items[listBox1.SelectedIndex] = "Выбрано";
                    index = listBox1.SelectedIndex;
                    lastSelect = "Открытый";
                }
                else
                {
                    listBox2.Items[listBox2.SelectedIndex] = "Выбрано";
                    index = listBox2.SelectedIndex;
                    lastSelect = "Тест";
                    visibleRadio(true);
                    radioButton3.Text = TestQ.Testquestions[listBox2.SelectedIndex].A1;
                    radioButton4.Text = TestQ.Testquestions[listBox2.SelectedIndex].A2;
                    radioButton5.Text = TestQ.Testquestions[listBox2.SelectedIndex].A3;
                    radioButton6.Text = TestQ.Testquestions[listBox2.SelectedIndex].A4;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                checkSolve = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkAnswer())
            {
                checkSolve = true;
                MessageBox.Show("Да");
                counter(true);
            }
            else
            {
                checkSolve = true;
                MessageBox.Show("Нет");
            }
            if (!checkQuest())
            {
                MessageBox.Show("Вопросы закончились. Результаты сохранены в файл results.txt");
                File.AppendAllText("results.txt", $"Дата: {DateTime.Now} Результат: {label4.Text}\n");
            }
        }

        bool checkAnswer()
        {
            if (lastSelect == "Открытый")
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Выберите задание");
                    return false;
                }
                if (textBox1.Text == OpenQ.questions[index].A)
                {
                    listBox1.Items[index] = "Решено";
                    return true;
                }    
                else
                {
                    listBox1.Items[index] = "Решено";
                    return false;
                }
            }
            else
            {
                if (findButton() == TestQ.Testquestions[index].Right)
                {
                    listBox2.Items[index] = "Решено";
                    visibleRadio(false);
                    clearRadio();
                    return true;
                }
                else
                {
                    listBox2.Items[index] = "Решено";
                    visibleRadio(false);
                    clearRadio();
                    return false;
                }
            }
        }

       string findButton()
       {
            foreach (RadioButton radio in Controls.OfType<RadioButton>())
            {
                if (radio.Checked)
                    return radio.Text;
            }
            return "-1";
       }

        void clearRadio()
        {
            radioButton3.Text = "";
            radioButton4.Text = "";
            radioButton5.Text = "";
            radioButton6.Text = "";
        }

        bool checkQuest()
        {
            foreach (string quest in listBox1.Items)
                if (quest != "Решено")
                    return true;
            foreach (string quest in listBox2.Items)
                if (quest != "Решено")
                    return true;
            return false;
        }

        void counter(bool result)
        {
            if (result)
            {
                int well = Convert.ToInt32(label4.Text.Split('/')[0]);
                label4.Text = $"{well + 1}/{OpenQ.questions.Count + TestQ.Testquestions.Count}";
            }
        }
        void visibleRadio(bool action)
        {
            radioButton3.Visible = action;
            radioButton4.Visible = action;
            radioButton5.Visible = action;
            radioButton6.Visible = action;
        }
    }
}
