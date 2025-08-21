package securityproviders;

public class AccountSecurityProvider implements ISecurityProvider {
    ISecurityProvider _next = null;
    public AccountSecurityProvider(ISecurityProvider next) {
        // Constructor logic if needed
        _next = next;
    }
    @Override
    public ISecurityProvider getNext() {
        return _next;
    }

    @Override
    public boolean scan() {
        // Simulate an account security scan
        boolean result = true;
        System.out.println("Scanning account security...");
        if (_next != null) {
            result = result && _next.scan();
        }
        return result; // Assume the scan is successful
    }

    @Override
    public String getName() {
        return "Account Security Provider";
    }
}
