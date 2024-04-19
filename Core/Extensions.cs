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

    public static T Map<T>(this string str, Func<string, T> func)
    {
        return func(str);
    }

    public static T Tap<T>(this T obj, Action<T> action)
    {
        action(obj);
        return obj;
    }
}