using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses;
using CapitolSharp.Congress.Responses.Bills;

namespace CapitolSharp.Congress.Stores
{
    public interface IBills
    {
        /// <summary>
        /// Get the 20 bills most recently introduced or updated by a particular member. Results can include more than one Congress. 
        /// You can paginate through bills using the offset querystring parameter that accepts multiples of 20. 
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="type"></param>
        /// <param name="offset"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<BillModel>> GetMemberBillsAsync(string memberId, string type, int offset = 0, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get details on bills that may be considered by the House or Senate in the near future, based on scheduled published or announced by congressional leadership.
        /// </summary>
        /// <param name="chamber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<BillModel>> GetUpcomingBillsAsync(string chamber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get details about a particular bill, including actions taken and votes.
        /// </summary>
        /// <param name="congress"></param>
        /// <param name="billId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BillModel> GetBillAsync(string congress, string billId, CancellationToken cancellationToken = default);

    }

    public class Bills(ICongressApiClient client, IMapper mapper) : IBills
    {
        public async Task<List<BillModel>> GetMemberBillsAsync(string memberId, string type, int offset = 0, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<Response<IEnumerable<MemberBillsResult>>>($"members/{memberId}/bills/{type}.json?offset={offset}", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results.FirstOrDefault()?.bills;
            return data != null
                ? mapper.Map<List<BillModel>>(data)
                : [];
        }

        public async Task<List<BillModel>> GetUpcomingBillsAsync(string chamber, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<BillsResponse<List<UpcomingBills>>>($"bills/upcoming/{chamber}.json", cancellationToken);
            if (response?.results == null) return [];
            var data = response.results.Select(m => m.bills).FirstOrDefault();
            return data != null
                ? mapper.Map<List<BillModel>>(data)
                : [];
        }

        public async Task<BillModel> GetBillAsync(string congress, string billId, CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync<BillsResponse<List<Bill>>>($"{congress}/bills/{billId}.json", cancellationToken);
            if (response?.results == null) return new BillModel();
            var data = response.results.Select(b => b).FirstOrDefault();
            return data != null
                ? mapper.Map<BillModel>(data)
                : new BillModel();
        }
    }
}
