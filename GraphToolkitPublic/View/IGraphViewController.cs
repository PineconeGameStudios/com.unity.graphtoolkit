using System;

namespace Unity.GraphToolkit.Editor
{
	public interface IGraphViewController : IDisposable
	{
		public void SetRootView(IGraphView rootView);

		public void OnEnable();
	}
}