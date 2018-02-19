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
            var printer = new ReliancePrinter("Reliance (Copy 1)");
            //var printer = new ReliancePrinter("CUSTOM TL80");
            
            var lineOfText = string.Format("Today is {0}\n", DateTime.Now.ToLongTimeString());

            var welcomeFont = new Font("Tahoma", 22);            
            var trailerFont = new Font("Courier Mono", 12);

            var content = new List<IContent>
            {
                new ImageContent(Resources.small_lettuce_burgers),
                new TextContent("Welcome", welcomeFont),

                new ImageContent(Resources.small_lettuce_burgers),
                new ImageContent(Resources.small_lettuce_burgers),
                new ImageContent(Resources.small_lettuce_burgers),
                new TextContent(lineOfText, trailerFont),
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
