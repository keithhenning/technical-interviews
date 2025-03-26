class UserService
{
   private readonly IUserRepository userRepository;
   public UserService(IUserRepository userRepository)
   {
      this.userRepository = userRepository;
   }

   public User GetUser(string username)
   {
      return userRepository.FindByUsername(username);
   }
}
