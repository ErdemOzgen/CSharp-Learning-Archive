using System;


class Test {

    static void Main() {

        // The signed integral types are sbyte, short, int, long:
        int i = -1;
        // The unsigned integral types are byte, ushort, uint and ulong:
        byte b = 255;

        // The real types are float, double and decimal:
        double d = 1.23;
        // Integral literals can use decimal or hexadecimal notation; hexadecimal is denoted with the 0x prefix:
        int x = 127;
        long y = 0x7F;

        //From C# 7, you can insert an underscore anywhere inside a numeric literal to make it more readable:
        int million = 1_000_000;

        //C# 7 also lets you specify numbers in binary with the 0b prefix:
        var bb = 0b1010_1011_1100_1101_1110_1111;

        //Real literals can use decimal and/or exponential notation. For example:
        double ddd = 1.5;
        double doubleMillion = 1E06;

        // Numeric literal type inference:
        Console.WriteLine(1.0.GetType());  // Double  (double)
        Console.WriteLine(1E06.GetType());  // Double  (double)
        Console.WriteLine(1.GetType());  // Int32   (int)
        Console.WriteLine(0xF0000000.GetType());  // UInt32  (uint)
        Console.WriteLine(0x100000000.GetType());  // Int64   (long)

        // Numeric literals can be suffixed with a character to indicate their type:
        //   F = float
        //   D = double
        //   M = decimal
        //   U = uint
        //   L = long
        //   UL = ulong
        /*
        long i = 5;     // No suffix needed: Implicit lossless conversion from int literal to long

        // The D suffix is redundant in that all literals with a decimal point are inferred to be double:
        double x = 4.0;

        // The F and M suffixes are the most useful:
        float f = 4.5F;      // Will not compile without the F suffix
        decimal d = -1.23M;    // Will not compile without the M suffix.
    */

        // Integral conversions are implicit when the destination type can represent every possible value
        // of the source type. Otherwise, an explicit conversion is required:

        int xC = 12345;       // int is a 32-bit integral
        long yC = xC;          // Implicit conversion to 64-bit integral
        short zC = (short)xC;  // Explicit conversion to 16-bit integral

        // All integral types may be implicitly converted to all floating-point numbers:
        int iC = 1;
        float f = iC;

        // The reverse conversion must be explicit:
        int iExplicit = (int)f;

        // Implicitly converting a large integral type to a floating-point type preserves magnitude but may
        // occasionally lose precision:

        int i1 = 100000001;
        float f1 = i1;          // Magnitude preserved, precision lost
        int i2 = (int)f1;       // 100000000


        // The increment and decrement operators (++, --) increment and decrement numeric types by 1.
        // The operator can either precede or follow the variable, depending on whether you want the
        // value before or after the increment/decrement:

        int xpp = 0, ypp = 0;
        Console.WriteLine(xpp++);   // Outputs 0; x is now 1
        Console.WriteLine(++ypp);   // Outputs 1; x is now 1

        /*  
           // Integral division truncates remainders:

          int a = 2 / 3;      // 0

          // Division by zero is an error:

          int b = 0;
          int c = 5 / b;      // throws DivisionByZeroException

          // By default, integral arithmetic operations overflow silently:

          int a = int.MinValue;
          a--;
          Console.WriteLine (a == int.MaxValue);  // True
           */

        // You can add the checked keyword to force overflow checking:

        int aOver = 1000000;
        int bOver = 1000000;

        // The following code throws OverflowExceptions:

        //int c = checked(aOver * bOver);      // Checks just the expression.
        /*
                // Checks all expressions in statement block:
                checked
                {
                    int c2 = aOver * bOver;
                    // c2.Dump(); linqpad code
                }


                // Reminder when using LINQPad: You can highlight any section of code and
        // hit F5 to execute just that selection!

        // Unlike integral types, floating-point types have values that certain operations treat specially,
        // namely NaN (Not a Number), +∞, −∞, and −0:
        Console.WriteLine (double.NegativeInfinity);   // -Infinity

        // Dividing a nonzero number by zero results in an infinite value:
        Console.WriteLine ( 1.0 /  0.0);     //  Infinity
        Console.WriteLine (-1.0 /  0.0);     // -Infinity
        Console.WriteLine ( 1.0 / -0.0);     // -Infinity
        Console.WriteLine (-1.0 / -0.0);     //  Infinity

        // Dividing zero by zero, or subtracting infinity from infinity, results in a NaN:
        Console.WriteLine ( 0.0 /  0.0);                  //  NaN
        Console.WriteLine ((1.0 /  0.0) - (1.0 / 0.0));   //  NaN

        // When using ==, a NaN value is never equal to another value, even another NaN value:
        Console.WriteLine (0.0 / 0.0 == double.NaN);    // False

        // To test whether a value is NaN, you must use the float.IsNaN or double.IsNaN method:
        Console.WriteLine (double.IsNaN (0.0 / 0.0));   // True

        // When using object.Equals, however, two NaN values are equal:
        Console.WriteLine (object.Equals (0.0 / 0.0, double.NaN));   // True
         */

        {
            float tenth = 0.1f;                       // Not quite 0.1
            float one = 1f;
            Console.WriteLine(one - tenth * 10f);    // -1.490116E-08
        }
        {
            decimal tenth = 0.1m;                     // Exactly 0.1
            decimal one = 1m;
            Console.WriteLine(one - tenth * 10m);    // 0.0
        }

        // Neither double nor decimal can precisely represent a fractional number whose base 10
        // representation is recurring:

        decimal m = 1M / 6M;               // 0.1666666666666666666666666667M
        double dr = 1.0 / 6.0;             // 0.16666666666666666

        //m.Dump("m"); d.Dump("d");

        // This leads to accumulated rounding errors:
        decimal notQuiteWholeM = m + m + m + m + m + m;  // 1.0000000000000000000000000002M
        double notQuiteWholeD = dr + dr + dr + dr + dr + dr;  // 0.99999999999999989

        // which breaks equality and comparison operations:
        Console.WriteLine(notQuiteWholeM == 1M);   // False
        Console.WriteLine(notQuiteWholeD < 1.0);   // True
    }
}