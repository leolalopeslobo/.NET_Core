//using System; //using Directory
//This is a Global Using


namespace ClassBasics
    //What is a namespace?
    //It is nothing but a better way of organising your classes
    //You can have same named classes in different namespaces
    //To refer to a class you can call it by its namespace.className
{
    internal class Programs
    {
        static void Main1()  //string[] args -> for command line arguments
        {
            //Console.WriteLine("Hello, World!");
            // ClassBasics.Program
            //MyNameSpace.n2.Class2
            System.Console.WriteLine("Hello World");
        }

        static void Main2(string[] args)  //string[] args -> for command line arguments
        {
            Class1 o;  //o is a reference of type Class1
            o = new Class1();
            //new Class1() is an object of the class
            //o refers to  (points to) the object created

            //Class1 o1 = new Class1();

            o.Display();
            o.Display("roslyn");


            //optional parameters with default values
            //positional parameters
            o.Add();
            o.Add(1);
            o.Add(1, 2);
            o.Add(1, 2, 3);

            //Remember it is okay to give the right most parameter as optional but no the left most
            //So optional parameters are given from left to right


            //named parameters
            Console.WriteLine(o.Add(c: 3)); //only c is value is given
            Console.WriteLine(o.Add(c:10, a:1));


            //combination of positional and named parameters
            Console.WriteLine(o.Add(10, c: 1));
        }

        //static int Add(int a, int b)
        //{
        //    return a + b;
        //}
        //static int Add(int a, int b, int c)
        //{
        //    return a + b + c;
        //}

        static void Main(string[] args)  //string[] args -> for command line arguments
        {
            Class1 o;
            o = new Class1();

            o.DoSomething();
        }

    public class Class1
    {
        public void Display()
        {
            Console.WriteLine("Display Called");
        }
        //Function Overloading
        public void Display(string s)
        {
            Console.WriteLine("Display Called "+s);
        }

        //optional parameters given from right to left
        public int Add(int a=0, int b=0, int c=0)
        {
            return a + b + c;
        }



        public void DoSomething()
        {
            int i = 100;
            //local function
            //by default a local function is implicitly 'private'
            //therefore it cannot have an access specifier
            //and can only be called from the outer function

            //local functions cannot be overloaded!
            void DoSomethingElse()
            {
                //can access local variables declared in the outer function
                i++;
                Console.WriteLine(i);
            }
            DoSomethingElse();
            Console.WriteLine(i);
        }
    }
}

namespace MyNameSpace
{
    public class Class1 { }

    namespace n2
    {
        public class Class2 { }
        
    }
}
