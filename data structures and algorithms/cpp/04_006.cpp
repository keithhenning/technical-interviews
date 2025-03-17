#include <string>
#include <memory>

class User; // Forward declaration
class UserRepository; // Forward declaration

class UserService {
private:
    std::shared_ptr<UserRepository> userRepository;
public:
    UserService(std::shared_ptr<UserRepository> repository) 
        : userRepository(repository) {}
 
    User getUser(const std::string& username) {
        return userRepository->findByUsername(username);
    }
};