package securityproviders;

public class OnlineAccountSecurityProvider extends AccountSecurityProvider implements ISecurityProvider {
    ISecurityProvider _next = null;
    public OnlineAccountSecurityProvider(ISecurityProvider next) {
        // Constructor logic if needed
        super(next);
        _next = next;
    }

    @Override
    public ISecurityProvider getNext() {
        return _next;
    }

    @Override
    public boolean scan() {
        // Note: Online account security scans may also involve checking local account security.

        // Simulate an online account security scan
        boolean result = true;
        System.out.println("Scanning online account security...");
        boolean scanResult = true; // Assume the scan is successful

        // Call the base class scan method.
        if (_next != null) {
            result = result && _next.scan();
        }
        boolean baseScanResult = true;
        return baseScanResult && scanResult && result; // Combine results
    }

    @Override
    public String getName() {
        return "Online Account Security Provider";
    }
}
