using HashTable.HashTableEntities.Common;

namespace HashTable.HashTableEntities;

public class CollidedHashTableEntry(string? key, object value) : BaseHashTableEntry(key, value)
{
    public CollidedHashTableEntry? NextEntry { get; set; }
    public CollidedHashTableEntry() : this(null, null) { }

    // Below two method increases the Hash Table base array size.
    // These two could be moved to the Hash Table class.
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

    public (CollidedHashTableEntry? entry, bool success) GetEntryWithKey(string? key)
    {
        CollidedHashTableEntry current = this;

        do
        {
            if (current.Key == key)
            {
                return (current, true);
            }

            if (current.NextEntry == null) return (null, false);

            current = current.NextEntry;
        }
        while (current != null);

        return (null, false);
    }
}
