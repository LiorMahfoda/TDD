/*
Lior Mahfoda 302782230
Ehab Jaber 313232514
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex2;
using System.Diagnostics; 


namespace Ex2
{
    public partial class Table : Form
    {
        int vari;
        public const int leng = 10000;
        public Employee[] emp = new Employee[leng];
        public Employee[] tmp= new Employee[leng];
        
        public Table()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.vari = 0;
            label1.Visible = false;
            label2.Visible = false;
        }

        public bool Check()
        {
            for (int i = 0; i < leng - 1; i++)
            {
                for (int j = 0; j < leng - i - 1; j++)
                {
                    if (emp[j].GetSal().CompareTo(emp[j + 1].GetSal()) != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        public bool CheckFillTable()
        {
            int count = 0;
            for (int i = 0; i < leng - 1; i++)
            {
                count++;
            }
            if (count == (leng - 1))
                return true;
            return false;
        }

        //set data grid view
        public void setDatagridview()
        {
            for (int i = 0; i < leng; i++)
            {
                
            }
        }

        public void MakeBubbleSort()
        {
            Employee tmp = new Employee();

            for (int i = 0; i < leng - 1; i++)
            {
                for (int j = 0; j < leng - i - 1; j++)
                {
                    if (emp[j].GetSal().CompareTo(emp[j + 1].GetSal()) == 1)
                    {
                        tmp = emp[j];
                        emp[j] = emp[j + 1];
                        emp[j + 1] = tmp;
                    }
                }
            }
        }

        public void BubbleSortFailure()
        {
            Employee tmp = new Employee();

            for (int i = 0; i < leng - 1; i++)
            {
                for (int j = 0; j < leng - i - 1; j++)
                {
                        tmp = emp[j];
                        emp[j] = emp[j + 1];
                        emp[j + 1] = tmp;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fill();
        }

        public void Fill()
        {
            this.vari = 1;
            //String[] details;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.vari == 0)
            {
                label2.Visible = true;
                label2.Text = "You must fill the table first of all";
            }
            else
            {
                var stopWatch = Stopwatch.StartNew();
                MergeSort(0, leng - 1);
                setDatagridview();
             
                stopWatch.Stop();
             
                var elapsedMilliseconds = stopWatch.ElapsedMilliseconds;
                label2.Text = (TimeSpan.FromMilliseconds(elapsedMilliseconds).TotalSeconds).ToString() + " Sec";
                label2.Visible = true;
                label1.Visible = true;
                label1.Text = "MergeSort time is:";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.vari == 0)
            {
                label2.Visible = true;
                label2.Text = "Must fill the table before you can sorting!!!";

            }
            else
            {
                var stopWatch = Stopwatch.StartNew();
                MakeBubbleSort();
                setDatagridview();
                stopWatch.Stop();
                var elapsedMilliseconds = stopWatch.ElapsedMilliseconds;
                label2.Text = (TimeSpan.FromMilliseconds(elapsedMilliseconds).TotalSeconds).ToString() + " Sec";
                label2.Visible = true;
                label1.Visible = true;
                label1.Text = "BubbleSort time is:";
            }
        }
        
        public void MergeSort(int l, int r)
        {
            int middle;

            if (r > l)
            {
                middle = (r + l) / 2;
                MergeSort(l, middle);
                MergeSort((middle + 1), r);
                FinalMerge(l, (middle+ 1), r);
            }
        }

       
        private void FinalMerge(int l, int m, int r)
        {
            int i, left_Endside, length, position;

            left_Endside = (m - 1);
            position = l;
            length = (r - l + 1);

            while ((l <= left_Endside) && (m<= r))
            {
                if (Convert.ToInt32(emp[l].GetSal()) <= Convert.ToInt32(emp[m].GetSal()))
                    tmp[position++] = emp[l++];
                else
                    tmp[position++] = emp[m++];
            }

            while (l <= left_Endside)
                emp[position++] = emp[l++];

            while (m <= r)
                emp[position++] = emp[m++];

            for (i = 0; i < length; i++)
            {
                tmp[r] = tmp[r];
                r--;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
