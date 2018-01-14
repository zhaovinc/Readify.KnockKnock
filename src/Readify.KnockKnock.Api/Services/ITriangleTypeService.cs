using Readify.KnockKnock.Api.Models;

namespace Readify.KnockKnock.Api.Services
{
    public interface ITriangleTypeService
    {
        TriangleType GetTriangleType(TriangleTypeRequest request);
    }
}