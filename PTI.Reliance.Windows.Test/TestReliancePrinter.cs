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
            
            var lineOfText = string.Format("Today is {0}\n", DateTime.Now.ToLongTimeString());

            // There is an open task for tabs, bold, etc.            
            var receiptContent = new TextContent();
            receiptContent.TextBuilder.Append("\n");
            receiptContent.TextBuilder.Append("Item       Price    Quantity\n");
            receiptContent.TextBuilder.Append("Lettuce    $4.99       3\n");
            receiptContent.TextBuilder.Append("\n\n");
            receiptContent.TextBuilder.Append("Total--------------------\n");
            receiptContent.TextBuilder.AppendFormat("${0}", 4.99 * 3);

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
