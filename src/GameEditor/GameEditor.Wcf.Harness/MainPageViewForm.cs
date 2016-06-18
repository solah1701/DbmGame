using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.IoC;
using GameEditor.Wcf.Harness.Presenters;
using GameEditor.Wcf.Harness.Views;

namespace GameEditor.Wcf.Harness
{
    public partial class MainPageViewForm : Form, IMainPageView
    {
        private readonly IMainPagePresenter _presenter;

        public MainPageViewForm()
        {
            InitializeComponent();
            _presenter = IoCContainer.Resolve<IMainPagePresenter>();
            _presenter.SetView(this);
        }

        public void SelectTab(string tabName)
        {
            MainTabControl.SelectTab(tabName);
        }
    }
}
