//using System; //using Directory
//This is a Global Using


namespace ClassBasics
    //What is a namespace?
    //It is nothing but a better way of organising your classes
    //You can have same named classes in different namespaces
    //To refer to a class you can call it by its namespace.className
{
    internal class Program
    {
        static void Main1()  //string[] args -> for command line arguments
        {
            //Console.WriteLine("Hello, World!");
            // ClassBasics.Program
            //MyNameSpace.n2.Class2
            System.Console.WriteLine("Hello World");
        }

        static void Main(string[] args)  //string[] args -> for command line arguments
        {
            Class1 o;  //o is a reference of type Class1
            o = new Class1();
            //new Class1() is an object of the class
            //o refers to  (points to) the object created

            //Class1 o1 = new Class1();

            o.Display();
        }
    }

    public class Class1
    {
        public void Display()
        {
            Console.WriteLine("Display Called");
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
