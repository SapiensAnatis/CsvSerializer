namespace CsvParser.SourceGenerator;

internal sealed record CsvSerializableDeclaration(
    string QualifiedTypeName,
    string ShortTypeName,
    EquatableReadOnlyList<Property> Properties)
{
    public string GetSerializeMethodName() => $"Serialize_{this.ShortTypeName}";
}

internal sealed record Property(string Name, bool IsUseSet);