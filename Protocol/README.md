# Protocol Schema

This directory contains the DataMiner Protocol XML Schema Definition (XSD) and Units of Measurement (UOM) definitions.

## Overview

The `protocol.xsd` file is the main XML Schema Definition for DataMiner protocols (connectors). It defines the complete structure and validation rules for protocol XML files used in DataMiner systems.

The `uom.xsd` file defines all the units of measurement that can be used in DataMiner protocols. When you need to add a new unit to be used in protocol definitions, you must extend the `uom.xsd` schema.

### How to Add Units

#### Step 1: Understand the Current Structure

The `uom.xsd` file contains a `UOM` simple type with a list of enumeration values. Each unit is defined as an enumeration with:
- A string value (e.g., "m", "kg", "W")
- An annotation with documentation and appinfo metadata

#### Step 2: Add the Enumeration Entry

Locate the appropriate position in the enumeration list (units are generally organized alphabetically). Add a new enumeration entry with the following structure:

```xml
<xs:enumeration value="YourUnitSymbol">
    <xs:annotation>
        <xs:documentation>Unit full description</xs:documentation>
        <xs:appinfo>
            <slu:name>Unit full description</slu:name>
            <slu:ignoreInDescription>false</slu:ignoreInDescription>
        </xs:appinfo>
    </xs:annotation>
</xs:enumeration>
```

#### Step 3: Understand the Metadata

- **value**: The unit symbol or abbreviation (e.g., "m" for meter, "kg" for kilogram)
- **slu:name**: The full descriptive name of the unit
- **slu:ignoreInDescription**: Set to `true` if  the unit should be ignored in description checks, `false` otherwise.

#### Step 4: Legacy Notations (Optional)

For units that have old notations, you can add legacy notations:

```xml
<xs:enumeration value="NewUnitName">
    <xs:annotation>
        <xs:documentation>Unit description</xs:documentation>
        <xs:appinfo>
            <slu:name>Unit description</slu:name>
            <slu:ignoreInDescription>false</slu:ignoreInDescription>
            <slu:legacyNotations>
                <slu:legacyNotation>oldNotation1</slu:legacyNotation>
                <slu:legacyNotation>oldNotation2</slu:legacyNotation>
            </slu:legacyNotations>
        </xs:appinfo>
    </xs:annotation>
</xs:enumeration>
```

#### Example: Adding Meters Per Square Second (m/s²)

```xml
<xs:enumeration value="m/s²">
    <xs:annotation>
        <xs:documentation>meter per square second (acceleration)</xs:documentation>
        <xs:appinfo>
            <slu:name>meter per square second (acceleration)</slu:name>
            <slu:ignoreInDescription>false</slu:ignoreInDescription>
        </xs:appinfo>
    </xs:annotation>
</xs:enumeration>
```

#### Testing Your Changes

After adding a unit to `uom.xsd`:

1. Verify the XML is well-formed (proper closing tags and structure)
2. Ensure the enumeration value is unique
3. Build the solution to verify schema validation passes
4. Update related documentation if the unit should appear in user-facing materials

#### Common Unit Categories

Units in the schema are typically organized into these categories:

- **SI Units**: meter (m), kilogram (kg), second (s), ampere (A), etc.
- **Prefixed Units**: kilo-, mega-, giga-, milli-, micro-, nano-, etc.
- **Frequency Units**: hertz (Hz), kilohertz (kHz), etc.
- **Power/Energy Units**: watt (W), joule (J), etc.
- **Pressure Units**: pascal (Pa), bar, etc.
- **Custom Units**: count-based or dimensionless units like "Alarms", "Blocks", etc.

#### Notes

- The schema maintains backward compatibility, so existing protocols continue to work
- Units are case-sensitive in protocol definitions
- New units should follow established naming conventions (SI units preferred)
- The `ignoreInDescription` flag affects how the unit is displayed in DataMiner applications
