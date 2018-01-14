using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Readify.KnockKnock.Api.Services;

namespace Readify.KnockKnock.Tests
{
    [TestFixture]
    public class ReversedWordsTest
    {
        private ReverseWordsService _subject;

        [SetUp]
        public void SetupTest()
        {
            _subject = new ReverseWordsService();
        }

        [TestCase("quicktest", ExpectedResult = "quicktest")]
        [TestCase("a b", ExpectedResult = "b a")]
        [TestCase("the quick brown fox", ExpectedResult = "fox brown quick the")]
        [TestCase("the    quick brown        fox", ExpectedResult = "fox brown quick the")]
        [TestCase("33()(){}{}[][]bbbb", ExpectedResult = "33()(){}{}[][]bbbb")]
        public string TestService(string sentense)
        {
            return _subject.Reverse(sentense);
        }
    }
}
