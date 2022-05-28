using ApplicantManagementTables;

namespace ApplicantManagementSystemBAL
{
    public interface IAccountBAl
    {
        string SaveCredentials(UserDetailEntity userDetailEntity);
        string GetRoleByDetail(string userName, string pass);
    }
}