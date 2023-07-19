namespace InheritanceExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseClass o = new BaseClass();
            
            //PUBLIC - avalaible (A)
            //PRIVATE - not avalaible (NA)
            //PROTECTED - not avalaible (NA)
            //INTERNAL - avalaible (A)
            //PROTECTED_INTERNAL - avalaible (A)
            //PRIVATE_PROTECTED - not avalaible (NA)

            DerivedClass o2 = new DerivedClass();
            //o2
            //o2.PUBLIC - avalaible (A)
            //o2.PRIVATE - not avalaible (NA)
            //o2.PROTECTED - avalaible (A)
            //o2.INTERNAL - avalaible (A)
            //o2.PROTECTED_INTERNAL - avalaible (A)
            //o2.PRIVATE_PROTECTED - avalaible (A)            


            TestAccessSpecifiers.BaseClass o3 = new TestAccessSpecifiers.BaseClass();
            //o3
            //o3.PUBLIC - A
            //o3.PRIVATE - NA
            //o3.PROTECTED - NA
            //o3.INTERNAL - NA
            //o3.PROTECTED INTERNAL - NA
            //o3.PRIVATE INTERNAL - NA

        }
    }

    public class BaseClass
    {
        //Access Specifiers

        //public - avalaible everywhere
        //private - same class
        //protected - same class, derived class
        //internal - same class, same assembly (same project)
        //protected internal - same class, derived class, same assembly (same project)
        //private protected - same class, derived class that is in the same assembly


        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;
        private protected int PRIVATE_PROTECTED;
    }

    public class DerivedClass : BaseClass
    {
        public int j;
    }

    public class DerivedClass1 : TestAccessSpecifiers.BaseClass
    {
        public int j;

        //PUBLIC - A
        //PRIVATE - NA
        //PROTECTED - A
        //INTERNAL - NA
        //PROTECTED INTERNAL - A
        //PRIVATE PROTECTED - NA
    }
}


//If you declare something within a class then the default access specifier is 'private' for the members of a class
//At the namespace the default access specifier is 'internal'
