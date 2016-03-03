using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MoqCallBaseExample.Business.Tests
{
    [TestClass]
    public class UnitTest1
    {

        Mock<Foo> _mockFoo = new Mock<Foo>();

        /// <summary>
        /// In this test, we are not using "CallBase", 
        /// meaning the "real" class implementation is *not* used when *not* explicitly mocked.
        /// </summary>
        [TestMethod]
        public void NotUsingCallBase_usesMethodStub()
        {
            // Arrange / Act
            var result = _mockFoo.Object.CalculateSomeValue();

            // This *should* return 5, and in a real situation it would - in the mocked situation though it returns the integer default of 0
            Assert.AreNotEqual(5, result);
        }

        /// <summary>
        /// In this test, we're using call base.  Methods that aren't "Setup" use their base class implementation.
        /// But how is this helpful?  See next test.
        /// </summary>
        [TestMethod]
        public void UsingCallBase_usesMethodImplementation()
        {
            // Arrange
            _mockFoo.CallBase = true;

            // Act
            var result = _mockFoo.Object.CalculateSomeValue();

            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// We know that "CalculateSomeValue()" calls "CalculateSomeValue(int, int)".
        /// In this test, we're saying to "CallBase", calling "CalculateSomeValue()", but providing
        /// a new implementation of "CalculateSomeValue(int, int)" - 
        /// so that we can test *ONLY* "CalculateSomeValue()" independant on "CalculateSomeValue(int, int)"'s implementation
        /// </summary>
        [TestMethod]
        public void UsingCallBase_OverrideACalledMethod()
        {
            // Arrange
            _mockFoo.CallBase = true;
            _mockFoo.Setup(s => s.CalculateSomeValue(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(10);

            // Act
            var result = _mockFoo.Object.CalculateSomeValue();

            Assert.AreEqual(10, result);

        }
    }
}
