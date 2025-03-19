interface UserService {
  User getUser(String username);
  void createUser(User user);
  void updateUser(User user);
  void deleteUser(String username);
}