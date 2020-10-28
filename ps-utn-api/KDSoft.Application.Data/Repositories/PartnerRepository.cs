using KDSoft.Application.Data;
using ManagementEsports.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ManagementEsports.Data.Repositories
{
    public class PartnerRepository : IPartnerRepository, IInjectable
    {
        private string cnnString = @"Data Source=DESKTOP-K6F3JF2\SQLEXPRESS;Initial Catalog=utn_ps;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public async Task<IEnumerable<Partner>> GetAll()
        {
            List<Partner> partners = new List<Partner>();

            DataTable table = await Connection.ExecuteGetQuery(cnnString, "DBO.SP_GET_PARTNERS");

            foreach (DataRow row in table.Rows)
            {
                Partner partner = new Partner
                {
                    Id = row["id_partner"] != DBNull.Value ? int.Parse(row["id_partner"].ToString()) : 0,                    
                    Nickname = row["nickname"].ToString(),
                    Description = row["description"].ToString(),
                    UrlPage = row["url_page"].ToString()
                };
                partners.Add(partner);
            }

            return partners;
        }

        public async Task<Partner> GetById(int dataId)
        {
            Partner partner = null;

            SqlParameter[] parameters = { new SqlParameter("@partner_id", dataId) };

            DataTable table = await Connection.ExecuteGetQuery(cnnString, "DBO.SP_GET_PARTNERS_BY_ID", parameters);

            foreach (DataRow row in table.Rows)
            {
                partner = new Partner
                {
                    Id = row["id_partner"] != DBNull.Value ? int.Parse(row["id_partner"].ToString()) : 0,
                    Name = row["name"].ToString(),
                    Nickname = row["nickname"].ToString(),
                    Description = row["description"].ToString(),
                    UrlPage = row["url_page"].ToString(),
                    Contract = new Contract
                    {
                        InitDate = DateTime.Parse(row["init_date"].ToString()),
                        FinalDate = DateTime.Parse(row["final_date"].ToString()),
                        CashMonth = decimal.Parse(row["cash_month"].ToString()),
                        RefPartner = row["ref_partner"].ToString(),
                        Phone = row["phone"].ToString(),
                        IdEmployee = int.Parse(row["id_employee"].ToString())
                    }
                };
            }
            return partner;
        }

        public async Task Insert(Partner data)
        {
            SqlParameter[] parameters = { 
                new SqlParameter("@contract_init_date", data.Contract.InitDate),
                new SqlParameter("@contract_final_date", data.Contract.FinalDate),
                new SqlParameter("@contract_cash_month", data.Contract.CashMonth),
                new SqlParameter("@contract_ref_partner", data.Contract.RefPartner),
                new SqlParameter("@contract_phone", data.Contract.Phone),
                new SqlParameter("@contract_id_employee", data.Contract.IdEmployee),
                new SqlParameter("@partner_name", data.Name),
                new SqlParameter("@partner_nickname", data.Nickname),
                new SqlParameter("@partner_description", data.Description),
                new SqlParameter("@partner_url_page", data.UrlPage)
            };

            await Connection.ExecuteNonQuerySync(cnnString, "DBO.SP_INSERT_PARTNERS", parameters);
        }

        public async Task Update(Partner data)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@partner_id", data.Id),
                new SqlParameter("@contract_init_date", data.Contract.InitDate),
                new SqlParameter("@contract_final_date", data.Contract.FinalDate),
                new SqlParameter("@contract_cash_month", data.Contract.CashMonth),
                new SqlParameter("@contract_ref_partner", data.Contract.RefPartner),
                new SqlParameter("@contract_phone", data.Contract.Phone),
                new SqlParameter("@partner_name", data.Name),
                new SqlParameter("@partner_nickname", data.Nickname),
                new SqlParameter("@partner_description", data.Description),
                new SqlParameter("@partner_url_page", data.UrlPage)
            };

            await Connection.ExecuteNonQuerySync(cnnString, "DBO.SP_UPDATE_PARTNERS", parameters);
        }

        public async Task Delete(int partnerId)
        {
            SqlParameter[] parameters = { new SqlParameter("@partner_id", partnerId) };

            DataTable table = await Connection.ExecuteGetQuery(cnnString, "DBO.SP_DELETE_PARTNERS_BY_ID", parameters);
        }
    }
}
