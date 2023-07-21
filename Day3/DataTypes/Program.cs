namespace DataTypes
{
    internal class Program
    {

        static void DataTypes()
        {
            //These are all values (and they are all 'struct' types)
            //For Numeric Data
            //i. Used for storing whole number
            byte b; //Byte - 1
            sbyte b1; //SByte (signed byte)
 
            short sh; //CTS - Int16 (2Bytes or 16bits)
            ushort ush; //unsigned short : CTS UInt16

            int i; //CTS - Int32 (4Bytes or 32bits)
            uint ui; //unsigned int : CTS UInt32

            long l; //CTS - Int64 (8Bytes or 64bits)
            ulong ul; //unsigned long : CTS UInt64


            //ii. Used for storing decimal numbers
            float f; //Single - 4Bytes (gives lowest precision)
            double d; //Double - 8Bytes
            decimal c; //Decimal - 16Bytes (gives highest precision)



            
            char ch; //Char - 2Bytes (Reason why 2 bytes since it can also store unicode values)


            bool boo; //Boolean




            //Reference Types
            object o; //Object
            string str; //string
        }
    }
}
