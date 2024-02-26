using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Committee;
using CapitolSharp.Congress.Responses;
using AutoMapper;

namespace CapitolSharp.Congress.Stores
{
    public interface ICommittees
    {
        Task<List<CommitteeModel>> GetCommitteesAsync(string congress, string chamber);
        Task<CommitteeModel> GetCommitteeAsync(string id, string congress, string chamber);
    }

    public class Committees(ICongressApiClient client, IMapper mapper) : ICommittees
    {
        public async Task<CommitteeModel> GetCommitteeAsync(string id, string congress, string chamber)
        {
            var response = await client.SendAsync<Response<IEnumerable<CommitteeResult>>>($"{congress}/{chamber}/committees/{id}.json");
            if (response?.results == null) return new CommitteeModel();

            var data = response.results.FirstOrDefault();

            return data != null
                ? mapper.Map<CommitteeModel>(data)
                : new CommitteeModel();
        }

        public async Task<List<CommitteeModel>> GetCommitteesAsync(string congress, string chamber)
        {
            var response = await client.SendAsync<Response<IEnumerable<CommitteeListResult>>>($"{congress}/{chamber}/committees.json");
            if (response?.results == null) return [];

            var data = response.results.Select(m => m.committees).FirstOrDefault();
            return data != null
                ? mapper.Map<List<CommitteeModel>>(data)
                : [];
        }
    }
}