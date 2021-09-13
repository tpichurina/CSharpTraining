using System;
using System.IO;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string type = args[3];

            switch (type)
            {
                case "g":
                    GroupFileGenerator.Generator(count, format, writer);
                    break;
                case "c":
                    ContactFileGenerator.Generator(count, format, writer);
                    break;

                default:
                    System.Console.Out.Write("Unrecognized type" + type);
                    break;
            }
        }
    }
}
