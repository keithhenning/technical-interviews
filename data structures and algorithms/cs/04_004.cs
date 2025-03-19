interface IUserService {
  User GetUser(string username);
  void CreateUser(User user);
  void UpdateUser(User user);
  void DeleteUser(string username);
}
