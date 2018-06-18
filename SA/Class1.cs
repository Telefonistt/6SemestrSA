using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LA_Shtokal;
using System.Reflection;
using System.IO;

namespace SA
{
    class Class1
    {
        static public void Main()
        {
            string path = Assembly.GetExecutingAssembly().Location;
            string path2 = Directory.GetCurrentDirectory();

            string code=null;
            try
            {
                code = System.IO.File.ReadAllText($@"{path2}\program.txt");
                //LexAnalizShtokal lex = new LexAnalizShtokal(code);
            }
            catch
            {

            }

            if (code != null)
            {
                Analiz.Analiz analiz = new Analiz.Analiz(code);
                if(analiz.Error!=null)
                Console.WriteLine(analiz.Error.ToString());
                else Console.WriteLine("Все отлично!!!");
            }

            



            Console.ReadKey();
            //коментарий к коду
        }
    }
}
