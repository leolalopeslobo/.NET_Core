namespace InheritanceOverloadingHidingOverriding
{
    internal class Program
    {

        //How to hide and override
        static void Main1()
        {
            DerivedClass o = new DerivedClass();
            //o.Display1();
            //o.Display1("overloaded");

            //o.Display2();

            //o.Display3();
        }

        //Whats the difference between hiding and overriding
        static void Main()
        {
            BaseClass o1;
            o1 = new BaseClass();
            o1.Display2();  //non virtual function - early bound (depends on declaration of refence)
            o1.Display3();  //virtual function - late bound (depends on object created)

            Console.WriteLine();
            BaseClass o2;
            o2 = new DerivedClass();
            o2.Display2();  //non virtual function - early bound (depends on declaration of refence)
            o2.Display3();  //virtual function - late bound (depends on object created)


            //Display3 is more flexible because it has been decided at runtime which is more flexible and according to which object is created
            //Display2 is more faster because at compile time itself it knows what method to call and the virtual method is much much slower since it has to checkout for what type of object it is pointing to
            //Therefore Virtual methods give 'Flexibilty' and Non Virtual methods give 'Speed'

            Console.WriteLine();
            BaseClass o3;
            o3 = new SubDerivedClass();
            o3.Display2();  //non virtual function - early bound (depends on declaration of refence)
            o3.Display3();  //virtual function - late bound (depends on object created)


            Console.WriteLine();
            BaseClass o4;
            o4 = new SubSubDerivedClass();
            o4.Display2();  //non virtual function - early bound (depends on declaration of refence)
            o4.Display3();  //non virtual function since SEALED - it calls upto the last method that was overridden
        }
    }

    public class BaseClass
    {
        public void Display1()
        {
            Console.WriteLine("Base Display1");
        }
        public void Display2()
        {
            Console.WriteLine("Base Display2");
        }
        public virtual void Display3() //only when marked as virtual then it can be overridden
        {
            Console.WriteLine("Base Display3");
        }
    }


    public class DerivedClass : BaseClass
    {
        //Overload the base class method - same name, different parameters
        public void Display1(string s)
        {
            Console.WriteLine("Derived display1 " + s);
        }


        //Hide the base class method - same name, same parameters (same signature)
        public new void Display2()  //when you use the 'new' keyword the compiler knows that you want to hide the method and the warning disappears
        {
            Console.WriteLine("Derived Display2");
        }

        //override the base class method - same name, same parameters (same signature)
        //ONLY a virtual method can be overridden
        public override void Display3()  //override displays only the virtual methods that can be overridden
        {
            Console.WriteLine("Derived Display3");
        }
    }



    //Overriding an Overridden Method
    //and sealing it so it cannot be override further
    public class SubDerivedClass : DerivedClass
    {
        public sealed override void Display3()
        {
            Console.WriteLine("SubDerived Display3");
        }
    }


    //Overriding not possible since not virtual method anymore
    public class SubSubDerivedClass : SubDerivedClass
    {
        //public override void Display3()  //gives ERROR
        public new void Display3()  //but the method can be hidden
        {
            Console.WriteLine("SubSubDerived Display3");
        }
       
    }
}

//A virtual method
//A method that is bound at run time (late binding/ run time binding/ run time pplymorphism)

//declare refrences of base class
//allocate memory for wither base class or derived class object
//Function to call (base or derived) depends on which object has been created



//In Java by default all methods are Virtual Methods
//But in .Net all methods by default are Non Virtual Methods


//Therefore if you want speed then you need to select .NET
//And if you want to select flexibility then you need to select Java



//sealed - this keyword is used to stop overriding a method further and you stop it from being override further

//sealed override - therefore sealed must only come with override since when we use sealed we make the virtual method a non virtual method
//and all methods are defult by are non-virtual methods and hence using sealed by itself doesn't make sense
