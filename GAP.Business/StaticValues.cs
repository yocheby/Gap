using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Business
{
    public abstract class StaticValues<T>
    {
        public virtual List<T> GetList()
        {
            return default;
        }
    }
}
