using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Committee;
using CapitolSharp.Congress.Responses;
using AutoMapper;
using CapitolSharp.Congress.Interfaces;

namespace CapitolSharp.Congress.Stores
{
    public class Committees : DataStoreAccessor, ICommittees
    {
        public Committees(string apiKey, IMapper mapper)
            : base(apiKey, mapper)
        {

        }

        public async Task<CommitteeModel> GetCommitteeAsync(string id, string congress, string chamber)
        {
            var response = await SendAsync<Response<IEnumerable<CommitteeResult>>>($"{congress}/{chamber}/committees/{id}.json");
            if (response?.results == null) return new CommitteeModel();

            var data = response.results.FirstOrDefault();

            return _mapper.Map<CommitteeModel>(data);
        }

        public async Task<List<CommitteeModel>> GetCommitteesAsync(string congress, string chamber)
        {
            var response = await SendAsync<Response<IEnumerable<CommitteeListResult>>>($"{congress}/{chamber}/committees.json");
            if (response?.results == null) return new List<CommitteeModel>();

            var data = response.results.Select(m => m.committees).FirstOrDefault();
            return data != null
                ? _mapper.Map<List<CommitteeModel>>(data)
                : new List<CommitteeModel>();
        }
    }
}