from collections import defaultdict

import bisect

class ConfigStore:
    def __init__(self):
        self.store = defaultdict(list)
        
    def set(self, feature, version, value):
        versions = self.store[feature]
        i = bisect.bisect_left([v for v, _ in versions], version)
        
        if i < len(versions) and versions[i][0] == version:
            versions[i] = (version, value)
        else:
            versions.insert(i, (version, value))
        
    def get(self, feature, version):
        if feature not in self.store:
            return ""
        
        versions = self.store[feature]
        i = bisect.bisect_right([v for v, _ in versions], version)
        
        if i == 0:
            return ""
        
        return versions[i-1][1]