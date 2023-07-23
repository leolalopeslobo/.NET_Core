using System.Collections;
namespace Collections
{
    internal class Program
    {
        static void Main1()
        {
            ArrayList objArrayList = new ArrayList();
            objArrayList.Add(1);
            objArrayList.Add("aa");
            objArrayList.Add(true);
            objArrayList.Add(6.7);
            objArrayList.Add(null); //gives a blank result

            foreach (Object i in objArrayList)  //Object since ArrayList consists of a Collection of Objects
            {
                Console.WriteLine(i);
            }

            objArrayList.Remove(1);
            objArrayList.RemoveAt(2);

            Console.WriteLine("Count: "+objArrayList.Count);


            foreach(Object i in objArrayList)  //Object since ArrayList consists of a Collection of Objects
            {
                Console.WriteLine(i);
            }

            ArrayList objArrayList1 = new ArrayList();
            objArrayList1.Add(12);
            objArrayList.Add("aabb");

            objArrayList.AddRange(objArrayList); //Takes ICollection as input
            //This basically helps combine one Collection with another by adding it to the end


            objArrayList.Insert(0, "newItem"); //lets you add an item at that specified index
            objArrayList.InsertRange(0, objArrayList1);  //add at the specified index


            objArrayList.RemoveRange(2, 5);  //index, no of elements -> This tells from where to remove from and how many elements


            objArrayList.AsParallel();  //dont use methods with DownArrow since these are used in LINQ which we will learn


            //Array implements IList
            //objArrayList.IndexOf
            //objArrayList.LastIndexOf
            //objArrayList.BinarySearch

            objArrayList.Clear();  //removes all the objects

            //Arrays makes it null since they are fixed size and they cannot remove everything
            //But ArrayList is dynamic hence you can remove all the items

            //objArrayList.Clone();  //-> ReadUp on Cloning 
            //ReadUp on Shallow Copy and Deep Copy
            //Cloning allows you to make a copy of the object


            bool isPresent = objArrayList.Contains(10);  //returns a boolean and check if the item is present

            //objArrayList.CopyTo(array);  //takes an array so that it can be converted into it
            //Takes the count and datatype is Object

            //objArrayList.ToArray();  //this returns an Object Array   
            //The difference between CopyTo and ToArray is that the first one there needs to be an array created first and second is it returns an array



            objArrayList.GetRange(0, 2); //Gets a subset of the arraylist that starts from index and no of elements


            //If sorting then if similar datatypes then in ascending order
            //If different then it might arrange on the basis od HashCode


            objArrayList.SetRange(0, objArrayList1); //overrides objArrayList with items of objArrayList1



        }

        static void Main2()
        {
            ArrayList arrList = new ArrayList();

            //When you create an ArrayList you have 2 properties that you need know of, One is the Count and Two is the Capacity
            //Initially both the Count and Capacity is 0
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            //Console.ReadLine();
            //Everytime you add an object you have to keep reallocate memory
            //So this might become inefficient if you add memory for only 1 object
            //So to make it more efficient then it adds more memory so you it doesn't have to continuously reallocate memory
            //Capacity basically becomes double
            arrList.Add(6);
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add(7);
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add("aa");
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add(6.7);
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add("bb");
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add(6);
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add(7);
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add("aa");
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add(6.7);
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add("bb");
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");


            //This means there is extra capacity that is added which you might not need
            //So solve this we can use a TrimToSize
            arrList.TrimToSize();
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}");
            arrList.Add("cc");
            Console.WriteLine($"Count={arrList.Count}, Capacity={arrList.Capacity}"); //since it doubles


        }

        static void Main3()
        {
            //HashTable
            Hashtable objDictionary = new Hashtable();

            //it takes keys and values and the keys MUST be unique
            objDictionary.Add(3, "c");
            objDictionary.Add(1, "d");
            objDictionary.Add(4, "r");
            objDictionary.Add(2, "q");

            foreach(DictionaryEntry item in objDictionary) //it is a collection of key-value pairs and there is a class called 'DictionaryEntry' and every dictionaryentry consists of a key-value pairs
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            //Hashtable is a collection of DictionaryEntry objects


            //The hashtable has no fixed way of storing things

            //so instead of a Hashtable, the preferred way is a 'SortedList'

            //SortedList
            //The hashtable is faster than sortedlist (since maybe bcz it's sorting)
            //Sorting is done based on the keys
            //The hashtable gives the values in any order

            Console.WriteLine();
            SortedList objDictionary1 = new SortedList();

            //it takes keys and values and the keys MUST be unique
            objDictionary1.Add(3, "c");
            objDictionary1.Add(1, "d");
            objDictionary1.Add(4, "r");
            objDictionary1.Add(2, "q");

            foreach (DictionaryEntry item in objDictionary1) //it is a collection of key-value pairs and there is a class called 'DictionaryEntry' and every dictionaryentry consists of a key-value pairs
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }


