using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Bills;

namespace CapitolSharp.Congress.Stores
{
    public interface IBills
    {
        Task<BillModel> GetBillAsync(string congress, string billId);
        Task<List<BillModel>> GetUpcomingBillsAsync(string chamber);
    }

    public class Bills(ICongressApiClient client, IMapper mapper) : IBills
    {
        public async Task<BillModel> GetBillAsync(string congress, string billId)
        {
            var response = await client.SendAsync<BillsResponse<List<Bill>>>($"{congress}/bills/{billId}.json");
            if (response?.results == null) return new BillModel();
            var data = response.results.Select(b => b).FirstOrDefault();
            return data != null
                ? mapper.Map<BillModel>(data)
                : new BillModel();
        }

        public async Task<List<BillModel>> GetUpcomingBillsAsync(string chamber)
        {
            var response = await client.SendAsync<BillsResponse<List<UpcomingBills>>>($"bills/upcoming/{chamber}.json");
            if (response?.results == null) return [];
            var data = response.results.Select(m => m.bills).FirstOrDefault();
            return data != null
                ? mapper.Map<List<BillModel>>(data)
                : [];
        }
    }
}
