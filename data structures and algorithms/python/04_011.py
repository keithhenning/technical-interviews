class UserService:
  """
  Service for user operations.
  """
  def __init__(self, user_repository):
     self.user_repository = user_repository
  
  def get_user(self, username):
     return self.user_repository.find_by_username(
        username)
  
  def create_user(self, user):
     if self.user_repository.exists_by_username(
           user.get_username()):
        raise UserAlreadyExistsException()
     self.user_repository.save(user)

class EmailService:
  """
  Service for email operations.
  """
  def send_welcome_email(self, email):
     # Send welcome email
     pass