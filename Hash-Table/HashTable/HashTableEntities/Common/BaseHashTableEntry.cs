namespace HashTable.HashTableEntities.Common;

/// <summary>
/// Base entry for HashTable base array.
/// This will be the parent class of two different type of entries,
/// Collided and Normal (Not collided) entries.
/// </summary>
public class BaseHashTableEntry : IHashTableEntry
{
    public string? key { get; init; }
    public object value { get; set; }
}