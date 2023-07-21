//LAB Work

//TO DO
//Create an interface (I1)
//Create a 2nd interface that inherits from I1

//I1 - M2()

//I2: I1
//M2()


//C1: M2


namespace InheritanceInInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            C1 o = new C1();
            o.M1();
            o.M2();
        }
    }

    public interface I1
    {
        //the default the access specifier of the methods is public
        void M1();
    }

    public interface I2 : I1
    {
        //the default the access specifier of the methods is public
        void M2();
    }

    public class C1 : I2
    {
        public void M1()
        {
            Console.WriteLine("C1-M1");
        }

        public void M2()
        {
            Console.WriteLine("C1-M2");
        }
    }

}
