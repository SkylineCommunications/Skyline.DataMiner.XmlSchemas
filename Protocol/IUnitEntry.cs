namespace Skyline.DataMiner.XmlSchemas.Protocol
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a unit.
    /// </summary>
    public interface IUnitEntry
	{
        /// <summary>
        /// Gets the name of the unit.
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Gets the value of the unit.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Gets a value indicating whether the unit should be ignored in description checks.
        /// </summary>
        bool IgnoreInDescription { get; }

        /// <summary>
        /// Gets the legacy notations.
        /// </summary>
        IList<string> LegacyNotations { get; }
	}
}