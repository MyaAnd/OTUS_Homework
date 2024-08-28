using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Interfaces
{
    public interface IMyCloneable<T>
    {
        T MyCloneMethod();
    }
}
