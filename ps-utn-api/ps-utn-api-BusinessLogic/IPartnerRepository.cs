using ps_utn_api_database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ps_utn_api_BusinessLogic
{
    public interface IPartnerRepository : IDisposable
    {
        int InsertPartner(Partners partner);
        void DeletePartner(int partnerId);
        void UpdatePartner(Partners partnerId);
        List<Partners> GetAllPartners();
        Partners GetPartnerById(int partnerId);
    }
}
