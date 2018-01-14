using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Readify.KnockKnock.Api.Exceptions;
using Readify.KnockKnock.Api.Models;

namespace Readify.KnockKnock.Api.Services
{
    public class TriangleTypeService : ITriangleTypeService
    {
        public TriangleType GetTriangleType(TriangleTypeRequest request)
        {
            var sides = new [] {request.A, request.B, request.C};
            sides = sides.OrderByDescending(c => c).ToArray();

            if (sides[2] <= 0 || sides[0] >= sides[1] + sides[2])
            {
                throw new InvalidTriangleException();
            }

            if (sides[0] == sides[1] && sides[0] == sides[2])
            {
                return TriangleType.Equilateral;
            }

            if (sides[0] * sides[0] == sides[1] * sides[1] + sides[2] * sides[2])
            {
                // note: impossible to get isosceles right triangle with integer side length
                return sides[1] == sides[2] ? TriangleType.IsoscelesRight : TriangleType.Right;
            }

            if (sides[1] == sides[2])
            {
                return TriangleType.Isosceles;
            }

            return TriangleType.Scalene;
        }
    }
}
