using Caliburn.Micro;
using GameEditor.Wcf.Harness.Wpf.Models;
using GameEditor.Wcf.Harness.Wpf.ViewModels.Base;
using GameEditor.Wcf.Harness.Wpf.Views.Interfaces;
using GameEditor.Wcf.Harness.Wpf.WarGameServiceReference;

namespace GameEditor.Wcf.Harness.Wpf.ViewModels
{
    public sealed class AllyDetailViewModel : DetailViewModel, IAllyDetailViewModel
    {
        public LabelTextboxViewModel AllyListControl { get; set; }
        public LabelTextboxViewModel AllyNameControl { get; set; }
        public LabelTextboxViewModel BookControl { get; set; }
        public LabelTextboxViewModel ListControl { get; set; }
        public LabelTextboxViewModel MinYearControl { get; set; }
        public LabelTextboxViewModel MaxYearControl { get; set; }

        public int AllyListId
        {
            get
            {
                int value;
                return int.TryParse(AllyListControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (AllyListControl.TextBox == value.ToString()) return;
                AllyListControl.TextBox = value.ToString();
            }
        }
        public string AllyName
        {
            get { return AllyNameControl.TextBox; }
            set
            {
                if (AllyNameControl.TextBox == value) return;
                AllyNameControl.TextBox = value;
            }
        }
        public int Book
        {
            get
            {
                int value;
                return int.TryParse(BookControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (BookControl.TextBox == value.ToString()) return;
                BookControl.TextBox = value.ToString();
            }
        }
        public int List
        {
            get
            {
                int value;
                return int.TryParse(ListControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (ListControl.TextBox == value.ToString()) return;
                ListControl.TextBox = value.ToString();
            }
        }
        public int MinYear
        {
            get
            {
                int value;
                return int.TryParse(MinYearControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (MinYearControl.TextBox == value.ToString()) return;
                MinYearControl.TextBox = value.ToString();
            }
        }
        public int MaxYear
        {
            get
            {
                int value;
                return int.TryParse(MaxYearControl.TextBox, out value) ? value : 0;
            }
            set
            {
                if (MaxYearControl.TextBox == value.ToString()) return;
                MaxYearControl.TextBox = value.ToString();
            }
        }

        protected override int CurrentId => GameModel.CurrentAllyArmyDefinitionId;

        public AllyDetailViewModel(IEventAggregator eventAggregator, IGameModel gameModel)
            : base(eventAggregator, gameModel)
        {
            InitialiseView();
        }

        protected override void InitialiseView()
        {
            AllyListControl = new LabelTextboxViewModel(EventAggregator) { Label = "Ally List:" };
            AllyNameControl = new LabelTextboxViewModel(EventAggregator) { Label = "Ally Name:" };
            BookControl = new LabelTextboxViewModel(EventAggregator) { Label = "Book:" };
            ListControl = new LabelTextboxViewModel(EventAggregator) { Label = "List:" };
            MinYearControl = new LabelTextboxViewModel(EventAggregator) { Label = "Min Year:" };
            MaxYearControl = new LabelTextboxViewModel(EventAggregator) { Label = "Max Year:" };
            base.InitialiseView();
        }

        protected override void ViewChanged()
        {
            AllyListControl.CanTextBox = false;
            CanUpdate = !string.IsNullOrEmpty(AllyName);
            CanDelete = AllyListId != 0;
            base.ViewChanged();
        }

        public override void Clear()
        {
            AllyListId = 0;
            AllyName = string.Empty;
            Book = 0;
            List = 0;
            MinYear = 0;
            MaxYear = 0;
            base.Clear();
        }

        public override void Select(int currentId)
        {
            var item = GameModel.GetAlliedArmyDefinition(currentId);
            if (item == null) return;
            AllyListId = item.Id;
            AllyName = item.AllyName;
            Book = item.ArmyBook;
            List = item.ArmyList;
            MinYear = item.MinYear;
            MaxYear = item.MaxYear;
            base.Select(currentId);
        }

        public override void Update()
        {
            var definition = new AlliedArmyDefinition
            {
                Id = AllyListId,
                AllyName = AllyName,
                ArmyBook = Book,
                ArmyList = List,
                MinYear = MinYear,
                MaxYear = MaxYear
            };
            AllyListId = GameModel.AddAllyDefinition(definition);
            base.Update();
        }

        public override void Delete()
        {
            GameModel.DeleteAllyDefinition(AllyListId);
            base.Delete();
        }
    }
}