public interface Document {
    void open();
}

public class PDFDocument implements Document {
    public void open() { /* PDF specific logic */ }
}

public class DocumentFactory {
    public Document createDocument(String type) {
        if (type.equals("pdf")) {
            return new PDFDocument();
        }
        // Add other document types
        return null;
    }
}