namespace HashTable;

/// <summary>
/// This is a implementation of HashTable.
/// It is designed as following: string key, object value
/// </summary>
public class HashTable
{
    private HashTableEntry[] _baseArray;
    private int _capacity;

    public HashTable(int size)
    {
        if (size < 5)
        {
            size = 5;
        }
        _capacity = size;
        _baseArray = new HashTableEntry[size];
    }

    public bool Set(string? key, object value)
    {
        if (key == null)
        {
            return false;
        }
        bool onCapacity = checkThreshold();
        var newEntry = new HashTableEntry { key = key, value = value };
        var arrayIndex = hashFunction(newEntry.key);
        // TODO: Handle the collision 💀
        _baseArray[arrayIndex] = newEntry;
        return true;
    }

    private int hashFunction(string? key)
    {
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
    /// <returns>True if the base array threshold is reached.</returns>
    private bool checkThreshold()
    {
        int limit = (int)Math.Ceiling(_capacity * 0.7f);
        if (_baseArray.Length >= limit)
        {
            // Double the size of base array field
            // modify the capacity private field
        }
    }
}