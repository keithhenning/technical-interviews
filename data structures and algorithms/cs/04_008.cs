class UserService
{
   private readonly UserRepository userRepository;

   public UserService(UserRepository userRepository)
   {
      this.userRepository = userRepository;
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
   }
}
