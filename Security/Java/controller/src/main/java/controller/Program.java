package controller;

import java.util.ArrayList;
import java.util.List;
import securityproviders.*;

public class Program {
    public static void main(String[] args) {
        // Create the various security provider instances.
        ISecurityProvider deviceSecurity = new DeviceSecurity(null);
        ISecurityProvider onlineAccountSecurity = new OnlineAccountSecurityProvider(deviceSecurity);
        ISecurityProvider accountSecurity = new AccountSecurityProvider(onlineAccountSecurity);
        ISecurityProvider antivirusSecurity = new AntivirusSecurityProvider(accountSecurity);
        ISecurityProvider extendedAntivirusSecurity = new ExtendedAntivirusSecurityProvider(antivirusSecurity);
        ISecurityProvider newHarddiskSecurity = new NewHarddiskSecurityProvider(extendedAntivirusSecurity);

        // Create a list of security providers.
//        List<ISecurityProvider> securityProviders = new ArrayList<>();
//        securityProviders.add(deviceSecurity);
//        securityProviders.add(onlineAccountSecurity);
//        securityProviders.add(accountSecurity);
//        securityProviders.add(antivirusSecurity);
//        securityProviders.add(extendedAntivirusSecurity);
//        securityProviders.add(newHarddiskSecurity);

        // Iterate through each security provider and perform a scan.
        // This will result in recursive scan ending at where it was called initially
        // Therefore the loop implementation for calling each of the security providers, is commented.
//        for (ISecurityProvider provider : securityProviders) {
//            System.out.println("Using " + provider.getName());
//            if (provider.scan()) {
//                System.out.println(provider.getName() + " scan completed successfully.\n");
//            } else {
//                System.out.println(provider.getName() + " scan failed.\n");
//            }
//        }

        // Calling New hard-disk scanner
        System.out.println("Chain of scan initialized.\n");
        if (newHarddiskSecurity.scan()) {
            System.out.println("Chain of scan completed successfully.\n");
        }
    }
}
