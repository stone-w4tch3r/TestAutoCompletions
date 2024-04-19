using Core;

Console.WriteLine("Ach Scheiße, jetzt geht es wieder los...");

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

Console.WriteLine($"Input:\n\n{input}");
Console.WriteLine("\n\n");
Console.WriteLine($"Expected:\n\n{expected}");

var output = AutoCompletionsSearcher.SearchAutoCompletions(input);

Console.WriteLine("\n\n");
Console.WriteLine($"Output:\n\n{output}");

Console.WriteLine("\n\n");
Console.WriteLine("Test passed: " + (output == expected));