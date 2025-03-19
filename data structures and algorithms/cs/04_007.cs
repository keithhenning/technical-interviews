// High-level module (depends on abstractions)
class UserService {
  private readonly IUserRepository userRepository;

  public UserService(IUserRepository userRepository) {
    this.userRepository = userRepository;
  }

  public User GetUser(string username) {
    return userRepository.FindByUsername(username);
  }

  public void CreateUser(User user) {
    if (userRepository.ExistsByUsername(user.Username)) {
      throw new UserAlreadyExistsException();
    }
    userRepository.Save(user);
  }
}

// Low-level module (implements abstractions)
interface IUserRepository {
  User FindByUsername(string username);
  void Save(User user);
  bool ExistsByUsername(string username);
}

class MySQLUserRepository : IUserRepository {
  public User FindByUsername(string username) {
    // Implementation details to retrieve user from MySQL database
  }

  public void Save(User user) {
    // Implementation details to save user to MySQL database
  }

  public bool ExistsByUsername(string username) {
    // Implementation details to check if user with given username exists in MySQL database
  }
}
