using NUnit.Framework;
using SpecsFor;

namespace PerformanceSmokeTest
{
    [TestFixture]
    public class KnownTypeDeserializerTests : SpecsFor<KnownTypeDeserializer>
    {
        private string doubleSerializedValue_with_dot="1.0";
        private string doubleSerializedValue_with_comma = "1,0";

        [Test]
        public void Double_should_be_parsed_with_comma_separator_as_ten()
        {
            Assert.AreEqual(10, SUT.Deserialize(typeof(double), doubleSerializedValue_with_comma));
        }

        [Test]
        public void Double_should_be_parsed_with_dot_separator()
        {
            Assert.AreEqual(1, SUT.Deserialize(typeof(double), doubleSerializedValue_with_dot));
        }

        [Test]
        public void Decimal_should_be_parsed_with_comma_separator_as_ten()
        {
            Assert.AreEqual(10, SUT.Deserialize(typeof(decimal), doubleSerializedValue_with_comma));
        }

        [Test]
        public void Decimal_should_be_parsed_with_dot_separator()
        {
            Assert.AreEqual(1, SUT.Deserialize(typeof(decimal), doubleSerializedValue_with_dot));
        }
    }
}