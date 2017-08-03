using Caliburn.Micro;

namespace GameEditor.Wcf.Harness.Wpf.EventAggregators
{
    public class ShowView
    {
        public bool HideOriginatingView { get; set; }
        public string TargetView { get; private set; }

        public ShowView(string targetView)
        {
            TargetView = targetView;
        } 
    }
}