using AutoMapper;
using CapitolSharp.Congress.Models;
using CapitolSharp.Congress.Responses.Bills;
using CapitolSharp.Congress.Interfaces;

namespace CapitolSharp.Congress.Stores
{
    public class Bills : DataStoreAccessor, IBills
    {
        public Bills(string apiKey, IMapper mapper)
            : base(apiKey, mapper)
        {

        }

        public async Task<BillModel> GetBillAsync(string congress, string billId)
        {
            var response = await SendAsync<BillsResponse<List<Bill>>>($"{congress}/bills/{billId}.json");
            if (response?.results == null) return new BillModel();
            var data = response.results.Select(b => b).FirstOrDefault();
            return data != null
                ? _mapper.Map<BillModel>(data)
                : new BillModel();
        }

        public async Task<List<BillModel>> GetUpcomingBillsAsync(string chamber)
        {
            var response = await SendAsync<BillsResponse<List<UpcomingBills>>>($"bills/upcoming/{chamber}.json");
            if (response?.results == null) return new List<BillModel>();
            var data = response.results.Select(m => m.bills).FirstOrDefault();
            return data != null
                ? _mapper.Map<List<BillModel>>(data)
                : new List<BillModel>();
        }
    }
}
