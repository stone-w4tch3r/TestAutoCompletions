using Core;

namespace Tests;

public class BasicTest
{
    [Test]
    public void Basic1()
    {
        const string input = """
                             5
                             kare 10
                             kanojo 20
                             karetachi 1
                             korosu 7
                             sakura 3
                             3
                             k
                             ka
                             kar
                             """;
        const string expected = """
                                k
                                    kanojo
                                    kare
                                    korosu
                                    karetachi

                                ka
                                    kanojo
                                    kare
                                    karetachi

                                kar
                                    kare
                                    karetachi
                                """;
        var searcher = new AutoCompletionsSearcher();

        var output = searcher.SearchAutoCompletions(input);

        Assert.That(output, Is.EqualTo(expected));
    }
}