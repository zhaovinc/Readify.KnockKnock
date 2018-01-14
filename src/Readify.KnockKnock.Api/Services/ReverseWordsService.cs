using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Readify.KnockKnock.Api.Services
{
    public class ReverseWordsService : IReverseWordsService
    {
        public string Reverse(string sentense)
        {
            var reversedWords = System.Text.RegularExpressions.Regex.Split(sentense, @"\s+").Reverse();
            var result = String.Join(' ', reversedWords);
            return result;
        }
    }
}
