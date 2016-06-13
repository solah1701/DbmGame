using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness
{
    public partial class DbmArmyListEditor : Form, IMainPageView
    {
        public DbmArmyListEditor()
        {
            InitializeComponent();
        }

        public void SelectTab(string tabName)
        {
            throw new NotImplementedException();
        }
    }
}
