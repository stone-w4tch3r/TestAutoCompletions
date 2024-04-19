namespace Core;

internal static class Extensions
{
    public static IEnumerable<T> TakeNotMoreThan<T>(this IEnumerable<T> source, int count)
    {
        var i = 0;
        foreach (var item in source)
        {
            if (i >= count) yield break;

            yield return item;
            i++;
        }
    }
}