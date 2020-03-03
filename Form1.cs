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
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView.View = View.Details;           //컬럼형식으로 변경

            listView.FullRowSelect = true;          //Row 전체 선택

            listView.Columns.Add("원래 이름", 150);        //컬럼추가
            listView.Columns.Add("변경될 이름", 150);
            listView.Columns.Add("파일 위치", 120);

        }
        private void listView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void listView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            listView.BeginUpdate();

            ListViewItem lvi1 = new ListViewItem(s);
            lvi1.SubItems.Add("");
            lvi1.SubItems.Add("");
            lvi1.ImageIndex = 0;
            listView.Items.Add(lvi1);
            listView.EndUpdate();
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
            listView.Items.RemoveAt(listView.SelectedIndex);
        }
    }
}
