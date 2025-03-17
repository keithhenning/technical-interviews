class UserService:
  """
  Service for user operations with email notification.
  """
  def __init__(self, user_repository, email_service):
     self.user_repository = user_repository
     self.email_service = email_service
  
  def get_user(self, username):
     return self.user_repository.find_by_username(
        username)
  
  def create_user(self, user):
     if self.user_repository.exists_by_username(
           user.get_username()):
        raise UserAlreadyExistsException()
     self.user_repository.save(user)
     self.email_service.send_welcome_email(
        user.get_email())