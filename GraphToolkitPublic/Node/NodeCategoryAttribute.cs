using System;

namespace Unity.GraphToolkit.Editor
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NodeCategoryAttribute : Attribute
    {
        public string Category { get; set; }

        public NodeCategoryAttribute(string category)
        {
            this.Category = category;
        }
    }
}
