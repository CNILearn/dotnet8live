using System.Collections.Immutable;
using System.Threading.Channels;

using CollectionLiterals;

// use different collection types with collection expressions

Span<int> span1 = [1, 2, 3];
Console.WriteLine(span1[1]);

int[] arr = [5, 6];
List<int> list = [7, 8, 9];
HashSet<int> set = [10, 11, 12];
ImmutableArray<int> immArray = [13, 14, 15];

IList<int> iList = [16, 17, 18];
Console.WriteLine($"The type declared with IList<int> is {iList.GetType().Name}");

ICollection<int> iCollection = [19, 20, 21];

IReadOnlyList<int> iReadOnlyList = [20, 21, 22];

IReadOnlyCollection<int> iReadOnlyCollection = [23, 24, 25];

IEnumerable<int> iEnumerable = [26, 27, 28];

List<int> multiple = [..iList, 4, ..iCollection, ..span1[1..] ];

foreach (int i in multiple)
{
    Console.WriteLine(i);
}
Console.WriteLine();

// custom collections

Console.WriteLine("custom collections");
MyCustomCollection<int> coll1 = [1, 2, 4, 8];
MyCustomCollection<int> coll2 = [7, 22, 33];
ICustomCollection<int> coll3 = [44, 55, 88];
MyCustomCollection<int> coll4 = [.. coll1, .. coll2, ..coll3];
foreach (int item in coll4)
{
    Console.WriteLine(item);
}
Console.WriteLine();

Console.WriteLine("Span");
// attention with spans!
byte[] buffer2 = new byte[4];

// Span<byte> span2 = buffer2.AsSpan();
Span<byte> span2 = [.. buffer2];  // don't use collection expressions with Span!
span2[0] = 1;
Console.WriteLine(buffer2[0]);
