namespace Core;

public static class Parser
{
    public class InvalidInputException(string message, int lineNumber, string line) : Exception(message)
    {
        public int LineNumber { get; } = lineNumber;

        public string Line { get; } = line;
    }
    
    public static InputModel Parse(string input)
    {
        var lines = input.Split("\n");

        int dictLength;
        try
        {
            dictLength = int.Parse(lines[0]);
        }
        catch (Exception)
        {
            throw new InvalidInputException("First line must be a valid dictionary length", 0, lines[0]);
        }


        var dictWordsWithWeights = new Dictionary<string, int>();
        for (var i = 1; i <= dictLength; i++)
        {
            var line = lines[i];
            var parts = line.Split(" ");
            if (!IsDictLineValid(parts))
                throw new InvalidInputException("Invalid dictionary line", i, line);

            var word = parts[0];
            var weight = int.Parse(parts[1]);
            dictWordsWithWeights[word] = weight;
        }

        int userWordsLength;
        try
        {
            userWordsLength = int.Parse(lines[dictLength + 1]);
        }
        catch (Exception)
        {
            throw new InvalidInputException("Invalid user words length", dictLength + 1, lines[dictLength + 1]);
        }

        var userWords = new string[userWordsLength];
        for (var i = 0; i < userWordsLength; i++)
            userWords[i] = lines[dictLength + 2 + i];

        return new(dictWordsWithWeights, userWords);
    }

    private static bool IsDictLineValid(string[] parts) => parts.Length == 2 && int.TryParse(parts[1], out _);
}