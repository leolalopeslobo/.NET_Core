namespace ReferencesAndValues
{
    internal class Program
    {
        static void Main1()
        {
            //Concept of Reference Type
            //(Here it 'points to')

            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            o1.i = 100;
            o2.i = 200;

            o1 = o2;
            //this means o1 = o2 = 200
            o2.i = 300;
            //this means that o1 = o2 = 300

            Console.WriteLine(o1.i); //-> 300
            Console.WriteLine(o2.i); //-> 300

        }

        static void Main2()
        {

            //** Concept of Value Type**
            //(Here it 'copies to')
            int o1, o2;
            o1 = 100;
            o2 = 200;
            o1 = o2;
            o2 = 300;
            Console.WriteLine(o1); //-> 200
            Console.WriteLine(o2); //-> 300

            //(an int is actually a struct)
        }

        static void Main()
        {
            string o1, o2;
            o1 = "100";
            o2 = "200";
            o1 = o2;
            o2 = "300";
            Console.WriteLine(o1); //-> 200
            Console.WriteLine(o2); //-> 300

            //Even though string class is the only exception to the reference type even though it is stored on the HEAP
            //Since string is a most commonly used data type
            //So we don't want if you change one string to change if another string changes

            //In .Net also strings are immutable so it won't change it's value rather it will create a new memory location and point to that
        }
        public class Class1
        {
            public int i;
        }
    }
}
