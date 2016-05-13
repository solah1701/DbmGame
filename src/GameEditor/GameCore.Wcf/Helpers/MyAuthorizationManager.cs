using System.ServiceModel;

namespace GameCore.Wcf.Helpers
{
    public class MyAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            return base.CheckAccessCore(operationContext);
        }
    }
}