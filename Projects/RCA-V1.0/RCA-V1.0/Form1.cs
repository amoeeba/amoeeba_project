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

namespace RCA_V1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checker();
        }

        public void checker()
        {
            if(listView1.Items.Count>0)
            {
                menuStrip1.Enabled = true;
            }
            else
            {
                menuStrip1.Enabled = false;
            }
        }
        public class Value
        {
            public string value { get; set; }
        }

        public class Valuestore
        {
            public string name { get; set; }
            public string type { get; set; }
            public Value value { get; set; }
        }

        public class RootObject
        {
            public string version { get; set; }
            public List<Valuestore> Valuestore { get; set; }
        }

        List<string> ver_val2 = new List<string>();
        List<string> ver_val1 = new List<string>();

        public void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                var json = File.ReadAllText(textBox1.Text);

  
                try
                {
                    var settingsNamelst1 = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json);



                    foreach (var item in settingsNamelst1.Valuestore)
                    {
                        ListViewItem lv = new ListViewItem(item.name);
                        //lv.SubItems.Add();
                        lv.SubItems.Add(item.value.value);
                        listView1.Items.Add(lv);
                        ver_val1.Add(item.value.value);

                    }
                }

                catch
                {
                    MessageBox.Show("INVALID FILE TYPE. PLEASE TRY AGAIN");
                }

                checker();
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = openFileDialog2.FileName;
                var json2 = File.ReadAllText(textBox2.Text);

                try
                {
                    var settingsNamelst2 = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json2);



                    foreach (var item1 in settingsNamelst2.Valuestore)
                    {
                        ListViewItem lv1 = new ListViewItem(item1.name);
                        //lv.SubItems.Add();
                        lv1.SubItems.Add(item1.value.value);
                        listView2.Items.Add(lv1);
                        ver_val2.Add(item1.value.value);
                    }
                }
                
                catch
                {
                    MessageBox.Show("INVALID FILE TYPE. PLEASE TRY AGAIN");
                }

            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            if(ver_val1.Count==0)
            {
                MessageBox.Show("ERROR: Can not Read Config"+"Please Load Config File and try again");
            }
            else
            {
                try
                {
                    for (int i = 0; i < ver_val1.Count; i++)
                    {
                        if (ver_val1[i] == ver_val2[i])
                        {
                            listView3.Items.Add("OK");
                        }
                        else
                        {
                            listView3.Items.Add("CONFLICT");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("ERROR: Configuration File Object Length Missmatch"+"Manual Verification Required");
                }
                
            }
            
        }

        private void eXITToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void cLEARALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            ver_val1.Clear();
            ver_val2.Clear();
        }

        private void nEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            ver_val1.Clear();
            ver_val2.Clear();
        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 1.0"+"FrameWork: 4.5");
        }

        private void rEADMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Work Under Progress....");
        }

        public void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Choose file to save to",
                FileName = "config.csv",
                Filter = "CSV (*.csv)|*.csv",
                FilterIndex = 0,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                
                string[] headers = listView1.Columns
                           .OfType<ColumnHeader>()
                           .Select(header => header.Text.Trim())
                           .ToArray();

                string[][] items = listView1.Items
                            .OfType<ListViewItem>()
                            .Select(lvi => lvi.SubItems
                                .OfType<ListViewItem.ListViewSubItem>()
                                .Select(si => si.Text).ToArray()).ToArray();

                string[] headers1 = listView2.Columns
                           .OfType<ColumnHeader>()
                           .Select(header => header.Text.Trim())
                           .ToArray();

                string[][] items1 = listView2.Items
                            .OfType<ListViewItem>()
                            .Select(lvi => lvi.SubItems
                                .OfType<ListViewItem.ListViewSubItem>()
                                .Select(si => si.Text).ToArray()).ToArray();

                string table = string.Join(",", headers) + Environment.NewLine;
                string table1 = string.Join(",", headers1) + Environment.NewLine;
                foreach (string[] a in items)
                {
                    //a = a_loopVariable;
                    table += string.Join(",", a) + Environment.NewLine;
                }

                foreach (string[] b in items1)
                {
                    table1 += string.Join(",", b) + Environment.NewLine;
                }
                table += string.Join(",", table1) + Environment.NewLine;
                table = table.TrimEnd('\r', '\n');
                
                System.IO.File.WriteAllText(sfd.FileName, table);
            }
        }

    }
}
