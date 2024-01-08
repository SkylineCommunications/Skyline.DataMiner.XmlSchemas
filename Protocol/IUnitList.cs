namespace Skyline.DataMiner.XmlSchemas.Protocol
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the UOM file.
    /// </summary>
    public interface IUnitList
    {
        /// <summary>
        /// Gets the units.
        /// </summary>
        IReadOnlyCollection<IUnitEntry> Units { get; }
    }
}