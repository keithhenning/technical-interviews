from abc import ABC, abstractmethod

class UserService:
  """
  High-level module depending on abstractions.
  """
  def __init__(self, user_repository):
     self.user_repository = user_repository
  
  def get_user(self, username):
     return self.user_repository.find_by_username(username)
  
  def create_user(self, user):
     if self.user_repository.exists_by_username(
           user.get_username()):
        raise UserAlreadyExistsException()
     self.user_repository.save(user)

class UserRepository(ABC):
  """
  Abstract repository interface.
  """
  @abstractmethod
  def find_by_username(self, username):
     pass
  
  @abstractmethod
  def save(self, user):
     pass
  
  @abstractmethod
  def exists_by_username(self, username):
     pass

class MySQLUserRepository(UserRepository):
  """
  MySQL implementation of repository.
  """
  def find_by_username(self, username):
     # Retrieve user from MySQL database
     pass
  
  def save(self, user):
     # Save user to MySQL database
     pass
  
  def exists_by_username(self, username):
     # Check if username exists in MySQL database
     pass