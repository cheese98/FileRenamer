using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRenamer
{
    public partial class Form1 : Form
    {
        private List<Tuple<string, string>> progressSave;
        public Form1()
        {
            InitializeComponent();
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
        }
        private void listBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void listBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                listBox1.Items.Add(s[i]);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Tuple<string, string> temp = Tuple.Create(" ", "");
            if (temp != null) progressSave.Append(temp);
            foreach (string before in listBox1.Items)
            {
                string after = before;
                foreach (Tuple<string, string> pro in progressSave)
                {
                    after.Replace(pro.Item1, pro.Item2);
                }

                System.IO.File.Move(before, after);
            }
            // TODO : 적용 알고리즘 작성
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
