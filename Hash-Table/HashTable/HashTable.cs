using HashTable.HashTableEntities.Common;
using HashTable.HashTableEntities;
using HashTable.Exceptions;

namespace HashTable;

/// <summary>
/// This is an implementation of HashTable.
/// It is designed as following: string key, object value
/// </summary>
public class HashTable
{
    private BaseHashTableEntry[] _baseArray;
    private int _capacity;
    private const int SizeMultiplier = 2;
    private const int MinSize = 5;

    public HashTable(int size)
    {
        if (size < MinSize) size = MinSize;

        _capacity = size;
        _baseArray = new BaseHashTableEntry[size];
    }

    public bool Set(string? key, object value)
    {
        ArgumentNullException.ThrowIfNull(key);

        if (keyExistsInTheMap(key))
            throw new ArgumentException("An element with the same key already exists.");

        if (onThreshold()) doubleTheBaseArrayCapacity();

        var arrayIndex = hashFunction(key);

        if (checkCollision(arrayIndex))
        {
            return handleCollisionAndAddItem(arrayIndex, key, value);
        }
        
        _baseArray[arrayIndex] = new NormalHashTableEntry
        {
            Key = key,
            Value = value
        };
        return true;
    }

    public (BaseHashTableEntry? entry, bool success) Get(string? key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key), "Key cannot be null");

        var hash = hashFunction(key);
        var retrievedItem = _baseArray[hash];

        return handleCollisionAndGetItem(retrievedItem, key);
    }

    public int hashFunction(string key)
    {
        if (key == null)
        {
            throw new NotImplementedException();
        }

        var hash = 0;
        for (var i = 0; i < key.Length; i++)
        {
            hash = (hash + key.ElementAt(i) * i) % _baseArray.Length;
        }

        return hash;
    }

    // TODO: Below two function has handleCollision functionality.
    // This could be refactored into a common method.
    // This also could be a static method.
    private (BaseHashTableEntry? entry, bool success) handleCollisionAndGetItem(BaseHashTableEntry retrievedItem, string? key)
    {
        if (key == null)
            throw new ArgumentNullException($"Key cannot be null: {key}");
        switch (retrievedItem)
        {
            case null:
                throw new ItemNotFoundException();
            case CollidedHashTableEntry collidedEntry:
                return collidedEntry.GetEntryWithKey(key);
            case NormalHashTableEntry:
                return (retrievedItem, true);
            default:
                throw new InvalidCastException();
        }
    }

    private bool handleCollisionAndAddItem(int arrayIndex, string? key, object value)
    {
        ArgumentNullException.ThrowIfNull(key);
        // Last item in the linked list
        var newEntry = new CollidedHashTableEntry
        {
            Key = key,
            Value = value,
            NextEntry = null
        };

        var collidedItem = _baseArray[arrayIndex];

        switch (collidedItem)
        {
            case NormalHashTableEntry:
                {
                    // Turn NormalHashTableEntry into CollidedHashTableEntry
                    var firstItemInCollidedRow = new CollidedHashTableEntry
                    {
                        Key = collidedItem.Key,
                        Value = collidedItem.Value,
                        NextEntry = newEntry
                    };

                    _baseArray[arrayIndex] = firstItemInCollidedRow;
                    return true;
                }
            case CollidedHashTableEntry collidedEntry:
                return collidedEntry.AddCollision(newEntry);
            case null:
                throw new ItemNotFoundException();
            default:
                throw new InvalidCastException();
        }
    }

    private bool keyExistsInTheMap(string key)
    {
        ArgumentNullException.ThrowIfNull(key);

        var retrievedItem = _baseArray[hashFunction(key)];
        switch (retrievedItem)
        {
            case null:
                return false;
            case NormalHashTableEntry:
                {
                    if (retrievedItem.Key == key) return true;
                    return false;
                }
            case CollidedHashTableEntry collidedEntry:
                {
                    var current = collidedEntry;
                    do
                    {
                        if (current.Key == key) return true;

                        current = current.NextEntry;
                    }
                    while (current != null);

                    return false;
                }
            default:
                throw new InvalidCastException();
        }
    }

    /// <summary>
    /// Checks if the base array length reached the threshold capacity.
    /// Which is set to %70 of array capacity. This might not be the best option.
    /// Implementing a percentage that's smaller with low array capacities is better.  
    /// </summary>
    /// <returns> True if the base array threshold is reached.</returns>
    private bool onThreshold()
    {
        var limit = (int)Math.Ceiling(_capacity * 0.7f);
        return _baseArray.Length <= limit;
    }

    private void doubleTheBaseArrayCapacity()
    {
        var tempArr = new BaseHashTableEntry[_capacity * SizeMultiplier];
        copyBaseArrayToNew(tempArr);
        _baseArray = tempArr;
        _capacity = _baseArray.Length;
    }

    private void copyBaseArrayToNew(IList<BaseHashTableEntry> tempArr)
    {
        for (var i = 0; i < _baseArray.Length; i++)
        {
            tempArr[i] = _baseArray[i];
        }
    }

    private bool checkCollision(int newIndex)
    {
        var retrievedItem = _baseArray[newIndex];
        return retrievedItem != null;
    }
}
