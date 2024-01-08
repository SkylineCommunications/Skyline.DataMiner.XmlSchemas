namespace Skyline.DataMiner.XmlSchemas.Protocol
{
    using System.Collections.Generic;

    internal class UnitEntry : IUnitEntry
    {
        public UnitEntry(string name, string value, bool ignoreInDescription, IList<string> legacyNotations)
        {
            Name = name;
            Value = value;
            IgnoreInDescription = ignoreInDescription;
            LegacyNotations = legacyNotations;
        }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public string Value { get; }

        /// <inheritdoc />
        public bool IgnoreInDescription { get; }

        /// <inheritdoc />
        public IList<string> LegacyNotations { get; }
    }
}