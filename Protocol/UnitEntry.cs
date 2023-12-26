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
        /// <summary>
        /// Gets the name of the unit.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the unit.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets a value indicating whether the unit should be ignored in description checks.
        /// </summary>
        public bool IgnoreInDescription { get; }

        /// <summary>
        /// Gets the legacy notations.
        /// </summary>
        public IList<string> LegacyNotations { get; }
	}
}