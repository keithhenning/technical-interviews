interface UserRetrievalService {
  User getUser(String username);
}
 
interface UserManagementService {
  void createUser(User user);
  void updateUser(User user);
  void deleteUser(String username);
}