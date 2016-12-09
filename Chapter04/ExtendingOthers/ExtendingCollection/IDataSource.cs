using System.Collections.Generic;

namespace ExtendingCollection
{
    public interface IDataSource
    {
        IEnumerable<DataItem> GetItems();
    }
}
