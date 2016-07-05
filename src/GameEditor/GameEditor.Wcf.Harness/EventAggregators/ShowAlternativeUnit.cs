namespace GameEditor.Wcf.Harness.EventAggregators
{
    public class ShowAlternativeUnit
    {
        public bool ShowList { get; private set; }

        public ShowAlternativeUnit(bool showList = false)
        {
            ShowList = showList;
        }
    }
}