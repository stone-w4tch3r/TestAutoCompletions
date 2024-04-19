namespace Core;

public static class AutoCompletionsSearcher
{
    public static string SearchAutoCompletions(string input)
    {
        var inputModel = Parser.Parse(input);

        var completions = FastSearcher.SearchCompletions(inputModel);

        var str = Serializer.Serialize(completions);

        return str;
    }
}