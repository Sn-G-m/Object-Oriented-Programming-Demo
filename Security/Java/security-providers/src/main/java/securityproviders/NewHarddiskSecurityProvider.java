package securityproviders;

// Adaptor design pattern implementation for Hard-disk security provider.
public class NewHarddiskSecurityProvider implements ISecurityProvider{
    public NewHarddiskSecurityProvider() {
        // Empty logic
    }

    private HarddiskSecurityProvider harddiskSecurityProvider = new HarddiskSecurityProvider();

    @Override
    public boolean scan() {
        // Simulate a harddisk security scan
        harddiskSecurityProvider.diskScan();
        return true; // Assume the scan is successful
    }

    @Override
    public String getName() {
        return harddiskSecurityProvider.getScanner();
    }
}
