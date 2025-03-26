interface IUserRetrievalService
{
   User GetUser(string username);
}

interface IUserManagementService
{
   void CreateUser(User user);
   void UpdateUser(User user);
   void DeleteUser(string username);
}
