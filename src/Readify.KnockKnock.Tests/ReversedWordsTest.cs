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

        [TestCase("quicktest", ExpectedResult = "tsetkciuq")]
        [TestCase("a b", ExpectedResult = "a b")]
        [TestCase("the quick brown fox", ExpectedResult = "eht kciuq nworb xof")]
        [TestCase("the    quick brown        fox", ExpectedResult = "eht kciuq nworb xof")]
        [TestCase("33()(){}{}[][]bbbb", ExpectedResult = "bbbb][][}{}{)()(33")]
        public string TestService(string sentense)
        {
            return _subject.Reverse(sentense);
        }
    }
}
