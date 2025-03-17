from abc import ABC, abstractmethod

class Document(ABC):
    @abstractmethod
    def open(self):
        pass

class PDFDocument(Document):
    def open(self):
        # PDF specific logic
        pass

class DocumentFactory:
    def create_document(self, doc_type):
        if doc_type == "pdf":
            return PDFDocument()
        # Add other document types
        return None