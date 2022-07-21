using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{

    public interface IOperation
    {
        int Operate(int left, int right);
    }

    public interface IOperationData
    {
        Char Symbol { get; }
    }
}
