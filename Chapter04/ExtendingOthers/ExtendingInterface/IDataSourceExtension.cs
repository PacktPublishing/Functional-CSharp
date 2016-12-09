<<<<<<< HEAD
﻿using System.Collections.Generic;

namespace ExtendingInterface
{
    public static class IDataSourceExtension
    {
        public static IEnumerable<DataItem> GetItemsByGender(
            this IDataSource src, 
            string gender)
        {
            foreach (DataItem item in src.GetItems())
            {
                if (item.Gender == gender)
                    yield return item;
            }
        }
    }
}
=======
﻿using System.Collections.Generic;

namespace ExtendingInterface
{
    public static class IDataSourceExtension
    {
        public static IEnumerable<DataItem> GetItemsByGender(
            this IDataSource src, 
            string gender)
        {
            foreach (DataItem item in src.GetItems())
            {
                if (item.Gender == gender)
                    yield return item;
            }
        }
    }
}
>>>>>>> origin/master
