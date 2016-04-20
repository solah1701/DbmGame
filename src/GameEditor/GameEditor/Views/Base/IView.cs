using GameEditor.Controllers.Base;

namespace GameEditor.Views.Base
{
    public interface IView
    {
        bool CanCreate { get; set; }
        bool CanRead { get; set; }
        bool CanUpdate { get; set; }
        bool CanDelete { get; set; }
        bool Button1Visible { set; }
        bool Button2Visible { set; }
        bool Button3Visible { set; }
        bool Button4Visible { set; }
        string Button1Text { set; }
        string Button2Text { set; }
        string Button3Text { set; }
        string Button4Text { set; }
        int BoolValue { set; }
        void SetController(IController controller);
    }
}
