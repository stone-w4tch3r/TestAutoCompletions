namespace Core;

internal static class Serializer
{
    internal static string Serialize(CompletionsModel model)
    {
        var strArray = model.Completions
            .Select(completion => $"{completion.Key}\n    {string.Join("\n    ", completion.Value)}\n");
        var str = string.Join("\n", strArray);

        return str;
    }
}