using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Readify.KnockKnock.Api.Exceptions;
using Readify.KnockKnock.Api.Models;
using Readify.KnockKnock.Api.Services;

namespace Readify.KnockKnock.Tests
{
    [TestFixture]
    public class TriangleTypeServiceTest
    {
        private TriangleTypeService _subject;

        [SetUp]
        public void SetupTest()
        {
            _subject = new TriangleTypeService();
        }

        [TestCase(10, 10, 10, ExpectedResult = TriangleType.Equilateral)]
        [TestCase(3, 4, 5, ExpectedResult = TriangleType.Right)]
        [TestCase(4, 5, 3, ExpectedResult = TriangleType.Right)]
        [TestCase(7, 7, 8, ExpectedResult = TriangleType.Isosceles)]
        [TestCase(8, 9, 10, ExpectedResult = TriangleType.Scalene)]
        public TriangleType TestService(int a, int b, int c)
        {
            var request = new TriangleTypeRequest {A = a, B = b, C = c};
            return _subject.GetTriangleType(request);
        }

        [TestCase(-1, 3, 3)]
        [TestCase(10, 1, 20)]
        public void TestInvalidValue(int a, int b, int c)
        {
            var request = new TriangleTypeRequest { A = a, B = b, C = c };
            Assert.Throws<InvalidTriangleException>(() => _subject.GetTriangleType(request));
        }
    }
}
