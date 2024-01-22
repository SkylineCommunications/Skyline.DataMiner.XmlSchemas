namespace Skyline.DataMiner.XmlSchemas.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Represents the Units of Measurement (UOM) file.
    /// </summary>
    /// <seealso cref="Skyline.DataMiner.XmlSchemas.Protocol.IUnitList" />
    public class UnitList : IUnitList
    {
        private List<IUnitEntry> units;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitList"/> class.
        /// The default UOM file will be used.
        /// </summary>
        internal UnitList()
        {
            var uomFilePath = GetUomFilePath();
            XDocument schema = XDocument.Load(uomFilePath);
            LoadUomXsd(schema);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitList"/> class.
        /// </summary>
        /// <param name="uomFilePath">The UOM file path.</param>
        /// <exception cref="ArgumentNullException"><paramref name="uomFilePath"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="uomFilePath"/> is empty or white space.</exception>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="uomFilePath"/> was not found.</exception>
        public UnitList(string uomFilePath)
        {
            if (uomFilePath == null) throw new ArgumentNullException(nameof(uomFilePath));

            if (String.IsNullOrWhiteSpace(uomFilePath)) throw new ArgumentException("File path is empty or white space.", nameof(uomFilePath));

            if (!File.Exists(uomFilePath)) throw new FileNotFoundException($"The specified file '{uomFilePath}' was not found.");

            XDocument schema = XDocument.Load(uomFilePath);
            LoadUomXsd(schema);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitList"/> class.
        /// </summary>
        /// <param name="schema">The UOM schema.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UnitList(XDocument schema)
        {
            if (schema == null) throw new ArgumentNullException(nameof(schema));

            LoadUomXsd(schema);
        }

        /// <inheritdoc />
        public IReadOnlyCollection<IUnitEntry> Units => units.AsReadOnly();

        private void LoadUomXsd(XDocument schema)
        {
            XNamespace xs = schema.Root.Name.Namespace;
            XNamespace slu = "http://www.skyline.be/uomapp";

            var listUnits = schema
                            .Root
                            .Descendants(xs + "simpleType")
                            .Descendants(xs + "restriction")
                            .Descendants(xs + "enumeration");

            List<IUnitEntry> uoms = new List<IUnitEntry>();

            foreach (XElement unit in listUnits)
            {
                string value = unit.Attribute("value").Value;
                var appinfo = unit.Element(xs + "annotation")?.Element(xs + "appinfo");
                string name = appinfo?.Element(slu + "name")?.Value;
                bool ignoreInDescription = Convert.ToBoolean(appinfo?.Element(slu + "ignoreInDescription")?.Value);
                var legacyNotations = appinfo?.Element(slu + "legacyNotations")?.Elements(slu + "legacyNotation")?.Select(x => x?.Value).ToArray() ?? new string[0];

                var uom = new UnitEntry(name, value, ignoreInDescription, legacyNotations);
                uoms.Add(uom);
            }

            units = uoms.OrderBy(x => x.Name).ToList();
        }

        private static string GetUomFilePath()
        {
            string root = Path.GetDirectoryName(typeof(UnitList).Assembly.Location);
            return Path.Combine(root, "Skyline", "XSD", "uom.xsd");
        }
    }
}