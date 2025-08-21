package securityproviders;

public class ExtendedAntivirusSecurityProvider extends AntivirusSecurityProvider implements ISecurityProvider {
    ISecurityProvider _next = null;
    public ExtendedAntivirusSecurityProvider(ISecurityProvider next) {
        // Empty constructor logic
        super(next);
        _next = next;
    }

    @Override
    public ISecurityProvider getNext() {
        return _next;
    }

    @Override
    public boolean scan() {

        // Simulate an extended antivirus security scan
        boolean result = true;
        System.out.println("Extended scan for viruses...");
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
        return "Extended Antivirus Security Provider";
    }
}
