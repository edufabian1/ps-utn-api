using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementEsports.Models
{
    public interface IPartnerRepository
    {
        Task Insert(Partner partner);
        Task Delete(int partnerId);
        Task Update(Partner partner);
        Task<IEnumerable<Partner>> GetAll();
        Task<Partner> GetById(int partnerId);
    }
}
