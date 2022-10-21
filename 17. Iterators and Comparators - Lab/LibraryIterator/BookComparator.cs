using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            if (x.Title != y.Title)
            {
                return x.Title.CompareTo(y.Title);
            }

            return y.Year.CompareTo(x.Year);
        }
    }
}
