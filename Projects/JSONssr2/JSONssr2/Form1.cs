using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSONssr2
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
            #region Serialize Object
            var emp = new Employee()
            {
                ID = 1,
                Name = "Jigsaw",
                Job = "Please respect others life"
            };

            var resultObject = Newtonsoft.Json.JsonConvert.SerializeObject(emp);

            textBox1.AppendText(resultObject);

            #endregion
        }
    }
}
