using System;
using System.Collections.Generic;
using System.Drawing;
using PTI.Reliance.Windows;

namespace PrinterTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length < 1)
            {
                Console.WriteLine("Enter printer name in quotes");
                return;
            }
            
            var printerName = args[0];

            PrintTicket(printerName);
            
            GetInfo(printerName);
        }

        private static void GetInfo(string printerName)
        {
            foreach (var str in Utilities.GetPageSizeList())
            {
                Console.WriteLine(str);
            }
        }

        private static void PrintTicket(string printerName)
        {     
            var printer = new ReliancePrinter(printerName);
            
            var lineOfText = $"Today is {DateTime.Now.ToLongDateString()}\n";

            // TODO There is an open task for bold, italics, etc.            
            var receiptContent = new TextContent();
            receiptContent.SetTabStops(0, new [] {100.0f, 50.0f, 50.0f, 50.0f});

            receiptContent.TextBuilder.Append("\n");
            receiptContent.TextBuilder.Append("Item\tPrice\tQuantity\tTotal\n");
            receiptContent.TextBuilder.Append("Lettuce\t$4.99\t3\t$14.97\n");
            receiptContent.TextBuilder.Append("Seedless Bun\t$1.99\t3\t$5.97\n");
            receiptContent.TextBuilder.Append("\n\n");
            receiptContent.TextBuilder.Append(new string('-', 78));
            receiptContent.TextBuilder.Append("\n\tTotal");
            receiptContent.TextBuilder.AppendFormat("\t\t$20.94\n\n");

            var welcomeFont = new Font("Tahoma", 22);            
            var trailerFont = new Font("Courier Mono", 12);

            var content = new List<IContent>
            {
                new ImageContent("killian_logo.jpg"),
                new TextContent("Welcome", welcomeFont, StringAlignment.Center),

                receiptContent,

                new TextContent(lineOfText, trailerFont),
                new TextContent("Ticket #007", justification: StringAlignment.Far),

            };

            var document = new Document
            {
                DocumentContent = content,
                // AutoSize = true,               
                //RequestedSize = new PageSizeMillimeters(80, 160)
            };

            printer.PrintDocument(document);
        }
    }
}