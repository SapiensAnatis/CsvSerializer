// See https://aka.ms/new-console-template for more information

using CsvHelper.Generated;
using CsvParser.Library;
using CsvParser.Models;

[assembly: CsvSerializable(typeof(CsvParser.Models.MyClass2))]

string csv = CsvSerializer.Serialize([new MyClass2() { String = "b", Integer = 4 }]);

Console.WriteLine(csv);

namespace CsvParser.Models
{
    public class MyClass2
    {
        public string String { get; init; }

        public int Integer { get; init; }
    }
}