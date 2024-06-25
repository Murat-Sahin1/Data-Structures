using HashTable.HashTableEntities.Common;

namespace HashTable.HashTableEntities;

public class NormalHashTableEntry(string key, object? value) : BaseHashTableEntry(key, value)
{
    public NormalHashTableEntry() : this(string.Empty, null) { }
}
