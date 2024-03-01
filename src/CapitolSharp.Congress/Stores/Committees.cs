using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Committee;
using CapitolSharp.Congress.Responses;
using AutoMapper;

namespace CapitolSharp.Congress.Stores
{
    public interface ICommittees
    {
        /// <summary>
        /// Get a list of Senate, House or joint committees, including their subcommittees.
        /// </summary>
        /// <param name="congress"></param>
        /// <param name="chamber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<CommitteeModel>> GetCommitteesAsync(string congress, string chamber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about a single Senate or House committee, including the members of that committee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="congress"></param>
        /// <param name="chamber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CommitteeModel> GetCommitteeAsync(string id, string congress, string chamber, CancellationToken cancellationToken = default);
    }

    public class Committees(ICongressApiClient client, IMapper mapper) : ICommittees
    {
        public async Task<CommitteeModel> GetCommitteeAsync(string id, string congress, string chamber, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<IEnumerable<CommitteeResult>>>($"{congress}/{chamber}/committees/{id}.json", cancellationToken);
            if (response?.results == null) return new CommitteeModel();

            var data = response.results.FirstOrDefault();

            return data != null
                ? mapper.Map<CommitteeModel>(data)
                : new CommitteeModel();
        }

        public async Task<List<CommitteeModel>> GetCommitteesAsync(string congress, string chamber, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<IEnumerable<CommitteeListResult>>>($"{congress}/{chamber}/committees.json", cancellationToken);
            if (response?.results == null) return [];

            var data = response.results.Select(m => m.committees).FirstOrDefault();
            return data != null
                ? mapper.Map<List<CommitteeModel>>(data)
                : [];
        }
    }
}