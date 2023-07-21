**References and Values**

**Concept of Reference Type**
_(Here it 'points to')_
//o1.i = 100;
//o2.i = 200;

//o1 = o2;
//this means o1 = o2 = 200
//o2.i = 300
//this means that o1 = o2 = 300

//Console.WriteLine(o1.i); -> 300
//Console.WriteLine(o2.i); -> 300




**Concept of Value Type**
_(Here it 'copies to')_
int o1, o2;
o1 = 100;
o2 = 200;
o1 = o2;
o2 = 300;
//Console.WriteLine(o1); -> 200
//Console.WriteLine(o2); -> 300

(an int is actually a struct)



---------------------------------------

In .Net also strings are immutable so it won't change it's value rather it will create a new memory location and point to that

![image](https://github.com/leolalopeslobo/.NET_Core/assets/83197830/2d0acf67-7899-4ed1-bd69-f7a0e3efde76)

---------------------------------------


**Reference Type**
- All classes and their variants are Ref Type
- **Object** is created on the **heap** and the **Reference** to the object is created on the **Stack**
- Examples of reference types are classes, interfaces, delegates, arrays, object class and the string class

![image](https://github.com/leolalopeslobo/.NET_Core/assets/83197830/85077faf-291a-4f59-9def-5fe21ccde143)

**Value Type**
- All **structs** and **enums** are value types and value types are created on the **Stack**

![image](https://github.com/leolalopeslobo/.NET_Core/assets/83197830/41fd06c2-5090-49ab-90d4-7e54a15efed8)
