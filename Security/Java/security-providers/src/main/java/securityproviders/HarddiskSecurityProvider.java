package securityproviders;

public class HarddiskSecurityProvider {
    public HarddiskSecurityProvider() {
        // Empty logic
    }

    public boolean diskScan() {
        // Simulate a hard-disk security scan
        System.out.println("Scanning hard-disk...");
        return true; // Assume the scan is successful
    }

    public String getScanner() {
        return "Hard-disk Security Provider";
    }
}
