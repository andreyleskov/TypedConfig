using System.Net.Mail;
using ImpromptuInterface;
using NUnit.Framework;
using Ploeh.AutoFixture;
using SpecsFor;
using TypedConfig.TypedAdapter;

namespace TypedConfig.Tests
{
  
    [TestFixture]
    public class TypedAdapter_WhenFakesType_ShouldProvideValues : SpecsFor<ValueCollectionToTypedClassAdapter>
    {
        private ITestTypedInterface _fakedClass;
        private TestTypedClass _testValues;

        public interface ITestTypedInterface
        {
            string StringValue { get; }
            decimal DecValue { get; }
            MailAddress MailValue { get; }
            object ObjValue { get; }

            double DoubleValue { get; }
        }

        private class TestTypedClass : ITestTypedInterface
        {
            public string StringValue { get; set; }
            public decimal DecValue { get; set; }
            public MailAddress MailValue { get; set; }
            public object ObjValue { get; set; }
            public double DoubleValue { get; set; }
        }

        protected override void Given()
        {
            _testValues = (new Fixture()).Create<TestTypedClass>();
            GetMockFor<IPropertyValueProvider>().Setup(p => p.GetValue(nameof(ITestTypedInterface.StringValue))).Returns(_testValues.StringValue);
            GetMockFor<IPropertyValueProvider>().Setup(p => p.GetValue(nameof(ITestTypedInterface.DecValue))).Returns(_testValues.DecValue);
            GetMockFor<IPropertyValueProvider>().Setup(p => p.GetValue(nameof(ITestTypedInterface.MailValue))).Returns(_testValues.MailValue);
            GetMockFor<IPropertyValueProvider>().Setup(p => p.GetValue(nameof(ITestTypedInterface.DoubleValue))).Returns(_testValues.MailValue);
            GetMockFor<IPropertyValueProvider>().Setup(p => p.GetValue(nameof(ITestTypedInterface.DoubleValue))).Returns(_testValues.DoubleValue);
            // GetMockFor<IPropertyValueProvider>().Setup(p => p.GetValue("ObjValue")).Returns(_testValues.ObjValue);
        }

        protected override void When()
        {
            _fakedClass = SUT.ActLike<ITestTypedInterface>();
        }

        [Test]
        public void DecimalValue_Should_be_provided()
        {
            Assert.AreEqual(_testValues.DecValue, _fakedClass.DecValue);
        }

        //[Test]
        //public void ObjValue_Should_be_provided()
        //{
        //    var objValue = _fakedClass.ObjValue;
        //    Assert.AreEqual(_testValues.ObjValue, objValue);
        //}

        [Test]
        public void DoubleValue_Should_be_provided()
        {
            Assert.AreEqual(_testValues.DoubleValue, _fakedClass.DoubleValue);
        }

        [Test]
        public void MailValue_Should_be_provided()
        {
            Assert.AreEqual(_testValues.MailValue, _fakedClass.MailValue);
        }

        [Test]
        public void StringValue_Should_be_provided()
        {
            Assert.AreEqual(_testValues.StringValue, _fakedClass.StringValue);
        }
    }
}