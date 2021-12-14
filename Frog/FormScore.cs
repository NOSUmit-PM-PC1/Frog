using System;
using System.IO;
using System.Windows.Forms;

namespace Frog
{
    public partial class FormScore : Form
    {
        public int result = -1;
        public FormScore()
        {
            InitializeComponent();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            listBoxWiners.Items.Add(textBoxUser.Text + " " + result.ToString());
            StreamWriter file = new StreamWriter("result.txt");
            for (int i = 0; i < listBoxWiners.Items.Count; i++)
            {
                file.WriteLine(listBoxWiners.Items[i].ToString());
            }
            
            file.Close();
        }

        private void FormScore_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("result.txt");
            while (!file.EndOfStream)
            {
                string s = file.ReadLine();
                listBoxWiners.Items.Add(s);
            }
            file.Close();
        }
    }
}
