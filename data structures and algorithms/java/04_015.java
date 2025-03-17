public interface NewSystem {
    void processData();
}

public class OldSystem {
    void processLegacyData() { /* old logic */ }
}

public class SystemAdapter implements NewSystem {
    private OldSystem oldSystem;
    
    public void processData() {
        oldSystem.processLegacyData();
    }
}