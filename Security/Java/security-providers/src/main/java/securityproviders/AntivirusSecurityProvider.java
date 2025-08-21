package securityproviders;

public class AntivirusSecurityProvider implements ISecurityProvider {
    ISecurityProvider _next = null;
    public AntivirusSecurityProvider(ISecurityProvider next) {
        // Constructor logic if needed
        _next = next;
    }

    @Override
    public ISecurityProvider getNext() {
        return _next;
    }

    @Override
    public boolean scan() {
        // Simulate a virus scan
        boolean result = true;
        System.out.println("Scanning for viruses...");
        if (_next != null) {
            result = result && _next.scan();
        }
        return result; // Assume the scan is successful
    }

    @Override
    public String getName() {
        return "Antivirus Security Provider";
    }
}
