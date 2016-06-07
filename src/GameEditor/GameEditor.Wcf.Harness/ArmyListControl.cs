using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameEditor.Wcf.Harness.Vews;

namespace GameEditor.Wcf.Harness
{
    public partial class ArmyListControl : UserControl, IArmyListView
    {
        public ArmyListControl()
        {
            InitializeComponent();
        }

        public string ArmyName { get; set; }
        public int ArmyBook { get; set; }
        public int ArmyId { get; set; }
        public int ArmyList { get; set; }
        public int MaxYear { get; set; }
        public int MinYear { get; set; }
    }
}
