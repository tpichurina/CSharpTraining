using System;
using System.Diagnostics.CodeAnalysis;

namespace address_book_tests_autoit
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public string Name { get; set; }

        public int CompareTo([AllowNull] GroupData other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals([AllowNull] GroupData other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
