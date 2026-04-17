using System;
using UnityEngine;

namespace Unity.GraphToolkit.Editor.Implementation
{
    [Serializable]
    class SubgraphNodeModelImp : SubgraphNodeModel, ISubgraphNode
    {
        public Graph GetSubgraph()
        {
            var graphModel = GetSubgraphModel();

            return (graphModel as GraphModelImp)?.Graph;
        }

        public bool TryGetSubgraphAssetGuid(out UnityEditor.GUID assetGuid)
        {
            assetGuid = SubgraphReference.AssetGuid;
            return assetGuid != default;
        }

        public IVariable GetVariableForInputPort(int index)
        {
            INode self = this;
            return GetVariableForInputPort(self.GetInputPort(index));
        }

        public IVariable GetVariableForInputPort(IPort port)
        {
            if(port is PortModel portModel && InputPortToVariableDeclarationDictionary.TryGetValue(portModel, out var variable))
                return variable;

            return null;
        }

        public IVariable GetVariableForOutputPort(int index)
        {
            INode self = this;
            return GetVariableForOutputPort(self.GetOutputPort(index));
        }

        public IVariable GetVariableForOutputPort(IPort port)
        {
            if(port is PortModel portModel && OutputPortToVariableDeclarationDictionary.TryGetValue(portModel, out var variable))
                return variable;

            return null;
        }

        public IPort GetInputPortForVariable(IVariable variable)
        {
            foreach(var (k, v) in InputPortToVariableDeclarationDictionary)
                if(v == variable)
                    return k;

            return null;
        }

        public IPort GetOutputPortForVariable(IVariable variable)
        {
            foreach(var (k, v) in OutputPortToVariableDeclarationDictionary)
                if(v == variable)
                    return k;

            return null;
        }
    }
}
