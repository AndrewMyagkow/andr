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
    public partial class ChoiceQuest : Form
    {
        public ChoiceQuest()
        {
            InitializeComponent();

            button1.Click += (s, e) => { CreateOpen createOpen = new CreateOpen(); createOpen.Show(); Hide(); };
            button2.Click += (s, e) => { CreateTest createTest = new CreateTest(); createTest.Show(); Hide(); };
        }

        private void ChoiceQuest_FormClosed(object sender, FormClosedEventArgs e) => Environment.Exit(0);
    }
}
