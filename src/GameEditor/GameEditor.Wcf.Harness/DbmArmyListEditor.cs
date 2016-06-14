using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Controllers;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness
{
    public partial class DbmArmyListEditor : Form, IMainPageView
    {
        private readonly IMainPageController _controller;

        public DbmArmyListEditor()
        {
            InitializeComponent();
            _controller = IoCContainer.Resolve<IMainPageController>();
            _controller.SetView(this);
        }

        public void SelectTab(string tabName)
        {
            MainTabControl.SelectTab(tabName);
        }
    }
}
