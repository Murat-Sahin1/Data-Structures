using HashTable.HashTableEntities;

namespace HashTable.Utility;

internal static class TypeConverter
{
    internal static NormalHashTableEntry ConvertCollidedToNormal(CollidedHashTableEntry collidedEntry)
    {
        return new NormalHashTableEntry
        {
            Key = collidedEntry.Key,
            Value = collidedEntry.Value
        };
    }
}
