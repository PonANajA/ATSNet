using ASTNet.Models.Responses;
using ASTNet.Services.Interfaces;

namespace ASTNet.Services
{
    public class RankService : IRankService
    {
        public List<RankResponse> ProcessRank(string input)
        {
            var items = input
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            // เอาเฉพาะค่าที่ซ้ำ
            var duplicates = items
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            // แยก alphabet
            var alphabets = duplicates
                .Where(x => !int.TryParse(x, out _))
                .OrderBy(x => x)
                .ToList();

            // แยก numeric และเรียงแบบ int
            var numbers = duplicates
                .Where(x => int.TryParse(x, out _))
                .OrderBy(x => int.Parse(x))
                .ToList();

            return alphabets
                .Concat(numbers)
                .Select(x => new RankResponse { rank = x })
                .ToList();
        }
    }
}
