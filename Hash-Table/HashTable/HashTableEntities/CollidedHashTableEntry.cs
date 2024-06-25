using HashTable.HashTableEntities.Common;

namespace HashTable.HashTableEntities;

public class CollidedHashTableEntry(string key, object? value) : BaseHashTableEntry(key, value)
{
    public CollidedHashTableEntry? NextEntry { get; set; }

    public CollidedHashTableEntry() : this(string.Empty, null) { }
}
