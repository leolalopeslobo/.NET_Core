//The main difference between Hiding and Overriding is the virtual method concept

//What is a virtual method?
//This is a late bound (runtime binding) method. This gives more flexibility
//In late binding you can declare a reference of the base class time but allocate memory for wither the base class or a derived class object and then if it is a virtual method, then the methid ti be called will depend on what allocation of memory you have done, if you have allocated the base class object then the base class is called and same works for derived
//This is called Late Time Binding, Runtime Binding or Polymorphism


//There is also an early bound (compile-time binding).
//A pure vitual method is a method that doesn't have a definition and can be defined in the child class
