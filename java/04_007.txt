// High-level module (depends on abstractions)
class UserService {
  private final UserRepository userRepository;
 
  public UserService(UserRepository userRepository) {
    this.userRepository = userRepository;
  }
 
  public User getUser(String username) {
    return userRepository.findByUsername(username);
  }
 
  public void createUser(User user) {
    if (userRepository.existsByUsername(user.getUsername())) {
      throw new UserAlreadyExistsException();
    }
    userRepository.save(user);
  }
}
 
// Low-level module (implements abstractions)
interface UserRepository {
  User findByUsername(String username);
  void save(User user);
  boolean existsByUsername(String username);
}
 
class MySQLUserRepository implements UserRepository {
  @Override
  public User findByUsername(String username) {
    // Implementation details to retrieve user from MySQL database
  }
 
  @Override
  public void save(User user) {
    // Implementation details to save user to MySQL database
  }
 
  @Override
  public boolean existsByUsername(String username) {
    // Implementation details to check if user with given username exists in MySQL database
  }
}