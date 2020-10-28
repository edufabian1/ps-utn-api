using ps_utn_api_dtos;
using System.Collections.Generic;

namespace ps_utn_api_manager
{
    public interface IPartnersInfoManager
    {
        List<PartnersInfoDTO> GetPartnersInfos();
        void InsertPartner(PartnerDTO partnerDTO);
    }
}
