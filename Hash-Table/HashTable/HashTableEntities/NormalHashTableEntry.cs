namespace HashTable.HashTableEntities.Common;

public class NormalHashTableEntry(string? key, object value) : BaseHashTableEntry(key, value)
{
    public NormalHashTableEntry() : this(null, null){}
}