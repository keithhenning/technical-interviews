class UserService:
    def __init__(self, user_repository):
        self.user_repository = user_repository
    
    def get_user(self, username):
        return self.user_repository.find_by_username(username)