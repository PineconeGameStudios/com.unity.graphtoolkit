using System;

namespace Unity.GraphToolkit.Editor
{
    /// <summary>
    /// Specifies the visual style of the connector used to represent a port in the UI.
    /// </summary>
    /// <remarks>
    /// Use this enum to define how the connector of a port appears visually.
    /// The connector indicates the type or role of the port and can help users understand connection semantics.
    /// </remarks>
    public enum PortPolymorphism
    {
        /// <summary>
        /// Not polymorphic. Requires a concrete type.
        /// </summary>
        None,

        /// <summary>
        /// Supports types from supplied list of types
        /// </summary>
        Explicit,

        /// <summary>
        /// Supports all types available as variable types in the graph's library. Optionally supports additional supplied types.
        /// </summary>
        VariableTypes,
    }
}
