using ASTNet.Models.Responses;

namespace ASTNet.Services.Interfaces
{
    public interface IRankService
    {
        List<RankResponse> ProcessRank(string input);
    }
}
