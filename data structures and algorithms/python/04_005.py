from abc import ABC, abstractmethod

class UserRetrievalService(ABC):
    @abstractmethod
    def get_user(self, username):
        pass
 
class UserManagementService(ABC):
    @abstractmethod
    def create_user(self, user):
        pass
    
    @abstractmethod
    def update_user(self, user):
        pass
    
    @abstractmethod
    def delete_user(self, username):
        pass