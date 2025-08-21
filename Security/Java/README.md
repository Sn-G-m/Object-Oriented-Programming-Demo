# OOP Principles Demo — Java Port

This is a 1:1 Java port of the .NET solution in `.NET/`, using a Maven multi-module layout.

**All credits to the starter files for this project goes to https://github.com/chittur**
- Modules:
  - `security-providers` (library with providers)
  - `controller` (console app)

## Prerequisites
- Java 17+
- Apache Maven 3.8+

## Build
```bash
# From the repo root
cd Java
mvn -q clean package
```

## Run (option A: via Maven Exec)
```bash
cd Java
mvn -q -pl controller exec:java -Dexec.mainClass=controller.Program
```

## Run (option B: shaded JAR)
```bash
cd Java
java -jar controller/target/controller-1.0-SNAPSHOT-shaded.jar
```

## Expected output (sample)
```
Using Device Security Provider
Scanning device security...
Device Security Provider scan completed successfully.

Using Online Account Security Provider
Scanning online account security...
Scanning account security...
Online Account Security Provider scan completed successfully.

Using Account Security Provider
Scanning account security...
Account Security Provider scan completed successfully.

Using Antivirus Security Provider
Scanning for viruses...
Antivirus Security Provider scan completed successfully.

Using Extended Antivirus Security Provider
Extended scan for viruses...
Scanning for viruses...
Extended Antivirus Security Provider scan completed successfully.

Using Hard-disk Security Provider
Scanning hard-disk...
Hard-disk Security Provider scan completed successfully.


Process finished with exit code 0
```

Tip: If Maven reports cached plugin resolution errors, retry with:
```bash
mvn -U clean package
```
