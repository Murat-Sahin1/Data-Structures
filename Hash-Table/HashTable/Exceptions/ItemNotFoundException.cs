namespace HashTable.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        : base($"Given key does does not exist in the Hash Table")
        {

        }
    }
}
