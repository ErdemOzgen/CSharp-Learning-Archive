using System;


class Test
{
    // Just as we can build complex functions from simple functions, we can build complex types
    // from primitive types. UnitConverter serves a a blueprint for unit conversions:

    public class UnitConverter
    {
        int ratio;                                                     // Field
        public UnitConverter(int unitRatio) { ratio = unitRatio; }  // Constructor
        public int Convert(int unit) { return unit * ratio; }  // Method
    }

    // The instance field Name pertains to an instance of a particular Panda,
    // whereas Population pertains to the set of all Pandas:

    public class Panda
    {
        public string Name;             // Instance field
        public static int Population;   // Static field

        public Panda(string n)         // Constructor
        {
            Name = n;                      // Assign the instance field
            Population = Population + 1;   // Increment the static Population field
        }
    }


    public struct Point { public int X, Y; }

    static void Main()
    {
        // string, int and bool types are examples of predefined types:

        string message = "Hello world";
        string upperMessage = message.ToUpper();
        Console.WriteLine(upperMessage);               // HELLO WORLD

        int x = 2015;
        message = message + x.ToString();
        Console.WriteLine(message);                    // Hello world2015

        bool simpleVar = false;
        if (simpleVar)
            Console.WriteLine("This will not print");

        int y = 5000;
        bool lessThanAMile = y < 5280;
        if (lessThanAMile)
            Console.WriteLine("This will print");
        //--------------------------------------------------------
        
        UnitConverter feetToInchesConverter = new UnitConverter(12);
        UnitConverter milesToFeetConverter = new UnitConverter(5280);

        Console.WriteLine(feetToInchesConverter.Convert(30));    // 360
        Console.WriteLine(feetToInchesConverter.Convert(100));   // 1200
        Console.WriteLine(feetToInchesConverter.Convert(milesToFeetConverter.Convert(1)));   // 63360
                                                                                             //-------------------------------------------------------
        Panda p1 = new Panda("Pan Dee");
        Panda p2 = new Panda("Pan Dah");

        Console.WriteLine(p1.Name);      // Pan Dee
        Console.WriteLine(p2.Name);      // Pan Dah

        Console.WriteLine(Panda.Population);   // 2

        // Implicit conversions are allowed when the compiler can guarantee they will
        // always succeed and no information is lost in conversion:

        int xConversionVar = 12345;       // int is a 32-bit integer
        long yConversionVar = xConversionVar;          // Implicit conversion to 64-bit integer

        // In other cases, you need explicit conversions:

        short zConversionVar = (short)xConversionVar;  // Explicit conversion to 16-bit integer
        Console.WriteLine(zConversionVar);
        //-----------------------------------------------

        Point point1 = new Point();
        point1.X = 7;
        Point point2 = point1;

        Console.WriteLine(point1.X);
        Console.WriteLine(point2.X);



    }
}

