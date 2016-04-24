using System.Windows.Forms;
using GameCore.DebellisMultitudinis;
using GameEditor.Controllers;
using GameEditor.Extensions;
using GameEditor.IoC;
using GameEditor.Views;
using GameEditor.Views.Base;

namespace GameEditor
{
    public partial class UnitsControl : UserControl, IUnitsView
    {
        private readonly IUnitsController _controller;
        public new string Name { get { return NameTextBox.Text; } set { this.InvokeIfRequired(() => NameTextBox.Text = value); } }
        public int Attack { get { return (int)AttackNumericUpDown.Value; } set { this.InvokeIfRequired(() => AttackNumericUpDown.Value = value); } }
        public int Defence { get { return (int)DefenceNumericUpDown.Value; } set { this.InvokeIfRequired(() => DefenceNumericUpDown.Value = value); } }
        public new int Move { get { return (int)MoveNumericUpDown.Value; } set { this.InvokeIfRequired(() => MoveNumericUpDown.Value = value); } }
        public int Range { get { return (int)RangeNumericUpDown.Value; } set { this.InvokeIfRequired(() => RangeNumericUpDown.Value = value); } }
        public int Speed { get { return (int)SpeedNumericUpDown.Value; } set { this.InvokeIfRequired(() => SpeedNumericUpDown.Value = value); } }
        public int Stamina { get { return (int)StaminaNumericUpDown.Value; } set { this.InvokeIfRequired(() => StaminaNumericUpDown.Value = value); } }
        public int Level { get { return (int)LevelNumericUpDown.Value; } set { this.InvokeIfRequired(() => LevelNumericUpDown.Value = value); } }
        public int Morale { get { return (int)MoraleNumericUpDown.Value; } set { this.InvokeIfRequired(() => MoraleNumericUpDown.Value = value); } }
        public decimal Cost { get { return (decimal)CostNumericUpDown.Value; } set { this.InvokeIfRequired(() => CostNumericUpDown.Value = value); } }
        public int Upkeep { get { return (int)UpkeepNumericUpDown.Value; } set { this.InvokeIfRequired(() => UpkeepNumericUpDown.Value = value); } }
        public int ConstructionTime { get { return (int)BuildNumericUpDown.Value; } set { this.InvokeIfRequired(() => BuildNumericUpDown.Value = value); } }
        public IView SubView => baseControl1;

        public UnitsControl()
        {
            InitializeComponent();
            _controller = IoCContainer.Resolve<IUnitsController>();
            _controller.SetView(this);
        }

        public void ClearList()
        {
            UnitListView.ClearList("Name");
        }

        public void AddItem(IConstructableUnit item)
        {
            UnitListView.AddItem(item.Name);
        }

        public void RemoveItem(IConstructableUnit item)
        {
            UnitListView.RemoveItem(item.Name);
        }

        public void UpdateItem(IConstructableUnit item)
        {
            UnitListView.UpdateItem(item.Name);
        }

        public void SelectItem(IConstructableUnit item)
        {
            UnitListView.SelectItem(item.Name);
        }

        private void UnitListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (UnitListView.Items.Count > 0 && e.Item.Selected) _controller.SelectedItemChanged(e.Item.Text);
        }
    }
}
