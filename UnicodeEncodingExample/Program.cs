﻿using System;
using System.Text;

namespace UnicodeEncodingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // The encoding.
            UnicodeEncoding unicode = new UnicodeEncoding();

            // Create a string that contains Unicode characters.
            String unicodeString =
                "This Unicode string contains two characters " +
                "with codes outside the traditional ASCII code range, " +
                "Pi (\u03a0) and Sigma (\u03a3) avec des accents éèàçù.";
            Console.WriteLine("Original string:");
            Console.WriteLine(unicodeString);

            // Encode the string.
            Byte[] encodedBytes = unicode.GetBytes(unicodeString);
            Console.WriteLine();
            Console.WriteLine("Encoded bytes:");
            foreach (Byte b in encodedBytes)
            {
                Console.Write("[{0}]", b);
            }
            Console.WriteLine();

            // Decode bytes back to string.
            // Notice Pi and Sigma characters are still present.
            String decodedString = unicode.GetString(encodedBytes);
            Console.WriteLine();
            Console.WriteLine("Decoded bytes:");
            Console.WriteLine(decodedString);
            Console.ReadKey();
        }
    }
}
