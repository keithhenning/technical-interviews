class UserService {
  private final UserRepository userRepository;
 
  public UserService(UserRepository userRepository) {
    this.userRepository = userRepository;
  }
 
  public User getUser(String username) {
    return userRepository.findByUsername(username);
  }
 
  public void createUser(User user) {
    if (userAlreadyExists(user.getUsername())) {
      throw new UserAlreadyExistsException();
    }
    userRepository.save(user);
  }
 
  private boolean userAlreadyExists(String username) {
    return userRepository.existsByUsername(username);
  }
}