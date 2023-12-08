using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace CollectionLiterals;

[CollectionBuilder(typeof(MyCustomCollection), methodName: nameof(MyCustomCollection.Create))]
internal class MyCustomCollection<T> : Collection<T>, ICustomCollection<T>
{
}

[CollectionBuilder(typeof(MyCustomCollection), methodName: nameof(MyCustomCollection.Create))]
internal interface ICustomCollection<T> : IEnumerable<T>
{
}

internal static class MyCustomCollection
{
    public static MyCustomCollection<T> Create<T>(ReadOnlySpan<T> items)
    {
#pragma warning disable IDE0028 // Simplify collection initialization
        // results in recursive invocations https://github.com/dotnet/roslyn/issues/70099
        MyCustomCollection<T> collection = new();
        foreach (T item in items)
        {
            collection.Add(item);
        }
#pragma warning restore IDE0028 // Simplify collection initialization
        return collection;
    }
}

