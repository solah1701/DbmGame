using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GameCore.DebellisMultitudinis;

namespace GameCore.Wcf
{
    [ServiceContract]
    public interface IGameCoreService
    {
        //[OperationContract]
        //IDbmUnit GetDbmUnit(int id);
    }
}
