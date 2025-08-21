package securityproviders;

public class DeviceSecurity implements ISecurityProvider {
    ISecurityProvider _next = null;
    public DeviceSecurity(ISecurityProvider next) {
        // Constructor logic if needed
        _next = next;
    }

    @Override
    public ISecurityProvider getNext() {
        return _next;
    }

    @Override
    public boolean scan() {
        // Simulate a device security scan
        boolean result = true;
        System.out.println("Scanning device security...");
        if (_next != null) {
            result = result && _next.scan();
        }
        return result; // Assume the scan is successful
    }

    @Override
    public String getName() {
        return "Device Security Provider";
    }
}
