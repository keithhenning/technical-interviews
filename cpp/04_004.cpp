#include <string>

class User; // Forward declaration

class UserService {
public:
    virtual ~UserService() = default;
    virtual User getUser(const std::string& username) = 0;
    virtual void createUser(const User& user) = 0;
    virtual void updateUser(const User& user) = 0;
    virtual void deleteUser(const std::string& username) = 0;
};