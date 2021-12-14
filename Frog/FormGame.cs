using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frog
{
    public partial class FormGame : Form
    {
        Bitmap frogLeft, frogRight, frogEmpty;
        int[] frogs = { 1, 1, 1, 1, 0, 2, 2, 2, 2 };
        int emptyCell = 4;
        int step = 0;

        bool isGameEnd()
        {
            int count2 = 0;
            int count1 = 0;
            for (int i = 0; i < 4; i++)
            {
                if (frogs[i] == 2) count2++;
                if (frogs[5 + i] == 1) count1++;
            }
            if (count1 == 4 && count2 == 4)
                return true;
            return false;
        }

        private void dataGridViewField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Math.Abs(e.ColumnIndex - emptyCell) <= 2)
            {
                frogs[emptyCell] = frogs[e.ColumnIndex];
                frogs[e.ColumnIndex] = 0;
                emptyCell = e.ColumnIndex;
                drawFrogs();
                step++;
                labelSteps.Text = "Количество шагов - " + step.ToString();
                if (isGameEnd())
                {
                    MessageBox.Show("Победа!");
                    FormScore form = new FormScore();
                    form.result = step;
                    form.Show();
                }
            }
            else
                MessageBox.Show("Так ходить нельзя!");
        }

        public FormGame()
        {
            InitializeComponent();
        }

        void drawFrogs()
        {
            for (int i = 0; i < frogs.Length; i++)
            {
                switch (frogs[i])
                {
                    case 0:
                        dataGridViewField.Rows[0].Cells[i].Value = frogEmpty; break;
                    case 1:
                        dataGridViewField.Rows[0].Cells[i].Value = frogLeft; break;
                    case 2:
                        dataGridViewField.Rows[0].Cells[i].Value = frogRight; break;
                }
            }
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            frogLeft = new Bitmap("frog1.png");
            frogRight = new Bitmap("frog2.png");
            frogEmpty = new Bitmap("list.png");
            dataGridViewField.Rows.Add();
            drawFrogs();
        }
    }
}
