namespace CsvParser.SourceGenerator.Tests;

public class CsvSerializationGeneratorTests
{
    [Fact]
    public void GenerateSerializationMethod()
    {
        var result = GeneratorTestHelper.RunGenerator<CsvSerializationGenerator>(
            """
            using CsvParser.Library;

            [assembly: CsvSerializable(typeof(MyNamespace.MyClass))]

            namespace MyNamespace
            {
                public class MyClass
                {
                    public int Integer { get; set; }
                    
                    public string String { get; set; }
                }
            }
            """);
    }
}