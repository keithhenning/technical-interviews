#include <string>
#include <memory>
#include <stdexcept>

class User; // Forward declaration
class UserRepository; // Forward declaration
class UserAlreadyExistsException; // Forward declaration

class UserService {
private:
    std::shared_ptr<UserRepository> userRepository;
    
public:
    UserService(std::shared_ptr<UserRepository> repository) 
        : userRepository(repository) {}
 
    User getUser(const std::string& username) {
        return userRepository->findByUsername(username);
    }
 
    void createUser(const User& user) {
        if (userRepository->existsByUsername(
                user.getUsername())) {
            throw UserAlreadyExistsException();
        }
        userRepository->save(user);
    }
};

class EmailService {
public:
    void sendWelcomeEmail(const std::string& email) {
        // Send welcome email
    }
};