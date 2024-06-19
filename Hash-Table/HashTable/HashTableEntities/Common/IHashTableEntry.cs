namespace HashTable.HashTableEntities.Common;

/// <summary>
/// This is designed to be implemented by a base class,
/// </summary>
public interface IHashTableEntry
{
   string? key { get; init; }
   object value { get; set; }
}