namespace HashTable.HashTableEntities.Common;

public class CollidedHashTableEntry : BaseHashTableEntry
{
    public IHashTableEntry nextEntry { get; set; }
}