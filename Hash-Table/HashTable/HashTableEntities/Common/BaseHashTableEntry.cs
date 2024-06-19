namespace HashTable.HashTableEntities.Common;

/// <summary>
/// Base entry for HashTable base array.
/// This will be the parent class of two different type of entries,
/// Collided and Normal (Not collided) entries.
/// </summary>
public class BaseHashTableEntry(string? key, object value) : IHashTableEntry
{
    public string? Key { get; init; } = key;
    public object Value { get; set; } = value;
}