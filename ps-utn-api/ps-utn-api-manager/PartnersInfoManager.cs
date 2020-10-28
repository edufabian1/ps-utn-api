using ps_utn_api_BusinessLogic;
using ps_utn_api_database.Models;
using ps_utn_api_dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ps_utn_api_manager
{
    public class PartnersInfoManager : IPartnersInfoManager
    {
        private IPartnerRepository _partnerRepository = new PartnerRepository(new UserContext());

        public List<PartnersInfoDTO> GetPartnersInfos()
        {
            List<Partners> partners = _partnerRepository.GetAllPartners();

            return partners.Select(x => new PartnersInfoDTO
            {
                Id = x.IdPartner,
                Nickname = x.Nickname,
                Description = x.Description,
                UrlPage = x.UrlPage
            }).ToList();
        }

        public void InsertPartner(PartnerDTO partnerDTO)
        {            
            var idPartner = _partnerRepository.InsertPartner(new Partners
            {
                Name = partnerDTO.Name,
                Nickname = partnerDTO.Nickname,
                Description = partnerDTO.Description,
                UrlPage = partnerDTO.UrlPage
            });
        }
    }
}
