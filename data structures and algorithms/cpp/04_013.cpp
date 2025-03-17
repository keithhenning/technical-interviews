#include <string>
#include <memory>

class Document {
public:
    virtual ~Document() = default;
    virtual void open() = 0;
};

class PDFDocument : public Document {
public:
    void open() override {
        // PDF specific logic
    }
};

class DocumentFactory {
public:
    std::unique_ptr<Document> createDocument(
            const std::string& type) {
        if (type == "pdf") {
            return std::make_unique<PDFDocument>();
        }
        // Add other document types
        return nullptr;
    }
};