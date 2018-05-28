using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatternMatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            string pat = textBox2.Text;
            search(txt, pat);
        }
        public static void search(String txt, String pat)
        {
            int M = pat.Length;
            int N = txt.Length;

            
            for (int i = 0; i <= N - M; i++)
            {
                int j;

                
                for (j = 0; j < M; j++)
                    if (txt[i + j] != pat[j])
                        break;

                
                if (j == M)
                
                    MessageBox.Show("Pattern found at index " + i);
          
            }
        }

        ////private void button1_Click(object sender, EventArgs e)
        //{
        //    Form1 f1 = new Form1();
        //    f1.Show();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

    }
}
