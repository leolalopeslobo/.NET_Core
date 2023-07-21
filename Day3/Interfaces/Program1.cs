namespace Interfaces1
{
    internal class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            //Method1
            o.Delete();
            o.Display();
            o.Insert();
            o.Update();

            //Method2 -> refers to the same object but through the interface reference
            IDbFunctions oIDb;
            oIDb = o;  //this makes oIDbpoints this same thing that o points to
            //Here also you only get the methods that are present in the reference type
            oIDb.Delete();
            oIDb.Insert();
            oIDb.Update();
            //This is explicit reference created

            //method1 is most widely used since here we get all the methods


            //Method3
            //Same as method2 just that->this is implicit reference created
            ((IDbFunctions)o).Delete();
            ((IDbFunctions)o).Insert();
            ((IDbFunctions)o).Update();


            //Method4
            //This is identical to Method3
            (o as IDbFunctions).Delete();
            (o as IDbFunctions).Insert();
            (o as IDbFunctions).Update();

        }
    }

    //by converntion, interfaces begin with the letter 'I'
    public interface IDbFunctions
    {
        //the default the access specifier of the methods is public
        void Insert();
        void Update();
        void Delete();
    }

    public class Class1 : IDbFunctions
    {
        public void Display()
        {
            Console.WriteLine("Display from class1");
        }
        public void Delete()
        {
            Console.WriteLine("idb.delete from class1");
        }

        public void Insert()
        {
            Console.WriteLine("idb.insert from class1");
        }

        public void Update()
        {
            Console.WriteLine("idb.update from class1");
        }
    }
}

namespace Interfaces2
{
    internal class Program
    {
        static void Main2()
        {
            Class1 o = new Class1();
            //o.Open();
            //o.Close();
            o.Update();
            o.Display();
            //o.Delete(); 
            o.Insert();
            o.Update();

            (o as IFileFunctions).Delete();
            (o as IFileFunctions).Open();
            (o as IFileFunctions).Close();

            (o as IDbFunctions).Delete();


        }
    }

    //by converntion, interfaces begin with the letter 'I'

    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete();
    }
    public interface IDbFunctions
    {
        //the default the access specifier of the methods is public
        void Insert();
        void Update();
        void Delete();
    }

    public class Class1 : IDbFunctions, IFileFunctions
    {
        public void Display()
        {
            Console.WriteLine("Display from class1");
        }
        //public void Delete()
        //{
        //    Console.WriteLine("idb.delete from class1");
        //}

        void IDbFunctions.Delete()
        {
            Console.WriteLine("idb.delete from class1");
        }

        public void Insert()
        {
            Console.WriteLine("idb.insert from class1");
        }

        public void Update()
        {
            Console.WriteLine("idb.update from class1");
        }

        //void IFileFunctions.Open()
        //{
        //    Console.WriteLine("ifile.open from class1");
        //}

        //void IFileFunctions.Close()
        //{
        //    Console.WriteLine("ifile.close from class1");
        //}

        void IFileFunctions.Delete()  //Explicit Implementation
        {
            Console.WriteLine("ifile.delete from class1");
        }

        public void Open()
        {
            Console.WriteLine("ifile.open from class1");
        }
        public void Close()
        {
            Console.WriteLine("ifile.close from class1");
        }
    }
}

namespace Interfaces3
{

    //With Interfaces also you can get late bound code
    //Also you can get polymorphic code (this is code that looks the same but behaves differently)
    internal class Program
    {
        static void Main1()
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();

            IDbFunctions oIDb;
            oIDb = o1;
            oIDb.Insert();

            oIDb = o2;
            oIDb.Insert();

            Console.ReadLine();

        }

        static void Main()
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();

            InsertMethod(o1);
            InsertMethod(o2);
            Console.ReadLine();
            

        }

        static void InsertMethod(IDbFunctions oIDb) //can receive an object of any class that implements IDbFunctions
        {
            oIDb.Insert();
        }
    }

    //by converntion, interfaces begin with the letter 'I'

    public interface IDbFunctions
    {
        //the default the access specifier of the methods is public
        void Insert();
        void Update();
        void Delete();
    }

    public class Class1 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("idb.delete from class1");
        }

        public void Insert()
        {
            Console.WriteLine("idb.insert from class1");
        }

        public void Update()
        {
            Console.WriteLine("idb.update from class1");
        }
    }

    public class Class2 : IDbFunctions
    {
        public void Delete()
        {
            Console.WriteLine("idb.delete from class2");
        }

        public void Insert()
        {
            Console.WriteLine("idb.insert from class2");
        }

        public void Update()
        {
            Console.WriteLine("idb.update from class2");
        }
    }
}


//Advantages of Interfaces

//Contract - class MUST implement all the interface methods
//similar code in entire project for all developers
//polymorphic code
//design patterns (this haopens when the same code is repeated and then you identify)
