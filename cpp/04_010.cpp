#include <string>
#include <memory>
#include <stdexcept>

class User; // Forward declaration
class UserRepository; // Forward declaration
class EmailService; // Forward declaration
class UserAlreadyExistsException; // Forward declaration

class UserService {
private:
    std::shared_ptr<UserRepository> userRepository;
    std::shared_ptr<EmailService> emailService;
    
public:
    UserService(std::shared_ptr<UserRepository> repository, 
                std::shared_ptr<EmailService> email) 
        : userRepository(repository), emailService(email) {}
 
    User getUser(const std::string& username) {
        return userRepository->findByUsername(username);
    }
 
    void createUser(const User& user) {
        if (userRepository->existsByUsername(
                user.getUsername())) {
            throw UserAlreadyExistsException();
        }
        userRepository->save(user);
        emailService->sendWelcomeEmail(user.getEmail());
    }
};