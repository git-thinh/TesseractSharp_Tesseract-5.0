﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TesseractSharp;
using TesseractSharp.Hocr;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestTxt();
            //TestTsv();
            //TestHocr();
            //TestAlto();

            test_all();

            Console.WriteLine("DONE...");
            Console.ReadLine();
        }

        static void test_all() {
            var input = @"./samples/1.jpg";

            //////var ouput1 = input.Replace(".jpg", "--.pdf");
            //////using (var stream = Tesseract.ImageToPdf(input, languages: new[] { Language.English, Language.French }))
            //////using (var writer = File.OpenWrite(ouput1))
            //////{
            //////    stream.CopyTo(writer);
            //////}

            //////var ouput2 = input.Replace(".jpg", "--.txt");
            //////using (var stream = Tesseract.ImageToTxt(input, languages: new[] { Language.English, Language.French }))
            //////using (var writer = File.OpenWrite(ouput2))
            //////{
            //////    stream.CopyTo(writer);
            //////}

            //////var ouput3 = input.Replace(".jpg", "--.tsv");
            //////using (var stream = Tesseract.ImageToTsv(input, languages: new[] { Language.English, Language.French }))
            //////using (var writer = File.OpenWrite(ouput3))
            //////{
            //////    stream.CopyTo(writer);
            //////}

            //var ouput4 = input.Replace(".jpg", "--.hocr");
            //using (var stream = Tesseract.ImageToHocr(input, languages: new[] { Language.English, Language.French }))
            //using (var writer = File.OpenWrite(ouput4))
            //{
            //    stream.CopyTo(writer);
            //}

            //////// Also works with a Bitmap !
            //////var ouput5 = input.Replace(".jpg", "---.pdf");
            //////var bitmap = (Bitmap)Image.FromFile(input);
            //////using (var stream = Tesseract.ImageToPdf(bitmap, languages: new[] { Language.English, Language.French }))
            //////using (var writer = File.OpenWrite(ouput5))
            //////{
            //////    stream.CopyTo(writer);
            //////}

            //var hocr = HOCRParser.Parse(File.OpenText(ouput4));
            using (var stream = Tesseract.ImageToHocr(input, languages: new[] { Language.English, Language.French }))
            {
                //var hocr = HOCRParser.Parse(File.OpenText(ouput4));
                var hocr = HOCRParser.Parse(new StreamReader(stream));
                foreach (var page in hocr.Pages)
                {
                    Console.WriteLine($"\t page=\t {page.Title}");
                    foreach (var area in page.Areas)
                    {
                        Console.WriteLine($"\t area=\t {area.Title}");
                        foreach (var par in area.Paragraphs)
                        {
                            Console.WriteLine($"\t par=\t {par.Title}");
                            foreach (var line in par.Lines)
                            {
                                Console.WriteLine($"\t line=\t {line.Title}");
                                foreach (var word in line.Words)
                                {
                                    Console.WriteLine($"\t word=\t {word.Title}");
                                }
                            }
                        }
                    }
                }
            }
        }


        static void TestTxt()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
            var input = Path.Combine(assemblyDirectory, @"samples\fakeidcard.bmp");

            using (var stream = Tesseract.ImageToTxt(input, languages: new[] { Language.English, Language.French }))
            using (var read = new StreamReader(stream))
            {
                var computed = read.ReadToEnd().Replace("\r\n", "\n").Trim('\f', '\n');
                Console.WriteLine(computed);
            }

            var bitmap = (Bitmap)Image.FromFile(input);
            using (var stream = Tesseract.ImageToTxt(bitmap, languages: new[] { Language.English, Language.French }))
            using (var read = new StreamReader(stream))
            {
                var computed = read.ReadToEnd().Replace("\r\n", "\n").Trim('\f', '\n');
                Console.WriteLine(computed);
            }
        }

        static void TestTsv()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
            var input = Path.Combine(assemblyDirectory, @"samples\fakeidcard.bmp");

            using (var stream = Tesseract.ImageToTsv(input, languages: new[] { Language.English, Language.French }))
            using (var read = new StreamReader(stream))
            {
                var computed = read.ReadToEnd().Replace("\r\n", "\n");
                Console.WriteLine(computed);
            }

            var bitmap = (Bitmap)Image.FromFile(input);
            using (var stream = Tesseract.ImageToTsv(bitmap, languages: new[] { Language.English, Language.French }))
            using (var read = new StreamReader(stream))
            {
                var computed = read.ReadToEnd().Replace("\r\n", "\n");
                Console.WriteLine(computed);
            }
        }

        static void TestHocr()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
            var input = Path.Combine(assemblyDirectory, @"samples\fakeidcard.bmp");

            using (var stream = Tesseract.ImageToHocr(input, languages: new[] { Language.English, Language.French }))
            using (var read = new StreamReader(stream))
            {
                var computed = read.ReadToEnd().Replace("\r\n", "\n");
                computed = RemoveFileNameFromHocr(computed);
                Console.WriteLine(computed);
            }

            var bitmap = (Bitmap)Image.FromFile(input);
            using (var stream = Tesseract.ImageToHocr(bitmap, languages: new[] { Language.English, Language.French }))
            using (var read = new StreamReader(stream))
            {
                var computed = read.ReadToEnd().Replace("\r\n", "\n");
                computed = RemoveFileNameFromHocr(computed);
                Console.WriteLine(computed);
            }
        }

        static void TestAlto()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
            var input = Path.Combine(assemblyDirectory, @"samples\fakeidcard.bmp");

            using (var stream = Tesseract.ImageToAlto(input, languages: new[] { Language.English, Language.French }))
            using (var read = new StreamReader(stream))
            {
                var computed = read.ReadToEnd().Replace("\r\n", "\n");
                Console.WriteLine(computed);
            }

            var bitmap = (Bitmap)Image.FromFile(input);
            using (var stream = Tesseract.ImageToAlto(bitmap, languages: new[] { Language.English, Language.French }))
            using (var read = new StreamReader(stream))
            {
                var computed = read.ReadToEnd().Replace("\r\n", "\n");
                Console.WriteLine(computed);
            }
        }

        //static void TestPdf()
        //{
        //    var assembly = Assembly.GetExecutingAssembly();
        //    var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
        //    var input = Path.Combine(assemblyDirectory, @"samples\fakeidcard.bmp");
        //    var output = Path.Combine(assemblyDirectory, @"samples\fakeidcard.pdf");

        //    using (var stream = Tesseract.ImageToPdf(input, languages: new[] { Language.English, Language.French }))
        //    using (var reader2 = new PdfReader(stream))
        //    {
        //        var pdf2 = new PdfDocument(reader2);

        //    }
        //}

        static string RemoveFileNameFromHocr(string text)
        {
            const string pattern = "title='image \"";

            var startTitleIdx = text.IndexOf(pattern, StringComparison.InvariantCulture);
            var endTitleIdx = (startTitleIdx > 0) ? text.IndexOf('"', startTitleIdx + pattern.Length + 1) : 0;

            if (startTitleIdx > 0 && endTitleIdx > 0)
            {
                text = text.Remove(startTitleIdx + pattern.Length, (endTitleIdx - startTitleIdx - pattern.Length));
            }

            return text;
        }
    }
}