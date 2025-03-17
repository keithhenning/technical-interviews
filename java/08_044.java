import java.util.HashMap;
import java.util.Map;
import java.util.TreeMap;

/**
 * Stores versioned feature configurations
 */
class ConfigStore {
   private Map<String, TreeMap<Integer, String>> store;
   
   /**
    * Initialize empty configuration store
    */
   public ConfigStore() {
      store = new HashMap<>();
   }
   
   /**
    * Set a feature's value for a specific version
    */
   public void set(String feature, int version, String value) {
      if (!store.containsKey(feature)) {
         store.put(feature, new TreeMap<>());
      }
      store.get(feature).put(version, value);
   }
   
   /**
    * Get feature value at or before specified version
    */
   public String get(String feature, int version) {
      if (!store.containsKey(feature)) {
         return "";
      }
      
      TreeMap<Integer, String> versions = store.get(feature);
      Map.Entry<Integer, String> entry = 
            versions.floorEntry(version);
      
      if (entry == null) {
         return "";
      }
      
      return entry.getValue();
   }
}