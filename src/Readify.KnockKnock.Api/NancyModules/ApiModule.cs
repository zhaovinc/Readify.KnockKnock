using System;
using System.Transactions;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using Readify.KnockKnock.Api.Exceptions;
using Readify.KnockKnock.Api.Models;
using Readify.KnockKnock.Api.Services;

namespace Readify.KnockKnock.Api.NancyModules
{
    public class ApiModule : NancyModule
    {
        private readonly IFibonacciService _fibonacciService;
        private readonly IReverseWordsService _reverseWordsService;
        private readonly ITriangleTypeService _triangleTypeService;

        public ApiModule(IFibonacciService fibonacciService, IReverseWordsService reverseWordsService,
            ITriangleTypeService triangleTypeService) : base("/api")
        {
            _fibonacciService = fibonacciService;
            _reverseWordsService = reverseWordsService;
            _triangleTypeService = triangleTypeService;

            Get("/Token", _ => GetToken());
            Get("/Fibonacci", _ => GetNthFibonacci());
            Get("/ReverseWords", _ => GetReversedWords());
            Get("/TriangleType", _ => GetTriangleType());
        }

        private dynamic GetToken()
        {
            return Constants.APIToken;
        }

        private dynamic GetNthFibonacci()
        {
            FibonacciRequest request = null;
            try
            {
                request = this.Bind<FibonacciRequest>();
            }
            catch (ModelBindingException)
            {
                return Response.AsJson(new ErrorMessage
                {
                    Message = "Please provide a valid integer"
                }).WithStatusCode(HttpStatusCode.BadRequest);
            }
            
            long result = 0;
            try
            {
                result = _fibonacciService.GetNth(request.N);
            }
            catch (Exception)
            {
                return Response.AsJson(new ErrorMessage
                {
                    Message = "Please provide a valid integer"
                }).WithStatusCode(HttpStatusCode.BadRequest);
            }

            return new TextResponse(result.ToString());
        }

        private dynamic GetReversedWords()
        {
            ReverseWordsRequest request = null;
            try
            {
                request = this.Bind<ReverseWordsRequest>();
            }
            catch (ModelBindingException)
            {
                return new TextResponse("");
            }

            var result = _reverseWordsService.Reverse(request.Sentence);
            return new TextResponse(result);
        }

        private dynamic GetTriangleType()
        {
            TriangleTypeRequest request = null;
            try
            {
                request = this.Bind<TriangleTypeRequest>();
            }
            catch (ModelBindingException)
            {
                return new TextResponse("Error");
            }

            TriangleType result;
            try
            {
                result = _triangleTypeService.GetTriangleType(request);
            }
            catch (InvalidTriangleException)
            {
                return new TextResponse("Error");
            }
            
            return new TextResponse(result.ToString("G"));
        }
    }
}
