using System.Collections.Generic;

namespace ExtendingObject
{
    public interface IDataSource
    {
        IEnumerable<DataItem> GetItems();
    }
}
