using System;

namespace Unity.GraphToolkit.Editor
{
    public interface IGraphViewController : IDisposable
    {
        public void Initialize(IGraphView rootView);
    }
}