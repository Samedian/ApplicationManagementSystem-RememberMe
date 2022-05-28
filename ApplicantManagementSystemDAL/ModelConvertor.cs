using ApplicantManagementSystemDAL.Model;
using ApplicantManagementTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantManagementSystemDAL
{
    public class ModelConvertor : IModelConvertor
    {
        public UserCredential ConvertEntityToModel(UserDetailEntity userDetailEntity)
        {
            UserCredential userDetail = new UserCredential();
            userDetail.UserName = userDetailEntity.UserName;
            userDetail.EmailId = userDetailEntity.EmailId;
            userDetail.Password = userDetailEntity.Password;
            userDetail.Role = userDetailEntity.UserType;

            return userDetail;
        }
    }
}
