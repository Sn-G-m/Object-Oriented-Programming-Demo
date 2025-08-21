package securityproviders;

// Adaptor design pattern implementation for Hard-disk security provider.
public class NewHarddiskSecurityProvider implements ISecurityProvider {
    ISecurityProvider _next = null;
    public NewHarddiskSecurityProvider(ISecurityProvider next) {
        // Empty logic
        _next = next;
    }

    HarddiskSecurityProvider harddiskSecurityProvider = new HarddiskSecurityProvider();

    @Override
    public ISecurityProvider getNext() {
        return _next;
    }

    @Override
    public boolean scan() {
        // Simulate a harddisk security scan
        boolean result = true;
        harddiskSecurityProvider.diskScan();
        if (_next != null) {
            result = result && _next.scan();
        }
        return result; // Assume the scan is successful
    }

    @Override
    public String getName() {
        return harddiskSecurityProvider.getScanner();
    }
}
