using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolkit.ItemLibrary.Editor;

namespace Unity.GraphToolkit.Editor.Implementation
{
    internal class PublicLibraryFilterProvider : ILibraryFilterProvider
    {
        public ItemLibraryFilter GetContextFilter(ContextNodeModel contextNodeModel) => ItemLibraryFuncFilter.Empty;
        public ItemLibraryFilter GetGraphFilter() => ItemLibraryFuncFilter.Empty;

        public ItemLibraryFilter GetInputToGraphFilter(IEnumerable<PortModel> portModels)
            => new ItemLibraryFuncFilter(item => MatchPorts(portModels, item));

        public ItemLibraryFilter GetInputToGraphFilter(PortModel portModel)
            => new ItemLibraryFuncFilter(item => MatchPorts(new[] { portModel }, item));

        public ItemLibraryFilter GetOutputToGraphFilter(IEnumerable<PortModel> portModels)
            => new ItemLibraryFuncFilter(item => MatchPorts(portModels, item));

        public ItemLibraryFilter GetOutputToGraphFilter(PortModel portModel)
            => new ItemLibraryFuncFilter(item => MatchPorts(new[] { portModel }, item));

        public ItemLibraryFilter GetWireFilter(WireModel wireModel) => ItemLibraryFuncFilter.Empty;

        private static bool MatchPorts(IEnumerable<PortModel> portModels, ItemLibraryItem item)
        {
            if(item is not GraphNodeModelLibraryItem nodeItem)
                return true;

            var portModel = portModels.FirstOrDefault();
            if(portModel == null)
                return true;

            var graphModel = portModel.GraphModel;

            var nodeModel = CreateGraphElementModel(graphModel, nodeItem) as NodeModel;
            if(nodeModel == null)
                return true;

            var ports = portModel.Direction == PortDirection.Input ? nodeModel.OutputsByDisplayOrder : nodeModel.InputsByDisplayOrder;
            var compatiblePorts = graphModel.GetCompatiblePorts(ports, portModel);

            return compatiblePorts.Count > 0;
        }

        protected static GraphElementModel CreateGraphElementModel(GraphModel graphModel, GraphNodeModelLibraryItem item)
        {
            return item.CreateElement(
                new GraphNodeCreationData(graphModel, UnityEngine.Vector2.zero, SpawnFlags.Orphan));
        }

    }
}
