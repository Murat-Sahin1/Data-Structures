using HashTable;

var hashTable = new HashTable.HashTable(10);

var firstTuple = Tuple.Create("Hello", 42, "First", "Tuple!");
var success = hashTable.Set("key1", firstTuple);
Console.WriteLine(success);
var secondTuple = Tuple.Create("Hello", 21, "SECOND", "Tuple!");
var success2 = hashTable.Set("key1", secondTuple);
Console.WriteLine(success2);

// Testing the hash function
/*
int hash = hashTable.hashFunction(Testing");
Console.WriteLine(hash);
*/
