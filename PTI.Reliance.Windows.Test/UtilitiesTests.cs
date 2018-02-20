using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTI.Reliance.Windows;
using NUnit.Framework;
namespace PTI.Reliance.Windows.Test
{
    [TestFixture()]
    public class UtilitiesTests
    {
        [Test()]
        public void BoundingBoxTest()
        {
            var data = new List<SizeF>
            {
                new SizeF(0, 0),
                new SizeF(40, 100),
                new SizeF(0, 100),
                new SizeF(800, 100)
            };

            var expected = new SizeF(800, 300);
            var actual = Utilities.BoundingBox(data);
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ConvertMmToInchesTest()
        {
            // input, output
            var data = new Dictionary<float, float>
            {
                { 25.4f, 1.0f },
                { 80.0f, 3.14961f },
                { 0, 0 }
            };


            foreach (var pair in data)
            {
                var actual = Utilities.ConvertMmToInches(pair.Key);
                var err = Math.Abs(pair.Value - actual);
                Assert.LessOrEqual(err, 0.0001);
            }
        }

        [Test()]
        public void ConvertInchesToMmTest()
        {
            // input, output
            var data = new Dictionary<float, float>
            {
                { 1.0f, 25.4f },
                { 3.14961f, 80.0f },
                { 0, 0 }
            };

            foreach (var pair in data)
            {
                var actual = Utilities.ConvertInchesToMm(pair.Key);
                var err = Math.Abs(pair.Value - actual);
                Assert.LessOrEqual(err, 0.0001);
            }
        }
    }
}
