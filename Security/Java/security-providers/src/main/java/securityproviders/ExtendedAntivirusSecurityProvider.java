package securityproviders;

public class ExtendedAntivirusSecurityProvider extends AntivirusSecurityProvider implements ISecurityProvider {
    public ExtendedAntivirusSecurityProvider() {
        // Empty constructor logic
    }

    @Override
    public boolean scan() {

        // Simulate an extended antivirus security scan
        System.out.println("Extended scan for viruses...");
        boolean scanResult = true; // Assume the scan is successful

        // Call the base class scan method.
        boolean baseScanResult = super.scan();
        return baseScanResult && scanResult; // Combine results
    }

    @Override
    public String getName() {
        return "Extended Antivirus Security Provider";
    }
}
