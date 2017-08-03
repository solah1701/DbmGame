using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;

namespace GameCore.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return $"You entered: {value}";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException(nameof(composite));
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public DbmUnit GetUnit(DbmUnit unit)
        {
            if (unit == null)
            {
                throw  new ArgumentNullException(nameof(unit));
            }
            return unit;
        }
    }
}
