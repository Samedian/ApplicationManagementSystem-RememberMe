using ApplicantManagemenSystemtExceptions;
using ApplicantManagementSystemDAL.Model;
using ApplicantManagementTables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApplicantManagementSystemDAL
{
    public class AccountDAL : IAccountDAL
    {
        private readonly IModelConvertor _modelConvertor;

        public AccountDAL(IModelConvertor modelConvertor)
        {
            _modelConvertor = modelConvertor;
        }
        public string SaveCredential(UserDetailEntity userDetailEntity)
        {
            UserCredential userDetail = _modelConvertor.ConvertEntityToModel(userDetailEntity);
            try
            {
                using (var context = new ApplicantManagementEntities())
                {
                    var data = context.UserCredentials.FirstOrDefault(x => x.UserName == userDetail.UserName);
                    if (data != null)
                        throw new PrimaryKeyViolationException("UserName already present");
                    context.UserCredentials.Add(userDetail);
                    context.SaveChanges();
                }
                return "Data Added Successfully";

            }
            catch (PrimaryKeyViolationException ex)
            {
                return ex.Message;
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
