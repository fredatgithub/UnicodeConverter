using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace UnicodeConverter
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //UnicodeEncoding
           

            String unicodeString = string.Empty;
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                unicodeString = sr.ReadToEnd();
            }
            UnicodeEncoding unicode = new UnicodeEncoding();
            Byte[] encodedBytes = unicode.GetBytes(unicodeString);
            String decodedString = unicode.GetString(encodedBytes);
            Byte[] changeEncoding = Encoding.Convert(Encoding.Default, Encoding.UTF7, encodedBytes);
            //EncodingInfo encodingInfo = new EncodingInfo();
                Encoding.GetEncodings();
            using (StreamWriter sw = new StreamWriter("test4.txt", false, Encoding.UTF32))
            {
                sw.Write(decodedString);
            }

            //byte[] ba = { 72, 101, 108, 108, 111 };
            //string s = Encoding.ASCII.GetString(ba);
            //Console.WriteLine(s);

            //byte[] bb = new byte[] { 0, 72, 0, 101, 0, 108, 0, 108, 0, 111 };
            //string t = Encoding.BigEndianUnicode.GetString(bb);
            //Console.WriteLine(t);

            //ASCIIEncoding ae = new ASCIIEncoding();
            //Console.WriteLine(ae.GetString(ba));
            //UnicodeEncoding bu = new UnicodeEncoding(true, false);
            //Console.WriteLine(bu.GetString(bb));

        }
    }
}