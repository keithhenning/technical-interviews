class UserService {
  private final UserRepository userRepository;
  public UserService(UserRepository userRepository) {
    this.userRepository = userRepository;
  }
 
  public User getUser(String username) {
    return userRepository.findByUsername(username);
  }
}