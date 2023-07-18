namespace ClassBasics
    //What is a namespace?
    //It is nothing but a better way of organising your classes
    //You can have same named classes in different namespaces
    //To refer to a class you can call it by its namespace.className
{
    internal class Program
    {
        static void Main(string[] args)  //string[] args -> for command line arguments
        {
            Console.WriteLine("Hello, World!");
            // ClassBasics.Program 
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
