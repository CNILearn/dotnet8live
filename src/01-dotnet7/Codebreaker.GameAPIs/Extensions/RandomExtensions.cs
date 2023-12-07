namespace Codebreaker.GameAPIs.Extensions;

public static class RandomExtensions
{
    public static T[] GetItems<T>(this Random random, T[] choices, int length)
    {
        var items = new T[length];

        for (int i = 0; i < length; i++)
            items[i] = choices[random.Next(0, choices.Length)];

        return items;

        // OR
        //return Enumerable.Range(0, length)
        //    .Select(i => choices[random.Next(0, choices.Length)])
        //    .ToArray();
    }
}