#include <string>

class User; // Forward declaration
 
class UserRetrievalService {
public:
    virtual ~UserRetrievalService() = default;
    virtual User getUser(const std::string& username) = 0;
};
 
class UserManagementService {
public:
    virtual ~UserManagementService() = default;
    virtual void createUser(const User& user) = 0;
    virtual void updateUser(const User& user) = 0;
    virtual void deleteUser(const std::string& username) = 0;
};