#include <string>
#include <vector>
#include <memory>
#include <algorithm>

class Observer {
public:
    virtual ~Observer() = default;
    virtual void update(const std::string& message) = 0;
};

class NewsAgency {
private:
    std::vector<std::shared_ptr<Observer>> observers;
    
public:
    void addObserver(std::shared_ptr<Observer> observer) {
        observers.push_back(observer);
    }
    
    void removeObserver(std::shared_ptr<Observer> observer) {
        observers.erase(
            std::remove(observers.begin(), 
                       observers.end(), observer),
            observers.end()
        );
    }
    
    void notifyObservers(const std::string& news) {
        for (const auto& observer : observers) {
            observer->update(news);
        }
    }
};