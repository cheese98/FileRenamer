using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileRenamer
{
    public partial class Form1 : Form
    {
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

            listView.Columns.Add("번호", 40);
            listView.Columns.Add("원래 이름", 100);        //컬럼추가
            listView.Columns.Add("변경될 이름", 100);
            listView.Columns.Add("파일 위치", 150);

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
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            listView.BeginUpdate();
            int count = listView.Items.Count;
            foreach (string path in paths)
            {
                // TODO: 폴더일 경우 continue
                string fileName = Path.GetFileName(path);
                ListViewItem lvi = new ListViewItem((++count).ToString());
                lvi.SubItems.Add(fileName);
                lvi.SubItems.Add(fileName);
                lvi.SubItems.Add(Path.GetDirectoryName(path));
                lvi.ImageIndex = 0;
                listView.Items.Add(lvi);
            }
            listView.EndUpdate();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachFile in listView.Items)
            {
                System.IO.File.Move(eachFile.SubItems[3].Text + "\\" + eachFile.SubItems[1].Text, eachFile.SubItems[3].Text + "\\" + eachFile.SubItems[2].Text);
            }
        }
        /*
        private string doProgress(string fileName)
        {
            string temp = fileName;
            foreach (Tuple<string, string> pro in progressSave)
            {
                temp = temp.Replace(pro.Item1, pro.Item2);
            }
            return temp;
        }*/
        private void removeButton_Click(object sender, EventArgs e)
        {
            //foreach()
            //listView.Items.RemoveAt();
            foreach (ListViewItem eachItem in listView.SelectedItems)
            {
                listView.Items.Remove(eachItem);
            }
            for(int i = 0; i < listView.Items.Count; i++)
            {
                listView.Items[i].Text = (i + 1).ToString();
            }
        }

        private void removeSpaceButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem fileName in listView.Items)
            {
                fileName.SubItems[2].Text = fileName.SubItems[2].Text.Replace(" ", "");
            }
        }
    }
}
