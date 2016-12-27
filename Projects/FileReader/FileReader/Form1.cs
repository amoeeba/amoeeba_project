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
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft;
using Newtonsoft.Json.Serialization;


namespace FileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Job { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
                using (StreamReader sr = new StreamReader(label1.Text))
                {
                    while (!sr.EndOfStream)
                    {
                        textBox1.AppendText(sr.ReadLine());
                        
                    }
                }
                  
               
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region Serialize Object
            var emp = new Employee()
            {
                ID = 1,
                Name = "Jigsaw",
                Job = "Please respect others life"
            };

            var resultObject = Newtonsoft.Json.JsonConvert.SerializeObject(emp);

            textBox2.AppendText(resultObject);

            #endregion
        }


    }
}
