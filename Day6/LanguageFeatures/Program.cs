namespace LanguageFeatures
{
    internal class Program
    {
        static void Main0(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}


namespace ImplicitVariables
{
    //1st Language Feature
    internal class Program
    {
        static void Main1()
        {
            //int i = 0;  //Explicit Variable
            var i = 0; //Implicit Variable
            //i = "ss";  //ERROR since now i cannot be converted from int to string
            //used only for Local Variables => WHY?
            //can't be used for class level vars, fn params and return types => WHY?
            Console.WriteLine(i);
            Console.WriteLine(i.GetType());
            Console.WriteLine(i.GetType().ToString());
        }
    }
}

namespace AnonymousTypes
{
    //2nd Language Feature -> Anonymous Types
    internal class Program
    {
        static void Main2()
        {
            //Class1 o = new Class1{a=10,b="aaa",c=1.2};  //Object Initializer
            //var o = new { a = 10, b = "aaa", c = 1.2 };

            var o = new { Id = 10, Name = "aaa", Salary = 1.2 };
            var o2 = new { Id = 11, Name = "bbb", Salary = 3.2, IsRetired = true };
            var o3 = new { Id = 11, Name = "bbb", Salary = 3.2, IsRetired = false };

            Console.WriteLine(o);
            Console.WriteLine(o.Id);
            Console.WriteLine(o.GetType());
            Console.WriteLine(o2.GetType());
            Console.WriteLine(o3.GetType());


            //To see code in Assembly you make use of ILDASM
        }
    }
}

namespace PartialClasses
{
    //3rd Language Feature -> Partial Classes

    //PARTIAL CLASSES
    //partial classes must be in the same assembly (assembly = project)
    //partial classes must be in the same namespace
    //partial classes must have the same name

    public partial class Class1
    {
        public int i;
    }

    public partial class Class1
    {
        public int j;
    }
    internal class Program
    {
        static void Main3()
        {
            Class1 o = new Class1();
            //o.  //gives you both i and j and k too
            //And even l which is in a different class file
        }
    }
}

namespace PartialClasses
{
    //3rd Language Feature -> Partial Classes

    //PARTIAL CLASSES
    //partial classes must be in the same assembly (assembly = project)
    //partial classes must be in the same namespace
    //partial classes must have the same name

    public partial class Class1
    {
        public int k;
    }
}

namespace PartialMethods
{
    //4th Language Feature -> Partial Methods


    //Rules for Partial Methods
    //Partial Methods can only be defined within a partial class
    //Partial Methods must return void
    //Partial mthids can be static or instance level
    //Partial methods cannot have out params
    //Partial methods are always implicitly private

    internal class Program
    {
        static void Main5()
        {
            Class1 o = new Class1();
            Console.WriteLine(o.Check());
            
        }
    }

    //1st partial class present from the beginning
    public partial class Class1
    {
        private bool isValid = true;

        partial void Validate();

        public bool Check()
        {
            //...
            Validate();  //calling the partial method
            return isValid;
        }
    }

    //2nd partial class created much later and the code is written for the partial method
    public partial class Class1
    {
        partial void Validate()
        {
            //perform some validation code here
            Console.WriteLine("Code for Partial Method is written");
            isValid = false;
        }
    }
}

namespace ExtensionMethods
{
    //5th Language Feature -> Extension Method
    internal class Program
    {
        static void Main05()
        {
            int i = 100;
            i.Display(); //extension method
            Console.WriteLine();

            string s = "ABC";
            s.Show();
            Console.WriteLine();

            i = i.Add(5);
            i.Display();
        }

        static void Main15()
        {
            int i = 100;
            i = MyExtensionClass.Add(i,5);
            MyExtensionClass.Display(i);
            //This is how the compiler converts the extensions into normal way of calling

            i.ExtMethodForObjectClass();
        }

        static void Main()
        {
            ClsMaths obj = new ClsMaths();
            Console.WriteLine(obj.Add(1, 2));
            Console.WriteLine(obj.Multiply(1, 2));
            Console.WriteLine(obj.Subtract(2, 1));  //Coming from the extension method
        }
    }

    //Creating an extension method
    //- Create a static method in a static class
    //- The firts parameter must be the type for which you are writing the extension method, preceeded by the 'this' keyword
    public static class MyExtensionClass
    {
        //extension method
        public static void Display(this int i)
        {
            Console.WriteLine(i);
        }
        public static void Show(this string i)
        {
            Console.WriteLine(i);
        }

        public static int Add(this int i, int x) //first to tell for which variable and the second is the parameter given
        {
            return i += x;
        }


        //If you add an extension for the base class that method will also be avalaible for the derived
        public static void ExtMethodForObjectClass(this object o) 
        {
            //Here the extension method is added for the object class
            Console.WriteLine(o);
        }

        public static int Subtract(this IMathOperations oIMath, int a, int b)
        {
            return a - b;
        }
    }


    public interface IMathOperations
    {
        int Add(int a, int b);

        int Multiply(int a, int b);
    }

    public class ClsMaths : IMathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
