namespace HashTable;

/// <summary>
/// This is a implementation of HashTable.
/// It is designed as following: string key, object value
/// </summary>
public class HashTable
{
    private List<object> baseList;

    public HashTable(int size)
    {
        // TODO: Make this a dynamic array that doubles in size when filled %70
        baseList = new List<object>(size);
    }

    public bool Set(string key, object value)
    {
        throw new NotImplementedException();
    }

private int hashFunction(string key)
    {
        var hash = 0;
        for (var i = 0; i < key.Length; i++)
        {
            hash = (hash + key.ElementAt(i) * i) % baseList.Capacity;
        }
        return hash;
    }
}