package securityproviders;

public interface ISecurityProvider {
    boolean scan();
    String getName();
    ISecurityProvider getNext();
}
