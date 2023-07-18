namespace StaticMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Every object gets a copy of i
            Class1 o1 = new Class1();  //here both constructors are called -> first static constructor and then the normal constrcutor
            o1.i = 10;

            Class1 o2 = new Class1();
            o2.i = 10;

            Class1.static_i = 100;

            o1.Display();
            Class1.static_Display();


            //accessing static property
            Class1.static_i = 10;
        }
    }

    public class Class1
    {

        public Class1()
        {
            Console.WriteLine("non static constructor");
        }

        //static constructor
        //it is implicity private - why?
        static Class1()
        {
            //used to initialize static members
        }

        public int i;

        //static variable
        //single copy - shared data
        public static int static_i;  

        //static property
        public static int Static_I
        {
            set
            {
                if (value < 100)
                    static_i = value;
                else
                    Console.WriteLine("Invalid i");
            }
        }


        public void Display()
        {
            Console.WriteLine("Display");
            Console.WriteLine(i); //no ambiguity therefore accessible
            Console.WriteLine(static_i); //no ambiguity therefore accessible
        }
        //static method
        //call method without creating object
        public static void static_Display()
        {
            Console.WriteLine("Static Display");
            Console.WriteLine(static_i); //no ambiguity therefore accessible
            //Console.WriteLine(i);  //here there is ambiguity since here we don't know which object it refers to  => therfore Error!
        }
    }
}

//Why have static variable?
//This field is created to have common variable for all objects

//Why have static method?
//This is inorder to call the method without creating an object and is not related to object data
//So methods which are general purpose and not related to any object data

//You can access non-static data from a non-static method

//Can you access static data inside non-static method
//Yes

//Can you access non-static data inside static method
//No, since we don't know the reference of which object it is


//Therefore static methods can only access static members


//Why create a static variable?
//To create a single data

//Why create a property?
//For validation

//Why create a static property?
//To create a single copy with validation



//Why create a constructor?
//To initialize data members of that object

//Why have a static constructor?
//To initialise static data members

//Static constructor is called only ONCE

//When is the static constructor called?
//When the class is loaded


//When is the class loaded?
//When the '_FIRST_' object is created OR when the '_FIRST_' static member is initialized (or accessed)

//Where is the class loaded?
//In the CLR

//The static constructor is ALWAYS implicitly called

//Can we pass parameters to a static constructor
//No, since we can't call it as it is implicitly called
//Therefore it is parameterless
//And therefore it cannot be OVERLOADED



//Creating a static class
//Static class can only have static members
//It cannot be initiantiated (ie object of the class cannot be created)
//It also cannot be used as a base class ie you cannot inherit from a static class
//All general purpose methods are used in a static class
//Eg: Console class is a static class
