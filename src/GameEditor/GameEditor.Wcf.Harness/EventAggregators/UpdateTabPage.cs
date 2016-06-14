namespace GameEditor.Wcf.Harness.EventAggregators
{
    public class UpdateTabPage
    {
        public string Message { get; private set; }

        public UpdateTabPage(string message)
        {
            Message = message;
        }
    }
}