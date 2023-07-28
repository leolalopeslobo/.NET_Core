using System.Threading;

namespace ThreadingExample1
{
    //Non Parameterized Threads
    //All the classes required for Threading are in the System.Threading namespace
    internal class Program
    {
        static void Main1(string[] args)
        {
            //Calling Without Threading
            Func1();
            Func2();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main: " + i);
            }
        }

        static void Main2(string[] args)
        {
            //Calling With Threading
            //Starting the functions on separate threads
            //To do that you create an object of the thread class
            Thread t1 = new Thread(new ThreadStart(Func1));  //creating the thread
            Thread t2 = new Thread(Func2);
            
            t1.Start();  //start the thread
            t2.Start();

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
                //Console.WriteLine($"Main: i={i} Id={Thread.CurrentThread.ManagedThreadId} ProcId={Thread.GetCurrentProcessorId()}");
            }

            //Who is managing the threads?
            //The CLR is responsible for Thread Management

            //All .Net code managed by the CLR is all Managed code
        }

        static void Main3(string[] args)
        {
            //Calling With Threading
            //Starting the functions on separate threads
            //To do that you create an object of the thread class
            Thread t1 = new Thread(new ThreadStart(Func1));  //creating the thread
            Thread t2 = new Thread(Func2);
           

            t1.Start();  //start the thread
            t2.Start();

            for (int i = 0; i < 1; i++)  //What if the main thread has fewer iterations? => Then technically it should finish first
            {
                Console.WriteLine("Main: "+i);
                //Console.WriteLine($"Main: i={i} Id={Thread.CurrentThread.ManagedThreadId} ProcId={Thread.GetCurrentProcessorId()}");
            }

            //Who is managing the threads?
            //The CLR is responsible for Thread Management

            //All .Net code managed by the CLR is all Managed code
        }

        static void Main4(string[] args)
        {
            //BackGround Thread
            Thread t1 = new Thread(new ThreadStart(Func1));  //creating the thread
            Thread t2 = new Thread(Func2);

            //making them background threads
            t1.IsBackground = true; t2.IsBackground = true;

            t1.Start();  //start the thread
            t2.Start();

            for (int i = 0; i < 1; i++)  //What if the main thread has fewer iterations? => Then technically it should finish first
            {
                Console.WriteLine("Main: " + i);
                //Console.WriteLine($"Main: i={i} Id={Thread.CurrentThread.ManagedThreadId} ProcId={Thread.GetCurrentProcessorId()}");
            }

            //Who is managing the threads?
            //The CLR is responsible for Thread Management

            //All .Net code managed by the CLR is all Managed code
        }

        static void Main5(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Func1));  //creating the thread
            Thread t2 = new Thread(Func2);


            t1.Start();  //start the thread
            t2.Start();

            for (int i = 0; i < 50; i++)  //What if the main thread has fewer iterations? => Then technically it should finish first
            {
                Console.WriteLine("Main: " + i);
                //Console.WriteLine($"Main: i={i} Id={Thread.CurrentThread.ManagedThreadId} ProcId={Thread.GetCurrentProcessorId()}");
            }
            t1.Join(); //waiting call -> this will wait until Func1 and then the next line is executed
            Console.WriteLine("This code should be called after Funct1 is over"); 
        }

        static void Main6(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Func1));  //creating the thread
            Thread t2 = new Thread(Func2);
            //By default the CLR takes care of the entire running and execution
            //But say you want to give more or less priority
            t1.Priority = ThreadPriority.Highest; t2.Priority = ThreadPriority.Lowest;  //this is a request made to the CLR
                                                                                        //It may or may not obey

            t1.Start();  //start the thread
            t2.Start();

            for (int i = 0; i < 50; i++)  //What if the main thread has fewer iterations? => Then technically it should finish first
            {
                Console.WriteLine("Main: " + i);
                //Console.WriteLine($"Main: i={i} Id={Thread.CurrentThread.ManagedThreadId} ProcId={Thread.GetCurrentProcessorId()}");
            }
            t1.Join(); //waiting call -> this will wait until Func1 and then the next line is executed
            Console.WriteLine("This code should be called after Funct1 is over");
        }

        static void Main7(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Func1));  //creating the thread
            Thread t2 = new Thread(Func2);
            
            t1.Priority = ThreadPriority.Highest; t2.Priority = ThreadPriority.Lowest; 


            if(t1.ThreadState == ThreadState.Unstarted) 
            {
                t1.Start();
            }
            if (t1.ThreadState == ThreadState.Unstarted)
            {
                t2.Start();
            }

            t1.Start();

            //t1.Suspend(); //pauses the thread temporarily
            //t1.Resume();
            //t1.Abort();

            //Suspend, Resume and Abort are all deprecated!
            //if (t1.ThreadState == ThreadState.)

            for (int i = 0; i < 50; i++) 
            {
                Console.WriteLine("Main: " + i);
                //Console.WriteLine($"Main: i={i} Id={Thread.CurrentThread.ManagedThreadId} ProcId={Thread.GetCurrentProcessorId()}");
            }
            t1.Join(); //waiting call -> this will wait until Func1 and then the next line is executed
            Console.WriteLine("This code should be called after Funct1 is over");
        }

        static void Main8(string[] args)
        {

            //ThreadState -> WaitSleepJoin
            Thread t1 = new Thread(new ThreadStart(Func1));  //creating the thread
            Thread t2 = new Thread(Func2);


            t1.Start();  //start the thread
            t2.Start();

            for (int i = 0; i < 50; i++)  
            {
                Console.WriteLine("Main: " + i);
                Thread.Sleep(2000);  //here the main thread is waiting for 1s (will do nothing for 1s)
            }
            //t1.Join(); //waiting call -> this will wait until Func1 and then the next line is executed, main thread is waiting for t1
            //Console.WriteLine("This code should be called after Funct1 is over");
        }

        static void Main9(string[] args)
        {

            //Wait 
            //An alternate way of doing a Suspend or Resume
            AutoResetEvent wh = new AutoResetEvent(false); //creating a waithandle that initially false that means it should not wait
            Thread t1 = new Thread(delegate () //using anonymous method
            {
                for (int i = 0; i < 200; i++)
                {
                    Console.WriteLine("f1: " + i);
                    if (i % 50 == 0)
                    {
                        //instead of Suspend, use this
                        Console.WriteLine("waiting");
                        wh.WaitOne();

                        //While you are doing a WaitOne() the ThreadState is WaitSleepJoin
                    }
                }
            });
            t1.Start();

            //Thread.Sleep(5000);
            Console.ReadLine();
            Console.WriteLine("resuming 1....");
            wh.Set();

            //Thread.Sleep(5000);
            Console.ReadLine();
            Console.WriteLine("resuming 2....");
            wh.Set();

            //Thread.Sleep(5000);
            Console.ReadLine();
            Console.WriteLine("resuming 3....");
            wh.Set();

            //Thread.Sleep(5000);
            Console.ReadLine();
            Console.WriteLine("resuming 4....");
            wh.Set();


            //What do Anonymous Methods give that Regular Methods dont give
            //Anonymous Methods can access variables from outside
        }
        static void Func1()
        {
            for(int i= 0; i < 50; i++)
            {
                Console.WriteLine("First: " + i);
                Thread.Sleep(2000);
            }
        }

        static void Func2()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("Second: " + i);
                Thread.Sleep(2000);
            }
        }
    }
}

