using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using PTI.Reliance.Windows.Test.Properties;

namespace PTI.Reliance.Windows.Test
{
    [TestFixture]
    public class TestReliancePrinter
    {
        [Test]
        public void TestPrintJob()
        {
            // TODO enter the name of your printer
            var printerName = "Reliance (Copy 1)";


            var printer = new ReliancePrinter(printerName);
            
            var lineOfText = string.Format("Today is {0}\n", DateTime.Now.ToLongDateString());

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
                new ImageContent(Resources.small_lettuce_burgers),
                new TextContent("Welcome", welcomeFont, StringAlignment.Center),

                receiptContent,

                new TextContent(lineOfText, trailerFont),
                new TextContent("Ticket #007", justification: StringAlignment.Far),

            };

            var document = new Document
            {
                DocumentContent = content,
                AutoSize = true,
            };

            printer.PrintDocument(document);
        }
    }
}
