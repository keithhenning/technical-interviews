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
      if (UserAlreadyExists(user.Username))
      {
         throw new UserAlreadyExistsException();
      }
      userRepository.Save(user);
   }

   private bool UserAlreadyExists(string username)
   {
      return userRepository.ExistsByUsername(username);
   }
}
