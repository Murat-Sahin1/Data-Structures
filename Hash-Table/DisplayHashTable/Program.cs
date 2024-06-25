using HashTable;

// Check HashTable class library project for more info and implementation.

var hashTable = new HashTable.HashTable(10);
var test3 = hashTable.hashFunction("k1ey1");


// Test of addition: Normal hash table entry 
var firstTuple = Tuple.Create("1 Hello", 42, "First", "Tuple!");
var success = hashTable.Set("key1", firstTuple);
// var succssess = hashTable.Set("key1", firstTuple);
Console.WriteLine(success);

// Test of reforming: Turning normal hash table entry into collided hash table entry
// Test of addition: Collided hash table entry over collided hash table entry

// Turns normal hash table entry into collided hash table entry
// Creates a new collided entry and adds that into next entry property
// of first collided entry (A linked list is formed)
var secondTuple = Tuple.Create("2 Hello", 21, "SECOND", "Tuple!");
var success2 = hashTable.Set("ke4131y1", secondTuple);
Console.WriteLine(success2);

// Test of addition: Collided hash table entry into a list of collided hash table entries

var thirdTuple = Tuple.Create("3 Hello", 72, "THIRD", "Tuple!");
var success3 = hashTable.Set("k1ey1", thirdTuple);
Console.WriteLine(success3);

// Test of getting: Getting a normal entry

string simpleItem = "Simple item";
var success4 = hashTable.Set("simple", simpleItem);
Console.WriteLine(success4);

var mySimpleItem = hashTable.Get("simple");

// Test of Getting: Getting a collided first entry

// TODO: Let these give Normal Entry
var firstItem = hashTable.Get("key1").entry;

var secondItem = hashTable.Get("ke4131y1").entry;

var thirdItem = hashTable.Get("k1ey1").entry;

var simple = hashTable.Get("simple").entry;

Console.WriteLine(thirdItem);
