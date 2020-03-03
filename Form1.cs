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
        private List<Tuple<string, string>> progressSave = new List<Tuple<string, string>>();
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
            foreach (string fileName in listBox1.Items)
            {
                // TODO: 폴더인지 확인하는 알고리즘 작성
                System.IO.File.Move(fileName, doProgress(fileName));
            }
        }

        private string doProgress(string fileName)
        {
            string temp = fileName;
            foreach (Tuple<string, string> pro in progressSave)
            {
                temp = temp.Replace(pro.Item1, pro.Item2);
            }
            return temp;
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
