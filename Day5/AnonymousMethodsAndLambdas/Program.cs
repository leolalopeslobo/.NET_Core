namespace AnonymousMethodsAndLambdas1
{
    internal class Program
    {
        static void Main1()
        {
            int i = 100;
            //Anonymous means someone who don't know
            //Therefore an Anonymous Method is a method that doesn't have a name
            //The only way of calling Anonymous Methods is by using Delegates
            Action o = delegate ()
            {
                i++;
                Console.WriteLine("Anonymous Method Called");
            };
            o();
            Console.WriteLine(i);

            //Why do we need Anonymous Methods?
            //Have you seen in .Net where you write a method inside another method -> Local Functions
            //A local function can access the variable in the local scope
            //Similar Anonymous functions are useful for this


            //Add Anonymous Function
            Func<int, int, int> o1 = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine(o1(2, 5));


            Predicate<int> o2 = delegate(int a)
            {
                return a % 2 == 0;
            };
            Console.WriteLine(o2(2));

        }
    }
}




namespace AnonymousMethodsAndLambdas2
{
    internal class Program
    {
        static void Main()
        {
            //Using Delegates
            Func<int, int> o1 = GetDouble;
            Console.WriteLine(o1(10));

            //Using Anonymous Function
            Func<int, int> o2 = delegate (int a)
            {
                return a * 2;
            };
            Console.WriteLine(o2(3));


            //Using Lambda
            Func<int, int> o3 = (a) => a * 2;
            Console.WriteLine(o3(3));
            Func<int, int> o4 = a => a * 2;
            Console.WriteLine(o4(3));

            //If we have zero or more than one parameter then we need to use the parenthesis
            //Else if we have only one parameter than we don't require the parenthesis

            Func<int, int, int> add = (a, b) => a + b;
            Func<int, int, int> sub = (a, b) => a - b;
            Predicate<int> isEv = n => n % 2 == 0;
            Predicate<Employee> isBscGreaterThan1000 = e => e.basic > 1000;
            Func<string> getNw = () => DateTime.Now.ToShortTimeString();

            //When you think of Lambda, think of KISS (Keep It Short and Sweet)
        }

        static int GetDouble(int a)
        {
            return a * 2;
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

        static string GetNow()
        {
            return DateTime.Now.ToShortTimeString();
        }
    }
    public class Employee
    {
        public int basic { get; set; }

    }
}
