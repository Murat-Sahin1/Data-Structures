namespace HashTable.HashTableEntities.Common;

public class CollidedHashTableEntry(string? key, object value) : BaseHashTableEntry(key, value)
{
    public CollidedHashTableEntry? NextEntry { get; set; }
    public CollidedHashTableEntry() : this(null, null) { }

    public bool AddCollision(CollidedHashTableEntry newEntry)
    {
        if (newEntry == null) return false;

        CollidedHashTableEntry current = this;

        while (current.NextEntry != null)
        {
            current = current.NextEntry;
        }
        current.NextEntry = newEntry;
        return true;
    }
}
