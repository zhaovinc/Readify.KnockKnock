using System;
using Nancy;
using Nancy.Responses;
using Readify.KnockKnock.Api.Models;
using Readify.KnockKnock.Api.Services;

namespace Readify.KnockKnock.Api.NancyModules
{
    public class ApiModule : NancyModule
    {
        private readonly IFibonacciService _fibonacciService;
        private readonly IReverseWordsService _reverseWordsService;

        public ApiModule(IFibonacciService fibonacciService, IReverseWordsService reverseWordsService) : base("/api")
        {
            _fibonacciService = fibonacciService;
            _reverseWordsService = reverseWordsService;

            Get("/Token", _ => GetToken());
            Get("/Fibonacci", _ => GetNthFibonacci());
            Get("/ReverseWords", _ => GetReversedWords());
        }

        private dynamic GetToken()
        {
            return Constants.APIToken;
        }

        private dynamic GetNthFibonacci()
        {
            long n = 0;
            if (!long.TryParse(Request.Query["n"], out n))
            {
                return Negotiate.WithModel(new ErrorMessage
                {
                    Message = "Please provide a valid integer"
                }).WithStatusCode(HttpStatusCode.BadRequest);
            }

            long result = 0;
            try
            {
                result = _fibonacciService.GetNth(n);
            }
            catch (Exception)
            {
                return Negotiate.WithModel(new ErrorMessage
                {
                    Message = "The result is too big"
                }).WithStatusCode(HttpStatusCode.BadRequest);
            }

            return new TextResponse(result.ToString());
        }

        private dynamic GetReversedWords()
        {
            var sentense = Request.Query["sentence"];
            if (string.IsNullOrEmpty(sentense))
            {
                return Negotiate.WithModel(new ErrorMessage
                {
                    Message = "Please provide a sentense"
                }).WithStatusCode(HttpStatusCode.BadRequest);
            }

            var result = _reverseWordsService.Reverse(sentense);
            return new TextResponse(result);
        }
    }
}
