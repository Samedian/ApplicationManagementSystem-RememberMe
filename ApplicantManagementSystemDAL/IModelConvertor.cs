using ApplicantManagementSystemDAL.Model;
using ApplicantManagementTables;

namespace ApplicantManagementSystemDAL
{
    public interface IModelConvertor
    {
        UserCredential ConvertEntityToModel(UserDetailEntity userDetailEntity);
    }
}