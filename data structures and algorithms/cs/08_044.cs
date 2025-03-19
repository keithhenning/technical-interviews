using System;
using System.Collections.Generic;

public class ConfigStore {
    private Dictionary<string, SortedDictionary<int, string>> store;

    public ConfigStore() {
        store = new Dictionary<string, SortedDictionary<int, string>>();
    }

    public void Set(string feature, int version, string value) {
        if (!store.ContainsKey(feature)) {
            store[feature] = new SortedDictionary<int, string>();
        }
        store[feature][version] = value;
    }

    public string Get(string feature, int version) {
        if (!store.ContainsKey(feature)) {
            return "";
        }

        var versions = store[feature];
        foreach (var entry in versions.Reverse()) {
            if (entry.Key <= version) {
                return entry.Value;
            }
        }

        return "";
    }
}