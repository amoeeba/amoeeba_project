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
using Newtonsoft.Json.Linq;
using Newtonsoft;

namespace ExternalJSON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            var json = File.ReadAllText("C:\\Users\\Raj\\Documents\\Visual Studio 2013\\Projects\\ExternalJSON\\ExternalJSON\\credentials_settings");

            var json2 = File.ReadAllText("C:\\Users\\Raj\\Documents\\Visual Studio 2013\\Projects\\ExternalJSON\\ExternalJSON\\settings.txt");



            var settingsNamelst1 = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json);

            var settingsNamelst2 = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json2);

            List<string> ver_val1 = new List<string>();
            List<string> ver_val2 = new List<string>();


            foreach (var item in settingsNamelst1.Valuestore)
            {
                ListViewItem lv = new ListViewItem(item.name);
                //lv.SubItems.Add();
                lv.SubItems.Add(item.value.value);
                listView1.Items.Add(lv);
                ver_val1.Add(item.value.value);
              
            }

            foreach (var item1 in settingsNamelst2.Valuestore)
            {
                ListViewItem lv1 = new ListViewItem(item1.name);
                //lv.SubItems.Add();
                lv1.SubItems.Add(item1.value.value);
                listView2.Items.Add(lv1);
                ver_val2.Add(item1.value.value);
            }

            //for (int i = 0; i < ver_val1.Count; i++)
            //{
            //    if (ver_val1[i] == ver_val2[i])
            //    {
            //        listView3.Items.Add("OK");
            //    }
            //    else
            //    {
            //        listView3.Items.Add("CONFLICT");
            //    }
            //}

        }
    }
}
