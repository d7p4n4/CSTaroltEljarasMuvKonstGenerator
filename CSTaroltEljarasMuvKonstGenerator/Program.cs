using d7p4n4Namespace.Final.Class;
using System;
using System.IO;

namespace CSTaroltEljarasMuvKonstGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Deserializer deserializer = new Deserializer();

            try
            {
                string[] files =
                    Directory.GetFiles("d:\\Server\\Visual_studio\\output_Xmls\\StorProcsMethods\\", "*.xml", SearchOption.TopDirectoryOnly);

                Console.WriteLine(files.Length);

                foreach (var _file in files)
                {
                    TaroltEljaras ujTaroltEljaras = new TaroltEljaras();
                    string _filename = Path.GetFileNameWithoutExtension(_file);
                    Console.WriteLine(_filename);

                    string textFile = Path.Combine("d:\\Server\\Visual_studio\\output_Xmls\\StorProcsMethods\\", _filename + ".xml");

                    string text = File.ReadAllText(textFile);

                    ujTaroltEljaras = deserializer.deser(text);
                    Generator.generateClass("d:\\Server\\Visual_studio\\AK\\outputTaroltEljaras\\Muvelet\\", ujTaroltEljaras);

                }
            }
            catch (Exception _exception)
            {
                Console.WriteLine(_exception.StackTrace);
            }
        }
    }
}
