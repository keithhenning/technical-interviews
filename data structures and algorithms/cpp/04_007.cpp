#include <string>
#include <memory>
#include <stdexcept>

class User {
public:
    std::string getUsername() const { return username; }
private:
    std::string username;
};

class UserAlreadyExistsException : public std::runtime_error {
public:
    UserAlreadyExistsException() 
        : std::runtime_error("User already exists") {}
};

// Low-level module (implements abstractions)
class UserRepository {
public:
    virtual ~UserRepository() = default;
    virtual User findByUsername(
        const std::string& username) = 0;
    virtual void save(const User& user) = 0;
    virtual bool existsByUsername(
        const std::string& username) = 0;
};

// High-level module (depends on abstractions)
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

class MySQLUserRepository : public UserRepository {
public:
    User findByUsername(
        const std::string& username) override {
        // Implementation details to retrieve user from MySQL
        User user;
        return user;
    }
 
    void save(const User& user) override {
        // Implementation details to save user to MySQL
    }
 
    bool existsByUsername(
        const std::string& username) override {
        // Implementation details to check if user exists
        return false;
    }
};