using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.BookmarkServiceReference;
using GameEditor.Wcf.Harness.ServiceReference1;

namespace GameEditor.Wcf.Harness
{
    public partial class Form1 : Form
    {
        private IBookmarkService service;
        public Form1()
        {
            InitializeComponent();
            service = new BookmarkServiceClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User();
            service.PutUser(textBox1.Text, user);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var user = service.GetUser(textBox1.Text);
            var service = new Service1Client();
            service.GenerateDatabase();
        }
    }
}
