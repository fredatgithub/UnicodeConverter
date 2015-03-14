using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace EncodingConverter
{
  class Program
  {
    static void Main(string[] args)
    {
      bool logEnable = false;
      string logFileName = string.Empty;
      string targetEncodingString = "UTF8"; // default value
      Encoding targetEncoding = Encoding.UTF8;
      logFileName = Path.GetFullPath(Assembly.GetEntryAssembly().Location); //Environment.CurrentDirectory;

      if (args.Length < 2)
      {
        DisplayUsage();
        return;
      }

      // parse log Enable

      if (args[2] != null)
      {
        string logStatus = args[2].ToUpper();
        if (logStatus.StartsWith(("-LOG:")))
        {
          logEnable = logStatus.Substring(5, 2) == "ON";
        }
      }

      // verify pathfilename is correct
      logFileName = args[0];
      if (!File.Exists(logFileName))
      {
        if (logEnable)
        {
          LogInfo("File does not exist");
        }

        DisplayUsage();
        return;
      }

      // Set Encoding
      targetEncodingString = args[1].ToUpper();
      // Validation of encoding
      switch (targetEncodingString)
      {
        case "UTF8":
          targetEncoding = Encoding.UTF8;
          break;
        case "ASCII":
          targetEncoding = Encoding.ASCII;
          break;
        case "BIGENDIANUNICODE":
          targetEncoding = Encoding.BigEndianUnicode;
          break;
        case "UTF32":
          targetEncoding = Encoding.UTF32;
          break;
        case "UTF7":
          targetEncoding = Encoding.UTF7;
          break;
        case "UNICODE":
          targetEncoding = Encoding.Unicode;
          break;
        default:
          targetEncoding = Encoding.UTF8;
          break;
      }

      String unicodeString = string.Empty;
      string shortname = Path.GetFileName(logFileName); // shortname
      if (shortname != null)
        using (StreamReader sr = new StreamReader(shortname))
        {
          unicodeString = sr.ReadToEnd();
        }
      UnicodeEncoding unicode = new UnicodeEncoding();
      Byte[] encodedBytes = unicode.GetBytes(unicodeString);
      String decodedString = unicode.GetString(encodedBytes);
      Byte[] changeEncoding = Encoding.Convert(Encoding.Default, targetEncoding, encodedBytes);
      //EncodingInfo encodingInfo = new EncodingInfo();
      Encoding.GetEncodings();
      using (StreamWriter sw = new StreamWriter("test4.txt", false, targetEncoding))
      {
        sw.Write(decodedString);
      }
    }

    private static void DisplayUsage()
    {
      DisplayText("EncodingConverter.exe is a freeware console application");
      DisplayText("created by Freddy Juhel on the 23rd of February 2014.");
      DisplayText("How to use this application :");
      DisplayText("EncodingConverter <Source File Path> <Encoding to be converted to> -<Options>");
      DisplayText("Encoding available : Default UTF8");
      DisplayText("UTF8");
      DisplayText("ASCII");
      DisplayText("BIGENDIANUNICODE");
      DisplayText("UTF32");
      DisplayText("UTF7");
      DisplayText("UNICODE");
      DisplayText("Here are all the options available :");
      DisplayText("-Log:<ON/OFF> default is OFF");
      DisplayText(string.Empty);

    }

    private static void DisplayText(string theText)
    {
      if (theText == null)
      {
        return;
      }

      Console.WriteLine(theText);
    }

    private static void LogInfo(string logText)
    {
      const string fileName = "EncodingConverter.log";
      if (!File.Exists(fileName))
      {
        File.Create(fileName);
      }

      const bool append = true;
      using (StreamWriter sw = new StreamWriter(fileName, append))
      {
        sw.WriteLine(DateTime.Now + " " + logText);
      }
    }
  }
}