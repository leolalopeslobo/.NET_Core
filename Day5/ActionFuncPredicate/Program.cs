namespace ActionFuncPredicate
{
    internal class Program
    {
        static void Main1()
        {
            //Action
            //Used to call function that are of void return type and no parameters
            Action o1 = Display;
            o1();

            //If it has one parameters then
            Action<string> o2 = Display; //the method in taking in one parameter called string
            o2("aa");

            //Therefore Action takes upto 16 parameters and return type is void
            Action<string, int> o3 = Display;
            o3("bb", 2);

        }

        static void Main2()
        {
            //-------------------------
            //What if you want to call a function that has a return type, then you need to use Func
            //Func is used to call functions that have a return type
            Func<string> f1 = GetNow;
            Console.WriteLine(f1());


            //if function has a parameter - this is also carries upto 16 parameters
            //In Func the return parameter are always given last
            Func<int, int> f2 = GetDouble;
            Console.WriteLine(f2(3));

            Func<int,int,int>  f3 = Add;
            Console.WriteLine(f3(10, 5));

            Func<int, bool> f4 = IsEven;
            Console.WriteLine(f4(5));

        }

        static void Main()
        {
            //A function with return as 'bool' and parameter is only 1
            //We can use 'Predicate' for it instead of Func
            Predicate<int> p1 = IsEven; //you don't have to pass the out since it's understood that we will get a bool return type


            Func<Employee,bool> p2 = IsBasicGreaterThan1000;
            Predicate<Employee> p3 = IsBasicGreaterThan1000;
            Employee e = new Employee { basic=2345 };
            Console.WriteLine(p3(e));

        }
        static void Display()
        {
            Console.WriteLine("Display Called");
        }
        static void Display(string s)
        {
            Console.WriteLine("String Display Called");
        }

        static void Display(string s, int i)
        {
            Console.WriteLine("Display Called"+s+i);
        }

        static string GetNow()
        {
            return DateTime.Now.ToShortTimeString();
        }

        static int GetDouble(int a)
        {
            return a * 2;
        }

        static void Show()
        {
            Console.WriteLine("Show Called");
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static bool IsEven(int i)
        {
            if (i % 2 == 0) return true;
            else return false;
        }

        static bool IsBasicGreaterThan1000(Employee a)
        {
            return (a.basic > 1000);
        }
    }

    public class Employee
    {
        public int basic { get; set;}

    }


}

//We know that for every different signature methods you will have to create different delegate classes
//Therfore we will have multiple delegate classes
//So instead .Net gives in-built delegate classes that can be used
//So here we use these and they are Action, Func and Predicate
