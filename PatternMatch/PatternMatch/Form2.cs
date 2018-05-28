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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string pattern = textBox2.Text;
            KMPSearch(text, pattern);
        }
        public List<int> KMPSearch(string text, string pattern)
        {
            int N = text.Length;
            int M = pattern.Length;

            int[] lpsArray = new int[M];
            List<int> matchedIndex = new List<int>();

            LongestPrefixSuffix(pattern, ref lpsArray);

            int i = 0, j = 0;
            while (i < N)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }

                // match found at i-j
                if (j == M)
                {
                    matchedIndex.Add(i - j);
                    MessageBox.Show("Pattern found at index " +(i - j).ToString());
                    j = lpsArray[j - 1];
                }
                else if (i < N && text[i] != pattern[j])
                {
                    if (j != 0)
                    {
                        j = lpsArray[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return matchedIndex;
        }

        public void LongestPrefixSuffix(string pattern, ref int[] lpsArray)
        {
            int M = pattern.Length;
            int len = 0;
            lpsArray[0] = 0;
            int i = 1;

            while (i < M)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lpsArray[i] = len;
                    i++;
                }
                else
                {
                    if (len == 0)
                    {
                        lpsArray[i] = 0;
                        i++;
                    }
                    else
                    {
                        len = lpsArray[len - 1];
                    }
                }
            }
        }

        //private void button2_Click(object sender, EventArgs e)
        //{

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

    }
}
