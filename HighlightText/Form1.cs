using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HighlightText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string text=null;
        public void Highlight()
        {
            Color[] HighColor = new Color[6] { Color.DarkGreen,Color.Red,Color.DeepPink,Color.Purple,Color.Blue,Color.Black};
            string[] patten = new string []{@"//.*|/\*[\s\S]*?\*/",@"#i\w+",@"#d\w+\s+\w+\s+[a-zA-Z]+",@"#d\w+\s+\w+\s+[0-9]+",@"\b(auto|break|case|char|const|continue|default|do|double|else|enum|extern|float|for|goto|if|int|long|register|return|short|static|signed|sizeof|struct|switch|typedef|unionun|signed|void|volatile|while)\b"};
            richTextBox1.Select(0,richTextBox1.TextLength);
            richTextBox1.SelectionColor = HighColor[5];
            richTextBox1.SelectionFont = new Font("Courier new", 10, FontStyle.Bold);
            for (int k = 0; k <5; k++)
            {
                Regex rex = new Regex(patten[k]);
                MatchCollection match = rex.Matches(this.richTextBox1.Text);
                foreach (Match mc in match)
                {
                    for (int i = 0; i < mc.Groups.Count; i++)
                    {
                        Group group = mc.Groups[i];
                        if (group.Success)
                        {
                            int start = group.Index;
                            int end = group.Length;
                            richTextBox1.Select(start, end);
                            richTextBox1.SelectionColor = HighColor[k];
                            richTextBox1.SelectionFont = new Font("Courier new", 10, FontStyle.Regular);
                        }
                    }
                }
            }
         }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //text = richTextBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
             Highlight();
        }
    }
}
