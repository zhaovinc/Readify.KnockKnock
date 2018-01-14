using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Readify.KnockKnock.Api.Models;

namespace Readify.KnockKnock.Api.Services
{
    public class TriangleTypeService
    {
        public TriangleType GetType(int a, int b, int c)
        {
            return TriangleType.Equilateral;
        }
    }
}
