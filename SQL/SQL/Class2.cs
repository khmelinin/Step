using System;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace One
{
    // agregate function
    [Serializable]
    [SqlUserDefinedAggregate(Format.Native, 
        IsInvariantToNulls = false, 
        IsInvariantToDuplicates = true, 
        IsInvariantToOrder = true)]
    public struct Class2
    {
        private SqlDouble sum;
        public void Init()
        {
            sum = 0;
        }

        public void Accumulate(SqlDouble x)
        {
            if(!x.IsNull)
            {
                sum += x;
            }
        }

        public void Merge(Class2 other)
        {
            this.sum += other.sum;
        }

        public SqlDouble Terminate()
        {
            return sum;
        }
    }
}