namespace ThreadingExample2
{
    //Parameterized Threads
    //All the classes required for Threading are in the System.Threading namespace
    internal class Program
    {
        static void Main1()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            Thread t2 = new Thread(Func2);


            //t1.Start("string1");
            //t2.Start(10);

            //Possibilities to pass multiple values to a function called on another thread
            //- Array/Collection
            int[] arr = new int[2];
            arr[0] = 10;
            arr[1] = 11;
            t1.Start(arr);


            //- Create a class/struct which contains properties matching parameters -- pass an object of the class
            //Difference between class and struct
            //Class is reference type and supports inheritance
            //Struct is value type and no inheritance
            //Anonymous Method or a Local Function or a Lambda Function - and access variables declared in calling code
        }

        static void Main2()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            Thread t2 = new Thread(Func2);


            //- Create a class/struct which contains properties matching parameters -- pass an object of the class
            Class1 obj = new Class1{ P1=20, P1Name = "sunny"};
            t1.Start(obj);
            //Difference between class and struct
            //Class is reference type and supports inheritance
            //Struct is value type and no inheritance
            //Anonymous Method or a Local Function or a Lambda Function - and access variables declared in calling code
        }

        static void Main3()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));

            //Anonymous Method or a Local Function or a Lambda Function - and access variables declared in calling code
            int x = 10;
            string name = "rose";
            t1.Start(new { X = x, Name = name });
        }

        static void Func1(object o)
        {
            var anonymousType = (dynamic)o;
            int x = anonymousType.X;
            string name = anonymousType.Name;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First: " + i + ", " + x + ", " + name);
            }
        }

        static void Func2(object o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second: " + i+o);
            }
        }
    }

    public class Class1
    {
        public int P1 { get; set; }
        public string? P1Name; //{ get; set; }
    }
}

