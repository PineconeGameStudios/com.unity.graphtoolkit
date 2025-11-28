using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.GraphToolkit.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.GraphToolkit.Editor.Implementation
{
    class GraphViewImp : GraphView, IGraphView
    {
        IGraphViewController controller;

        public GraphViewImp(EditorWindow window, GraphTool graphTool, string graphViewName, GraphRootViewModel graphViewModel, ViewSelection viewSelection, GraphViewDisplayMode displayMode = GraphViewDisplayMode.Interactive, TypeHandleInfos typeHandleInfos = null)
            : base(window, graphTool, graphViewName, graphViewModel, viewSelection, displayMode, typeHandleInfos)
        {
        }

        public override void Update()
        {
            base.Update();

            if (controller == null && GraphModel is GraphModelImp graphModelImp)
            {
                var graphAttribute = graphModelImp.Graph.GetType().GetCustomAttribute<GraphAttribute>();
                if (graphAttribute != null && graphAttribute.controller != null)
                {
                    controller = (IGraphViewController)Activator.CreateInstance(graphAttribute.controller);
                    controller.Initialize(this);
                }
            }
        }

        Graph IGraphView.Graph => (GraphModel as GraphModelImp)?.Graph;

        protected override IDragAndDropHandler GraphAssetDragAndDropHandler
        {
            get
            {
                if (GraphModel is GraphModelImp graphModelImp)
                {
                    var graphAttribute = graphModelImp.Graph.GetType().GetCustomAttribute<GraphAttribute>();
                    if (graphAttribute != null && graphAttribute.options.HasFlag(GraphOptions.SupportsSubgraphs))
                    {
                        // Only add subgraph drag and drop handler if the graph supports subgraphs
                        return m_SubgraphAssetDragAndDropHandler ??= new SubgraphDragAndDropHandler(this);
                    }
                }

                return null;
            }
        }

        protected override ItemLibraryHelper CreateItemLibraryHelper()
        {
            return (Window as GraphViewEditorWindow)?.CreateItemLibraryHelper(GraphModel);
        }

        public override GraphView CreateSimplePreview()
        {
            return new PreviewGraphViewImp(null, null, "",  null, null, GraphViewDisplayMode.NonInteractive);
        }

        internal void CallBuildContextualMenuForTests(ContextualMenuPopulateEvent evt)
        {
            BuildContextualMenu(evt);
            evt.menu.PrepareForDisplay(evt.triggerEvent);
        }

        protected override void Dispose(bool disposing)
        {
            controller?.Dispose();
            controller = null;

            base.Dispose(disposing);
        }
    }
}
