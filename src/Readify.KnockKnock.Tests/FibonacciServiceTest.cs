using System;
using NUnit.Framework;
using Readify.KnockKnock.Api.Services;
using Shouldly;

namespace Readify.KnockKnock.Tests
{
    [TestFixture]
    public class FibonacciServiceTest
    {
        private FibonacciService _subject;

        [SetUp]
        public void SetupTest()
        {
            _subject = new FibonacciService();
        }
        
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 2)]
        [TestCase(4, ExpectedResult = 3)]
        [TestCase(5, ExpectedResult = 5)]
        [TestCase(50, ExpectedResult = 12586269025)]
        public long TestService(long n)
        {
            return _subject.GetNth(n);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestInvalidValue(long n)
        {
            Assert.Throws<ApplicationException>(() => _subject.GetNth(n));
        }

        [TestCase(1000)]
        public void TestOverflow(long n)
        {
            Assert.Throws<OverflowException>(() => _subject.GetNth(n));
        }

    }
}