namespace ThreadingExample3
{
    //ThreadPool
    class MainClass
    {
        static void PoolFunc1(object o)
        {
            for (int i=0; i<10000; i++)
            {
                Console.WriteLine("First Thread "+i.ToString() +o.ToString());
            }
        }

        static void PoolFunc2(object o)
        {
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString());
            }
        }

        static void Main0()
        {
            //Why have a queue?
            //For maintaining the sequence
            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1), "aaa");
            //ThreadPool.QueueUserWorkItem(PoolFunc1, "aaa"); //Calling PoolFunc1 and passing aaa


            //ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1));
            //ThreadPool.QueueUserWorkItem(PoolFunc2);  //Default value of an object is null

            //To pass multiple parameters do the same thing as before

            //for(int i = 0; i < 1; i++)
            //{
            //    Console.WriteLine("Main Thread " + i.ToString());
            //}
            int workerthreads, iothreads;


            //This tells how many workerthreads are there and how many iothreads are there
            //workerthreads are threads that you are creating out
            //iothreads are the threads that are internally used for io operations done by .Net
            //ThreadPool.GetAvailableThreads(out workerthreads, out iothreads);
            //ThreadPool.SetMinThreads
            //ThreadPool.SetMaxThreads
            ThreadPool.GetMinThreads(out workerthreads, out iothreads);
            //ThreadPool.GetMaxThreads(out workerthreads, out iothreads);
            Console.WriteLine(workerthreads);
            Console.WriteLine(iothreads);

            Console.ReadLine(); //If this is not present then the main thread is working as a BackGround Thread

            //Therefore, by default when you create a thread from a ThreadPool they are Backgound Threads


            //32766 - usual number of worker threads
            //1000 - no of io threads present
        }
    }
}

namespace ThreadingExample4
{
    class MainClass
    {
        //Synchronization

        static object lockObject = new object();
        static int i = 0;
        static void Main()
        {
            Thread t1 = new Thread(new ThreadStart(FuncLock));
            Thread t2 = new Thread(new ThreadStart(FuncMonitor));
            //Thread t3 = new Thread(new ThreadStart(FuncInterlocked));
            t1.Start();
            t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            Console.WriteLine("Finished Main");
            Console.ReadLine();
        }

        static void FuncLock()
        {

            lock (lockObject)
            {
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                //-----------------------------
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
            }
       
        }


        static void FuncMonitor()
        {
            Monitor.Enter(lockObject);
            {
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                //-----------------
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
            }
            Monitor.Exit(lockObject);
        }


        static void DoSomething()
        {
            i = i + i;
        }


//        Instead of using multiple lock statements you have a class called 'Interlocked'

//This will be used for Thread Safe Synchronised Code, making sure that if there is an arithmetic operation that you want to perform than in the middle of that operation nobody else gets control

        static void FuncInterlocked()
        {
            Interlocked.Add(ref i, 10);  //i+=10
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Increment(ref i);  //++i
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Decrement(ref i);  //--i
            Console.WriteLine("Third Interlocked " + i.ToString());

            Interlocked.Exchange(ref i, 100);  //i = 100
            Console.WriteLine("Third Interlocked " + i.ToString());

        }
    }
    
}
