using ApplicantManagementTables;

namespace ApplicantManagementSystemDAL
{
    public interface IAccountDAL
    {
        string SaveCredential(UserDetailEntity userDetailEntity);
    }
}