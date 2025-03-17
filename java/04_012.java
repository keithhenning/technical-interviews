public class ConfigManager {
    private static ConfigManager instance;
    private ConfigManager() {} // Private constructor
    
    public static ConfigManager getInstance() {
        if (instance == null) {
            instance = new ConfigManager();
        }
        return instance;
    }
}