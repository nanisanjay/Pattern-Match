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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public static int d = 256;
        private void button4_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string pattern = textBox2.Text;

            int q = 101; // A prime number
            search(pattern, text, q);
        }
        private static void search(string pat, string txt, int q)
        {
            int M = pat.Length;
            int N = txt.Length;
            int i, j;
            int p = 0; 
            int t = 0; 
            int h = 1;

           
            h = (int)Math.Pow(d, M - 1) % q;

            for (i = 0; i < M; i++)
            {
                p = (d * p + (int)pat[i]) % q;
                t = (d * t + (int)txt[i]) % q;
            }
          
            for (i = 0; i <= N - M; i++)
            {

               
                if (p == t)
                {
                    /* Check for characters one by one */
                    for (j = 0; j < M; j++)
                    {
                        if (txt[i + j] != pat[j])
                            break;
                    }

                   
                    if (j == M)
                        MessageBox.Show("Pattern found at index " + i);
                }

                
                if (i < N - M)
                {
                    t = (d * (t - (int)txt[i] * h) + (int)txt[i + M]) % q;

                   
                    if (t < 0)
                        t = (t + q);
                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
