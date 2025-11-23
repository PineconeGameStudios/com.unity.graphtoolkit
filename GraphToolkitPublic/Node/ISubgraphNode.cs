using System;
using Unity.GraphToolkit.Editor.Implementation;

namespace Unity.GraphToolkit.Editor
{
    /// <summary>
    /// Interface for a specialized node that references a subgraph and exposes its input and output variables as ports.
    /// </summary>
    /// <remarks>
    /// Subgraph nodes act as entry points to reusable graphs. These nodes mirror the subgraph's inputs and outputs
    ///   as ports on the node to allow the integration of subgraphs within a main graph.
    /// The subgraph must be a valid <see cref="Graph"/> type. The main graph must support subgraphs through <see cref="GraphOptions.SupportsSubgraphs"/>,
    /// and the subgraph must be linked to the main graph using the <see cref="SubgraphAttribute"/>.
    /// </remarks>
    public interface ISubgraphNode : INode
    {
        /// <summary>
        /// Retrieves the subgraph linked to this node.
        /// </summary>
        /// <returns>The <see cref="Graph"/> instance that this node references.</returns>
        /// <remarks>
        /// Call this method to access the subgraph that provides the behavior for this node.
        /// The subgraph defines input and output variables that appear as ports on the subgraph node.
        /// This method does not create or modify the subgraph.
        /// </remarks>
        Graph GetSubgraph();

        /// <summary>
        /// Retrieves the subgraph variable linked to the input port at the given index.
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        IVariable GetVariableForInputPort(int index);

        /// <summary>
        /// Retrieves the subgraph variable linked to the output port at the given index.
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        IVariable GetVariableForOutputPort(int index);

        /// <summary>
        /// Retrieves the subgraph variable linked to the given input port.
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        IVariable GetVariableForInputPort(IPort port);

        /// <summary>
        /// Retrieves the subgraph variable linked to the given output port.
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        IVariable GetVariableForOutputPort(IPort port);

        /// <summary>
        /// Returns the subgraph input port linked to the given input variable within the subgraph.
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        IPort GetInputPortForVariable(IVariable variable);

        /// <summary>
        /// Returns the subgraph output port linked to the given output variable within the subgraph.
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        IPort GetOutputPortForVariable(IVariable variable);
    }
}
