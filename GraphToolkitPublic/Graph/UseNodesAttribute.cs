using System;

namespace Unity.GraphToolkit.Editor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class UseNodesAttribute : Attribute
    {
        public Type BaseType { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UseNodesAttribute"/> class.
        /// </summary>
        /// <param name="baseType">
        /// Base type (class or interface)
        /// </param>
        /// <remarks>
        /// Use this attribute to declare that a Graph type can additionally
        /// use nodes derived from the base type even if they are defined in
        /// another assembly.
        /// </remarks>
        /// <example>
        /// <code>
        /// // This declares a graph that uses nodes derived from ICommonNode
        /// [UseNodes(typeof(ICommonNode))]
        /// public class MyGraph : Graph
        /// </code>
        /// </example>
        public UseNodesAttribute(Type baseType)
        {
            BaseType = baseType;
        }

    }
}
