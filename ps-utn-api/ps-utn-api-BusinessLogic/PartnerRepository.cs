using Microsoft.EntityFrameworkCore;
using ps_utn_api_database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ps_utn_api_BusinessLogic
{
    public class PartnerRepository : IPartnerRepository, IDisposable
    {
        private UserContext _userContext;
        public PartnerRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void DeletePartner(int partnerId)
        {
            Partners partners = _userContext.Partners.Find(partnerId);
            _userContext.Partners.Remove(partners);
        }

        public List<Partners> GetAllPartners()
        {
            return _userContext.Partners.ToList();
        }

        public Partners GetPartnerById(int partnerId)
        {
            return _userContext.Partners.Find(partnerId);
        }

        public int InsertPartner(Partners partner)
        {
            _userContext.Partners.Add(partner);
            _userContext.SaveChanges();
            return partner.IdPartner;
        }

        public void UpdatePartner(Partners partners)
        {
            _userContext.Entry(partners).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _userContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
