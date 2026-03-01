// Example in Swift for iOS
class OfflineFirstCache {
    private let memoryCache =
        NSCache<NSString, AnyObject>()
    private let fileManager =
        FileManager.default
    private let cacheDirectory: URL
    init() throws {
        // Get cache directory
        let urls = fileManager.urls(
            for: .cachesDirectory,
            in: .userDomainMask
        )
        cacheDirectory = urls[0]
            .appendingPathComponent(
                "offline_cache"
            )
        // Create directory if needed
        if !fileManager.fileExists(
            atPath: cacheDirectory.path
        ) {
            try fileManager.createDirectory(
                at: cacheDirectory,
                withIntermediateDirectories: true
            )
        }
    }
    func get<T: Decodable>(key: String) -> T? {
        // Check memory cache first
        if let cachedObject =
            memoryCache.object(
                forKey: key as NSString
            ) as? T {
            return cachedObject
        }
        // Check disk cache
        let filePath = cacheDirectory
            .appendingPathComponent(key)
        guard fileManager.fileExists(
            atPath: filePath.path
        ) else {
            return nil
        }
        do {
            let data = try Data(
                contentsOf: filePath
            )
            let object = try JSONDecoder()
                .decode(T.self, from: data)
            // Update memory cache
            memoryCache.setObject(
                object as AnyObject,
                forKey: key as NSString
            )
            return object
        } catch {
            print("Error reading: \(error)")
            return nil
        }
    }
}
