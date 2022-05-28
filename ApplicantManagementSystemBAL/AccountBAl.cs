using ApplicantManagementSystemDAL;
using ApplicantManagementTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantManagementSystemBAL
{
    public class AccountBAl : IAccountBAl
    {
        private readonly IAccountDAL _accountDAL;

        public AccountBAl(IAccountDAL accountDAL)
        {
            _accountDAL = accountDAL;
        }

        public string GetRoleByDetail(string userName, string pass)
        {
            throw new NotImplementedException();
        }

        public string SaveCredentials(UserDetailEntity userDetailEntity)
        {
            var result = _accountDAL.SaveCredential(userDetailEntity);
            return result;
        }
    }
}