            //There is a property called 'this', that exposes an indexer
            //The Indexer allows you access an object based on the index
            objDictionary1[5] = "new value";  //we are accessing the index; if it doesnt it creates it and if it does then it changes that index value to the one given
            objDictionary1[3] = "changed value";

            Console.WriteLine();
            foreach (DictionaryEntry item in objDictionary1) //it is a collection of key-value pairs and there is a class called 'DictionaryEntry' and every dictionaryentry consists of a key-value pairs
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }

            //objDictionary1.Remove(1);  //(key) - removes the value specified
            //objDictionary1.RemoveAt(1);  //(index) - removes the value at that index


            //objDictionary1.Contains(key) = objDictionary.ContainsKey(key)  //they both do the same
            //objDictionary1.ContainsValue(value);  //checks if this value is present

            //In dictionary you have three things: key, value and index

            //objDictionary1.GetByIndex(index);  //gets value at the specified index
            //objDictionary1.GetKey(index);  //pass index and get the key
            //objDictionary1.GetKeyList(); //returns the list (arraylist) of all the keys -> returns
            //objDictionary1.GetValueList();
            //objDictionary1.IndexOfKey(key);
            //objDictionary1.IndexOfValue(value);  //returns the first index of the specified value

            //objDictionary1.Keys();  //returns ICollection of key list
            //objDictionary1.Values();

            ICollection keys = objDictionary1.Keys;
            ICollection values = objDictionary1.Values;

            foreach (object item in keys)
            {
                Console.WriteLine(item);
            }


            //objDictionary1.SetByIndex(value);  //sets the value at the given index
        }


        static void Main4()
        {
            //STACK
            Stack s = new Stack();
            s.Push("a");

            Console.WriteLine(s.Peek());
            Console.WriteLine(s.Pop());

            //Difference between Pop and Peek
            //The both give the TOP of the stack value only that in Peek it doesnt remove the value whereas in Pop the value is removed



            //QUEUE
            Queue q = new Queue();
            q.Enqueue("b");
            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Dequeue());
        }

        static void Main5()
        {
            //In ArrayList the problem is that we create an ArrayList of different datatypes which is taken as and object which is why this leads to Boxing and Unboxing and is not at all efficient
            //Therefore to solve this we make use of collections that are 'Generic'


            List<int> objList = new List<int>();
            objList.Add(10);
            objList.Add(20);
            objList.Add(30);

            foreach (int item in objList)
            {
                Console.WriteLine(item);
            }


            SortedList<int, string> objSortedList = new SortedList<int, string>();  //key is int and value is string
            objSortedList.Add(3, "a");
            objSortedList.Add(4, "f");
            objSortedList.Add(1, "e");
            objSortedList.Add(2, "u");


            foreach (KeyValuePair<int, string> item in objSortedList)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }




            Stack<int> s = new Stack<int>();


            Queue<string> q = new Queue<string>();



        }


        static void Main()
        {
            //Create a list of Employees
            List<Employee> lstEmp = new List<Employee>();
            lstEmp.Add(new Employee { EmpNo=1, Name="Mary"});
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Jude" });

            foreach (Employee item in lstEmp)
            {
                Console.WriteLine(item.Name);
            }

            //Create a sorted list of Employees
            SortedList<int, Employee> sortedLstEmp = new SortedList<int, Employee>();
            sortedLstEmp.Add(1, new Employee { EmpNo = 1, Name = "Mary" });
            sortedLstEmp.Add(2, new Employee { EmpNo = 2, Name = "Jude" });

            foreach (KeyValuePair<int, Employee> item in sortedLstEmp)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value.EmpNo);
                Console.WriteLine(item.Value.Name);
            }
        }
    }

    public class Employee
    {
        public int EmpNo { get; set;}
        public string? Name { get; set; }
    }
}

//Why use Collections than Arrays
//Since collections are more flexible, they are dynamic, you can add elements at runtime while Arrays are fixed

//There are 2 types of collections
//1. With Generics
//2. Not using Generics


//The Not using Generics
//Found in System.Collections namespace


//All Collections implements the ICollection interface
//ICollection implements/inherits IEnumerable

//IEnumerable has a set of functions/methods that all you to enumerate through a group of objects -> forEach() -> this works only for classes that implemented IEnumerable
//ICollection inherits from IEnumerable, which means it gets all the methods from there
//ICollections gives rise to two other types of Collections: IList and IDictionary

//Difference between IList and IDictionary
//Dictionary has a key and value
//While the List has only values, like arrays



//Whenever you work with Collections you need to remember 3 things:
//- It will have an add() method  or some variation of it
//- It will have an remove() method   or some variation of it
//- It will have an count() method   or some variation of it
//These methods will always be there
