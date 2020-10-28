using ManagementEsports.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagementEsports.Business
{
    public class PartnerBus : IInjectable
    {
        private readonly IPartnerRepository _repository;

        public PartnerBus(IPartnerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Partner> GetById(int dataId)
        {
            return await _repository.GetById(dataId);
        }

        public async Task<IEnumerable<Partner>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Insert(Partner partner)
        {
            await _repository.Insert(partner);
        }

        public async Task Update(Partner partner)
        {
            await _repository.Update(partner);
        }

        public async Task Delete(int partnerId)
        {
            await _repository.Delete(partnerId);
        }
    }
}
