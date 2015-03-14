using System;
using System.IO;
using System.Text;

namespace EnocdingInfodisplay
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Print the header.
            Console.Write("Info.CodePage      ");
            Console.Write("Info.Name                    ");
            Console.Write("Info.DisplayName");
            Console.WriteLine();

            // Display the EncodingInfo names for every encoding, and compare with the equivalent Encoding names.
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                Encoding e = ei.GetEncoding();

                Console.Write("{0,-15}", ei.CodePage);
                if (ei.CodePage == e.CodePage)
                {
                    Console.Write("    ");
                }
                else
                {
                    Console.Write("*** ");
                }

                Console.Write("{0,-25}", ei.Name);
                if (ei.CodePage == e.CodePage)
                {
                    Console.Write("    ");
                }
                else
                {
                    Console.Write("*** ");
                }

                Console.Write("{0,-25}", ei.DisplayName);
                if (ei.CodePage == e.CodePage)
                {
                    Console.Write("    ");
                }
                else
                {
                    Console.Write("*** ");
                }

                Console.WriteLine();
            }

            CreateFile();
            
            Console.ReadKey();
        }

        private static void CreateFile()
        {
            using (StreamWriter sw = new StreamWriter("EncodingInfo.txt"))
            {
                // Print the header.
                sw.Write("Info.CodePage      ");
                sw.Write("Info.Name                    ");
                sw.Write("Info.DisplayName");
                sw.WriteLine();

                // Display the EncodingInfo names for every encoding, and compare with the equivalent Encoding names.
                foreach (EncodingInfo ei in Encoding.GetEncodings())
                {
                    Encoding e = ei.GetEncoding();

                    sw.Write("{0,-15}", ei.CodePage);
                    if (ei.CodePage == e.CodePage)
                    {
                        sw.Write("    ");
                    }
                    else
                    {
                        sw.Write("*** ");
                    }

                    sw.Write("{0,-25}", ei.Name);
                    if (ei.CodePage == e.CodePage)
                    {
                        sw.Write("    ");
                    }
                    else
                    {
                        sw.Write("*** ");
                    }

                    sw.Write("{0,-25}", ei.DisplayName);
                    if (ei.CodePage == e.CodePage)
                    {
                        sw.Write("    ");
                    }
                    else
                    {
                        sw.Write("*** ");
                    }

                    sw.WriteLine();
                }
            }
        }
    }
}