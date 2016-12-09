using System.Collections.Generic;

namespace ExtendingInterface
{
    public interface IDataSource
    {
        IEnumerable<DataItem> GetItems();
    }
}