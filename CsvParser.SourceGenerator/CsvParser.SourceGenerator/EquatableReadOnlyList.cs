/*
 * Borrowed from
 * https://github.com/ImmediatePlatform/Immediate.Handlers/blob/3a342aad4bce65c8755e40bef3972ab864658778/src/Immediate.Handlers.Generators/EquatableReadOnlyList.cs
 * under MIT license
 */

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace CsvParser.SourceGenerator;

[ExcludeFromCodeCoverage]
internal static class EquatableReadOnlyList
{
    public static EquatableReadOnlyList<T> ToEquatableReadOnlyList<T>(this IEnumerable<T> enumerable)
        => new(enumerable.ToArray());
}

/// <summary>
///     A wrapper for IReadOnlyList that provides value equality support for the wrapped list.
/// </summary>
[ExcludeFromCodeCoverage]
internal readonly struct EquatableReadOnlyList<T>(
    IReadOnlyList<T>? collection
) : IEquatable<EquatableReadOnlyList<T>>, IReadOnlyList<T>
{
    private IReadOnlyList<T> Collection => collection ?? [];

    public bool Equals(EquatableReadOnlyList<T> other)
        => this.SequenceEqual(other);

    public override bool Equals(object? obj)
        => obj is EquatableReadOnlyList<T> other && Equals(other);

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var item in Collection)
            hashCode.Add(item);

        return hashCode.ToHashCode();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
        => Collection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => Collection.GetEnumerator();

    public int Count => Collection.Count;
    public T this[int index] => Collection[index];

    public static bool operator ==(EquatableReadOnlyList<T> left, EquatableReadOnlyList<T> right)
        => left.Equals(right);

    public static bool operator !=(EquatableReadOnlyList<T> left, EquatableReadOnlyList<T> right)
        => !left.Equals(right);
}