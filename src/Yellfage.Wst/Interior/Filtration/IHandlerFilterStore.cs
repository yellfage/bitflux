using System.Collections.Generic;

using Yellfage.Wst.Filtration;
using Yellfage.Wst.Interior.Handling;

namespace Yellfage.Wst.Interior.Filtration
{
    internal interface IHandlerFilterStore
    {
        void AddRange(Handler handler, IEnumerable<IFilter> filters);
        IEnumerable<IFilter> GetAll(Handler handler);
    }
}
