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
            var words = System.Text.RegularExpressions.Regex.Split(sentense, @"\s+");
            var reversedWords = words.Select(x => new string(x.Reverse().ToArray()));
            var result = String.Join(' ', reversedWords);
            return result;
        }
    }
}
