using d7p4n4Namespace.Final.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSTaroltEljarasMuvKonstGenerator
{
    class Generator
    {
        public static void generateClass(string outputPath, TaroltEljaras taroltEljaras)
        {
            StringToPascalCase converter = new StringToPascalCase();

            string[] text = readIn("TemplateTaroltEljarasMuvelet");

            string replaced = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("enums"))
                {
                    int x = 0;
                    string newline = "";
                    foreach (var muvelet in taroltEljaras.MuveletLista)
                    {
                        newline = newline + text[i + 1].Replace("#muveletNev#", converter.Convert(muvelet.Leiras)).Replace("#num#", "" + x) + "\n";
                        Console.WriteLine(newline);
                        x++;

                    }
                    replaced = replaced + newline + "\n";
                    i = i + 2;
                }
                else if (text[i].Contains("muveletKonstans"))
                {
                    string newline = "";
                    foreach (var muvelet in taroltEljaras.MuveletLista)
                    {
                        newline = newline + text[i + 1].Replace("#muveletNev#", converter.Convert(muvelet.Leiras)).Replace("#muveletKod#", muvelet.Kod) + "\n";
                        Console.WriteLine(newline);
                        
                    }
                    replaced = replaced + newline + "\n";
                    i = i + 2;
                }
                replaced = replaced + text[i] + "\n";
            }

            replaced = replaced.Replace("#taroltEljarasNev#", taroltEljaras.Kod);

            writeOut(replaced, taroltEljaras.Kod, outputPath);

        }

        public static string[] readIn(string fileName)
        {

            string textFile = "c:\\Templates\\c#\\Tabla\\" + fileName + ".csT";

            string[] text = File.ReadAllLines(textFile);

            return text;
        }

        public static void writeOut(string text, string fileName, string outputPath)
        {
            File.WriteAllText(outputPath + fileName + ".cs", text);

        }
    }
}