namespace AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AbstractBaseClass1 obj = new AbstractBaseClass1();  //ERROR since we cannot create an object of an abstract class
            DerivedClass1 obj = new DerivedClass1(); //We can create an object of the derived class that is inherited from an Abstract Class
        }
    }

    //Abstract Class having normal methods
    public abstract class AbstractBaseClass1
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }
    }

    public class DerivedClass1 : AbstractBaseClass1
    {

    }

    //Abstract Class having abstract methods
    public abstract class AbstractBaseClass2
    {
        public abstract void Display();
        public abstract void Show();
    }

    public class DerivedClass2 : AbstractBaseClass2
    {
        public override void Display()
        {
            Console.WriteLine("DerivedClass2 : AbstractBaseClass2 -> Display");
        }

        public override void Show()
        {
            Console.WriteLine("DerivedClass2 : AbstractBaseClass2 -> Show");
        }
    }

    public abstract class DerivedClass3 : AbstractBaseClass2
    {
        public override void Display()
        {
            Console.WriteLine("DerivedClass2 : AbstractBaseClass2 -> Display");
        }

        //In case we don't have to define Show() then the only way out is to make the present class abstract
    }


}

//By default all abstract functions are pure virtual functions

//One main difference between Abstract Methods and Virtual Methods
//Is that
//An Abstract Method must compulsorily be overridden and a Virtual Method need not be overridden



/*
                        can instantiate         can be used as a base class
abstract class              NO                              YES
sealed class                YES                             NO

 */

//A sealed class is the exact oopposite of an abstract class
