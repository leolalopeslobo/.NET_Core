namespace DefaultImplemetationsWithInterfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 o = new Class1();
            o.Insert();
            //o.Select();    //Public Implementation


            (o as IDbFunctions).Select();
        }
    }

    public interface IDbFunctions
    {
        //the default the access specifier of the methods is public
        void Insert();
        void Update();
        void Delete();
        

        //Default Implementation
        void Select()
        {
            Console.WriteLine("Default Implementation code here");
        }
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

        //public void Select()
        //{
        //    Console.WriteLine("Select Implementation from class1");
        //}

        //Explicit Implementation is required when you have 2 interfaces having the same name
        void IDbFunctions.Select()
        {
            Console.WriteLine("Select Implementation from class1-Explicit Implementation");
        }
    }
}

//.Net code is extensible that means all the code is not essentially written by Microsoft but can also use other third-part code
//But then due to this there was lot of code there was lot of new code that was added later which affected the present code that used the updated code
//So they came up with the idea of 'default implementation of method' -> so the present code then doesnt't need to worry about the latest implementation

//But then it also takes us back to the concept of Multiple Inheritance since more than one interface can have the implementation and this leads to the compiler not knowing what code to run!
//but the .Net core came up with a solution for this
