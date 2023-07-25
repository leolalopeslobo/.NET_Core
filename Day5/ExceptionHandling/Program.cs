using static ExceptionHandling.Class1;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main0()
        {
            //User Part
            Class1 obj = new Class1();
            obj = null;  //Null Pointer Exception -> System.NullReferenceException
            int x = Convert.ToInt32(Console.ReadLine());  //TypeCasting Exception -> System.FormatException
            obj.P1 = 100/x;  //Arithmetic Exception -> System.DivideByZeroException
            Console.WriteLine(obj.P1);
            Console.ReadLine();
        }

        static void Main1() //Simple try block with catch
        {
            //User Part
            Class1 obj = new Class1();
            try
            {
                //obj = null;  //Null Pointer Exception -> System.NullReferenceException
                int x = Convert.ToInt32(Console.ReadLine());  //TypeCasting Exception -> System.FormatException
                obj.P1 = 100 / x;  //Arithmetic Exception -> System.DivideByZeroException
                Console.WriteLine(obj.P1);
                Console.ReadLine();
            }
            catch
            {
                //Write code to handle exception
                Console.WriteLine("Exception Occured");
            }
        }


        static void Main2() //try block with Multiple catch
        {
            //User Part
            Class1 obj = new Class1();
            try
            {
                obj = null;  //Null Pointer Exception -> System.NullReferenceException
                int x = Convert.ToInt32(Console.ReadLine());  //TypeCasting Exception -> System.FormatException
                obj.P1 = 100 / x;  //Arithmetic Exception -> System.DivideByZeroException
                Console.WriteLine(obj.P1);
                Console.ReadLine();
            }
            catch(DivideByZeroException)
            {
                //Write code to handle exception
                Console.WriteLine("DBZException Occured");
            }
            catch (NullReferenceException)
            {
                //Write code to handle exception
                Console.WriteLine("NRException Occured");
            }
            catch (FormatException)
            {
                //Write code to handle exception
                Console.WriteLine("FException Occured");
            }
            //Base class exception has to be caught after Derived class exceptions
        }


        static void Main3() //try block with Multiple catch and Finally
        {
            //User Part
            Class1 obj = new Class1();
            try
            {
                obj = null;  //Null Pointer Exception -> System.NullReferenceException
                int x = Convert.ToInt32(Console.ReadLine());  //TypeCasting Exception -> System.FormatException
                obj.P1 = 100 / x;  //Arithmetic Exception -> System.DivideByZeroException
                Console.WriteLine(obj.P1);
                Console.ReadLine();
            }
            catch (DivideByZeroException)
            {
                //Write code to handle exception
                Console.WriteLine("DBZException Occured");
            }
            catch (NullReferenceException)
            {
                //Write code to handle exception
                Console.WriteLine("NRException Occured");
            }
            catch (FormatException)
            {
                //Write code to handle exception
                Console.WriteLine("FException Occured");
            }
            //Base class exception has to be caught after Derived class exceptions

            //finally runs when Exception does not occur
            //or exception occurs and is handled or
            //Exception occurs and is NOT handled
            //Therefore, in all situations the finally block runs
            finally
            {
                Console.WriteLine("Finally Block Executed");
            }
            Console.WriteLine("After finally");
        }

        static void Main() //nested try block
        {
            //User Part
            Class1 obj = new Class1();
            try
            {
                //obj = null;  //Null Pointer Exception -> System.NullReferenceException
                int x = Convert.ToInt32(Console.ReadLine());  //TypeCasting Exception -> System.FormatException
                //obj.P1 = 100 / x;  //Arithmetic Exception -> System.DivideByZeroException
                obj.P1 = x;
                Console.WriteLine(obj.P1);
                Console.WriteLine("No Exceptions");
                Console.ReadLine();
            }
            catch (FormatException ex)
            {
                try
                {
                    //Write code to handle exception
                    Console.WriteLine("FException Occured. Enter only numbers");
                    int x = Convert.ToInt32(Console.ReadLine());  //TypeCasting Exception -> System.FormatException
                    obj.P1 = 100 / x;  //Arithmetic Exception -> System.DivideByZeroException
                    Console.WriteLine(obj.P1);
                }
                catch
                {
                    Console.WriteLine("Nested Try Catch Example");
                }
                finally
                {
                    Console.WriteLine("Nested Try Finally Example");
                }

            }
            catch (DivideByZeroException e)
            {
                //Write code to handle exception
                Console.WriteLine("DBZException Occured=> " + e.Message);
            }
            catch (NullReferenceException)
            {
                //Write code to handle exception
                Console.WriteLine("NRException Occured");
            }

            //Custom Exception
            catch (InvalidP1Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            catch (SystemException ex)  //all unhandled exceptions from .net base classes
            {
                Console.WriteLine(ex.Message);
            }

            catch (ApplicationException ex)  //all unhandled user defined exceptions
            {
                Console.WriteLine(ex.Message);
            }




            //Developer handled exception, is thrown which is then caught
            catch (Exception ex)  //all other exceptions that dont inherit from SystemException and ApplicationException
            {
                Console.WriteLine(ex.Message);
            }
            
            //Base class exception has to be caught after Derived class exceptions

            //finally runs when Exception does not occur
            //or exception occurs and is handled or
            //Exception occurs and is NOT handled
            //Therefore, in all situations the finally block runs
            finally
            {
                Console.WriteLine("Finally Block Executed");
            }
            Console.WriteLine("After finally");
        }
    }


    //Developer Part
    public class Class1
    {
        private int p1;

        public int P1
        {
            get { return p1; }
            set { 
                if (value < 100)
                    p1 = value;
                else
                {
                    //throw new Exception("Invalid Number");  //here the developer is handling the exception
                                                            //By throwing an exception
                    throw new InvalidP1Exception("Invalid P1");
                }

            }
        }


        //Creating custom exceptions
        public class InvalidP1Exception : Exception
        {
            public InvalidP1Exception(string message) : base(message)
            {

            }
        }

    }
}


//Every try can have multiple catch but only one finally
