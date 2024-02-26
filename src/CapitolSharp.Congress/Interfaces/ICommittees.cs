using CapitolSharp.Congress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitolSharp.Congress.Interfaces
{
    public interface ICommittees
    {
        Task<List<CommitteeModel>> GetCommitteesAsync(string congress, string chamber);
        Task<CommitteeModel> GetCommitteeAsync(string id, string congress, string chamber);
    }
}
