using HashTable.HashTableEntities.Common;

namespace HashTable;

/// <summary>
/// This is an implementation of HashTable.
/// It is designed as following: string key, object value
/// </summary>
public class HashTable
{
    private BaseHashTableEntry[] _baseArray;
    private int _capacity;
    private const int SIZE_MULTIPLIER = 2;
    private const int MIN_SIZE = 5;

    public HashTable(int size)
    {
        if (size < MIN_SIZE) size = MIN_SIZE;

        _capacity = size;
        _baseArray = new BaseHashTableEntry[size];
    }

    public bool Set(string? key, object value)
    {
        if (key == null) return false;

        if (onThreshold()) doubleTheBaseArrayCapacity();

        var arrayIndex = hashFunction(key);

        if (checkCollision(arrayIndex))
        {
            // Last item in the linked list
            var newEntry = new CollidedHashTableEntry
            {
                Key = key,
                Value = value,
                NextEntry = null
            };

            var collidedItem = _baseArray[arrayIndex];
            Type collidedItemType = collidedItem.GetType();

            if (collidedItemType == typeof(NormalHashTableEntry))
            {
                // Turn NormalHashTableEntry into CollidedHashTableEntry
                var newCollidedHashTableEntry = new CollidedHashTableEntry
                {
                    Key = collidedItem.Key,
                    Value = collidedItem.Value,
                    NextEntry = newEntry
                };

                _baseArray[arrayIndex] = newCollidedHashTableEntry;
            }
            else if (collidedItem is CollidedHashTableEntry collidedEntry)
            {
                collidedEntry.AddCollision(newEntry);
            }
        }
        else
        {
            _baseArray[arrayIndex] = new NormalHashTableEntry
            {
                Key = key,
                Value = value
            };
        }

        return true;
    }

    private int hashFunction(string key)
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
        var tempArr = new BaseHashTableEntry[_capacity * SIZE_MULTIPLIER];
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
