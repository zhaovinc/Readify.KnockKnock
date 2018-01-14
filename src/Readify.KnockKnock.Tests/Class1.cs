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
        private long _result;

        [SetUp]
        public void SetupTest()
        {
            _subject = new FibonacciService();
        }

        [TestCase(-1, ExpectedResult = 0)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 2)]
        [TestCase(4, ExpectedResult = 3)]
        [TestCase(5, ExpectedResult = 5)]
        public long TestService(long n)
        {
            return _subject.GetNth(n);
        }
    }
}
