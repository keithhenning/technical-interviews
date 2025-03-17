class UserService {
 
  private final UserRepository userRepository;
  private final EmailService emailService;
 
  public UserService(UserRepository userRepository, EmailService emailService) {
    this.userRepository = userRepository;
    this.emailService = emailService;
  }
 
  public User getUser(String username) {
    return userRepository.findByUsername(username);
  }
 
  public void createUser(User user) {
    if (userRepository.existsByUsername(user.getUsername())) {
      throw new UserAlreadyExistsException();
    }
    userRepository.save(user);
    emailService.sendWelcomeEmail(user.getEmail());
  }
}