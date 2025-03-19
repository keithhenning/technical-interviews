class UserService
{
    private readonly UserRepository userRepository;
    private readonly EmailService emailService;

    public UserService(UserRepository userRepository, EmailService emailService)
    {
        this.userRepository = userRepository;
        this.emailService = emailService;
    }

    public User GetUser(string username)
    {
        return userRepository.FindByUsername(username);
    }

    public void CreateUser(User user)
    {
        if (userRepository.ExistsByUsername(user.Username))
        {
            throw new UserAlreadyExistsException();
        }
        userRepository.Save(user);
        emailService.SendWelcomeEmail(user.Email);
    }
}
