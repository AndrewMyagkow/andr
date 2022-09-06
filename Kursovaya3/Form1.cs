using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += (s, a) => { ChoiceQuest choiceQuest = new ChoiceQuest(); choiceQuest.Show(); Hide(); };
            button2.Click += (s, a) => { SolveTask solveTask = new SolveTask(); solveTask.Show(); Hide(); };
        }
    }
}
