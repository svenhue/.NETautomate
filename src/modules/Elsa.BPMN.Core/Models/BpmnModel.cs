/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Elsa.BPMN.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

/// <summary>
/// @author Tijs Rademakers
/// @author Joram Barrez
/// </summary>
public class BpmnModel
{
    protected Dictionary<string, List<ExtensionAttribute>> definitionsAttributes = new();
    protected List<Process> processes = new();
    protected Dictionary<string, GraphicInfo> locationMap = new();
    protected Dictionary<string, GraphicInfo> labelLocationMap = new();
    protected Dictionary<string, List<GraphicInfo>> flowLocationMap = new();
    protected Dictionary<string, BpmnDiEdge> edgeMap = new();
    protected List<Signal> signals = new();
    protected Dictionary<string, MessageFlow> messageFlowMap = new();
    protected Dictionary<string, Message> messageMap = new();
    protected Dictionary<string, List<string>> variableListenerToActivityMap = new();
    protected Dictionary<string, string> errorMap = new();
    protected Dictionary<string, Escalation> escalationMap = new();
    protected Dictionary<string, ItemDefinition> itemDefinitionMap = new();
    protected Dictionary<string, DataStore> dataStoreMap = new();
    protected List<Pool> pools = new();
    protected List<Import> imports = new();
    protected List<Interface> interfaces = new();
    protected List<Artifact> globalArtifacts = new();
    protected List<Resource> resources = new();
    protected Dictionary<string, string> namespaceMap = new();
    protected string targetNamespace;
    protected string sourceSystemId;
    protected List<string> userTaskFormTypes;
    protected List<string> startEventFormTypes;
    protected object eventSupport;
    protected string exporter;
    protected string exporterVersion;

    public Dictionary<string, List<ExtensionAttribute>> DefinitionsAttributes
    {
        get { return definitionsAttributes; }
        set { definitionsAttributes = value; }
    }

    public string GetDefinitionsAttributeValue(string @namespace, string name)
    {
        if (DefinitionsAttributes.TryGetValue(name, out var attributes) && attributes.Any())
        {
            return attributes.FirstOrDefault(attribute => 
                @namespace.Equals(attribute.getNamespace())).getValue();
        }
        return null;
    }

    public void AddDefinitionsAttribute(ExtensionAttribute attribute)
    {
        if (attribute != null && !string.IsNullOrEmpty(attribute.getName()))
        {
            if (!this.definitionsAttributes.ContainsKey(attribute.getName()))
            {
                this.definitionsAttributes[attribute.getName()] = new List<ExtensionAttribute>();
            }
            this.definitionsAttributes[attribute.getName()].Add(attribute);
        }
    }

    public Process MainProcess
    {
        get
        {
            if (Pools.Any())
            {
                var process = GetProcess(Pools[0].Id);
                if (process != null)
                {
                    return process;
                }
            }
            return GetProcessWithoutPool();
        }
    }

    private Process GetProcessWithoutPool()
    {
        return GetProcess(null);
    }

    public Process GetProcess(string poolRef)
    {
        foreach (var process in processes)
        {
            bool foundPool = false;
            foreach (var pool in pools)
            {
                if (!string.IsNullOrEmpty(pool.ProcessRef) && 
                    pool.ProcessRef.Equals(process.Id, StringComparison.OrdinalIgnoreCase))
                {
                    if (poolRef != null)
                    {
                        if (pool.Id.Equals(poolRef, StringComparison.OrdinalIgnoreCase))
                        {
                            foundPool = true;
                        }
                    }
                    else
                    {
                        foundPool = true;
                    }
                }
            }

            if (poolRef == null && !foundPool && process.Executable)
            {
                return process;
            }
            else if (poolRef != null && foundPool)
            {
                return process;
            }
        }
        
        if (poolRef == null && processes.Any())
        {
            return processes[0];
        }

        return null;
    }

    public Process GetProcessById(string id)
    {
        return processes.FirstOrDefault(process => process.Id.Equals(id));
    }

    public List<Process> Processes
    {
        get { return processes; }
    }

    public void AddProcess(Process process)
    {
        processes.Add(process);
    }

    public Pool GetPool(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            return pools.FirstOrDefault(pool => id.Equals(pool.Id));
        }
        return null;
    }

    public Lane GetLane(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            foreach (var process in processes)
            {
                var lane = process.Lanes.FirstOrDefault(l => id.Equals(l.Id));
                if (lane != null)
                {
                    return lane;
                }
            }
        }
        return null;
    }

    public FlowElement GetFlowElement(string id)
    {
        FlowElement foundFlowElement = null;
        foreach (var process in processes)
        {
            foundFlowElement = process.GetFlowElement(id);
            if (foundFlowElement != null)
            {
                break;
            }
        }

        if (foundFlowElement == null)
        {
            foreach (var process in processes)
            {
                foreach (var flowElement in process.FindFlowElementsOfType<SubProcess>())
                {
                    foundFlowElement = GetFlowElementInSubProcess(id, (SubProcess)flowElement);
                    if (foundFlowElement != null)
                    {
                        break;
                    }
                }
                if (foundFlowElement != null)
                {
                    break;
                }
            }
        }

        return foundFlowElement;
    }

    protected FlowElement GetFlowElementInSubProcess(string id, SubProcess subProcess)
    {
        var foundFlowElement = subProcess.GetFlowElement(id);
        if (foundFlowElement == null)
        {
            foreach (var flowElement in subProcess.GetFlowElements())
            {
                if (flowElement is SubProcess)
                {
                    foundFlowElement = GetFlowElementInSubProcess(id, (SubProcess)flowElement);
                    if (foundFlowElement != null)
                    {
                        break;
                    }
                }
            }
        }
        return foundFlowElement;
    }

    public Artifact GetArtifact(string id)
    {
        Artifact foundArtifact = null;
        foreach (var process in processes)
        {
            foundArtifact = process.GetArtifact(id);
            if (foundArtifact != null)
            {
                break;
            }
        }

        if (foundArtifact == null)
        {
            foreach (var process in processes)
            {
                foreach (var flowElement in process.FindFlowElementsOfType<SubProcess>())
                {
                    foundArtifact = GetArtifactInSubProcess(id, (SubProcess)flowElement);
                    if (foundArtifact != null)
                    {
                        break;
                    }
                }
                if (foundArtifact != null)
                {
                    break;
                }
            }
        }

        return foundArtifact;
    }

    protected Artifact GetArtifactInSubProcess(string id, SubProcess subProcess)
    {
        var foundArtifact = subProcess.GetArtifact(id);
        if (foundArtifact == null)
        {
            foreach (var flowElement in subProcess.GetFlowElements())
            {
                if (flowElement is SubProcess)
                {
                    foundArtifact = GetArtifactInSubProcess(id, (SubProcess)flowElement);
                    if (foundArtifact != null)
                    {
                        break;
                    }
                }
            }
        }
        return foundArtifact;
    }

    public void AddGraphicInfo(string key, GraphicInfo graphicInfo)
    {
        locationMap[key] = graphicInfo;
    }

    public GraphicInfo GetGraphicInfo(string key)
    {
        return locationMap.TryGetValue(key, out var info) ? info : null;
    }

    public void RemoveGraphicInfo(string key)
    {
        locationMap.Remove(key);
    }

    public List<GraphicInfo> GetFlowLocationGraphicInfo(string key)
    {
        return flowLocationMap.TryGetValue(key, out var info) ? info : null;
    }

    public void RemoveFlowGraphicInfoList(string key)
    {
        flowLocationMap.Remove(key);
    }
    
    public BpmnDiEdge GetEdgeInfo(string key)
    {
        return edgeMap.TryGetValue(key, out var info) ? info : null;
    }
    
    public void AddEdgeInfo(string key, BpmnDiEdge edgeInfo)
    {
        edgeMap[key] = edgeInfo;
    }

    public Dictionary<string, GraphicInfo> LocationMap => locationMap;

    public Dictionary<string, List<GraphicInfo>> FlowLocationMap => flowLocationMap;

    public Dictionary<string, BpmnDiEdge> EdgeMap => edgeMap;

    public GraphicInfo GetLabelGraphicInfo(string key)
    {
        return labelLocationMap.TryGetValue(key, out var info) ? info : null;
    }

    public void AddLabelGraphicInfo(string key, GraphicInfo graphicInfo)
    {
        labelLocationMap[key] = graphicInfo;
    }

    public void RemoveLabelGraphicInfo(string key)
    {
        labelLocationMap.Remove(key);
    }

    public Dictionary<string, GraphicInfo> LabelLocationMap => labelLocationMap;

    public void AddFlowGraphicInfoList(string key, List<GraphicInfo> graphicInfoList)
    {
        flowLocationMap[key] = graphicInfoList;
    }

    public ICollection<Resource> Resources => resources;

    public void SetResources(ICollection<Resource> resourceList)
    {
        if (resourceList != null)
        {
            resources.Clear();
            resources.AddRange(resourceList);
        }
    }

    public void AddResource(Resource resource)
    {
        if (resource != null)
        {
            resources.Add(resource);
        }
    }

    public bool ContainsResourceId(string resourceId)
    {
        return GetResource(resourceId) != null;
    }

    public Resource GetResource(string id)
    {
        return resources.FirstOrDefault(resource => id.Equals(resource.Id));
    }

    public ICollection<Signal> Signals => signals;

    public void SetSignals(ICollection<Signal> signalList)
    {
        if (signalList != null)
        {
            signals.Clear();
            signals.AddRange(signalList);
        }
    }

    public void AddSignal(Signal signal)
    {
        if (signal != null)
        {
            signals.Add(signal);
        }
    }

    public bool ContainsSignalId(string signalId)
    {
        return GetSignal(signalId) != null;
    }

    public Signal GetSignal(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            return signals.FirstOrDefault(signal => id.Equals(signal.Id));
        }
        return null;
    }

    public Dictionary<string, MessageFlow> MessageFlows
    {
        get { return messageFlowMap; }
        set { messageFlowMap = value; }
    }

    public void AddMessageFlow(MessageFlow messageFlow)
    {
        if (messageFlow != null && !string.IsNullOrEmpty(messageFlow.Id))
        {
            messageFlowMap[messageFlow.Id] = messageFlow;
        }
    }

    public MessageFlow GetMessageFlow(string id)
    {
        return messageFlowMap.TryGetValue(id, out var flow) ? flow : null;
    }

    public bool ContainsMessageFlowId(string messageFlowId)
    {
        return messageFlowMap.ContainsKey(messageFlowId);
    }

    public ICollection<Message> Messages => messageMap.Values;

    public void SetMessages(ICollection<Message> messageList)
    {
        if (messageList != null)
        {
            messageMap.Clear();
            foreach (var message in messageList)
            {
                AddMessage(message);
            }
        }
    }

    public void AddMessage(Message message)
    {
        if (message != null && !string.IsNullOrEmpty(message.Id))
        {
            messageMap[message.Id] = message;
        }
    }

    public Message GetMessage(string id)
    {
        if (messageMap.TryGetValue(id, out var result))
        {
            return result;
        }

        var indexOfNS = id.IndexOf(':');
        if (indexOfNS > 0)
        {
            var idNamespace = id.Substring(0, indexOfNS);
            if (idNamespace.Equals(this.TargetNamespace, StringComparison.OrdinalIgnoreCase))
            {
                id = id.Substring(indexOfNS + 1);
            }
            messageMap.TryGetValue(id, out result);
        }
        return result;
    }
    
    public bool ContainsMessageId(string messageId)
    {
        return messageMap.ContainsKey(messageId);
    }
    
    public List<string> GetActivityIdsForVariableListenerName(string variableName)
    {
        return variableListenerToActivityMap.TryGetValue(variableName, out var ids) ? ids : null;
    }

    public void AddActivityIdForVariableListenerName(string variableName, string activityId)
    {
        if (!variableListenerToActivityMap.TryGetValue(variableName, out var activityIds))
        {
            activityIds = new List<string>();
            variableListenerToActivityMap[variableName] = activityIds;
        }
        
        activityIds.Add(activityId);
    }

    public bool ContainsVariableListenerForVariableName(string variableName)
    {
        return variableListenerToActivityMap.ContainsKey(variableName);
    }
    
    public bool HasVariableListeners => variableListenerToActivityMap.Any();

    public Dictionary<string, string> Errors
    {
        get { return errorMap; }
        set { errorMap = value; }
    }

    public void AddError(string errorRef, string errorCode)
    {
        if (!string.IsNullOrEmpty(errorRef))
        {
            errorMap[errorRef] = errorCode;
        }
    }

    public bool ContainsErrorRef(string errorRef)
    {
        return errorMap.ContainsKey(errorRef);
    }
    
    public ICollection<Escalation> Escalations => escalationMap.Values;

    public void SetEscalations(Dictionary<string, Escalation> escalationMap)
    {
        this.escalationMap = escalationMap;
    }

    public void AddEscalation(string escalationRef, string escalationCode, string name)
    {
        if (!string.IsNullOrEmpty(escalationRef))
        {
            escalationMap[escalationRef] = new Escalation(escalationRef, name, escalationCode);
        }
    }
    
    public void AddEscalation(Escalation escalation)
    {
        if (!string.IsNullOrEmpty(escalation.getEscalationCode()))
        {
            escalationMap[escalation.getEscalationCode()] = escalation;
        }
    }

    public bool ContainsEscalationRef(string escalationRef)
    {
        return escalationMap.ContainsKey(escalationRef);
    }
    
    public Escalation GetEscalation(string escalationRef)
    {
        return escalationMap.TryGetValue(escalationRef, out var escalation) ? escalation : null;
    }

    public Dictionary<string, ItemDefinition> ItemDefinitions
    {
        get { return itemDefinitionMap; }
        set { itemDefinitionMap = value; }
    }

    public void AddItemDefinition(string id, ItemDefinition item)
    {
        if (!string.IsNullOrEmpty(id))
        {
            itemDefinitionMap[id] = item;
        }
    }

    public bool ContainsItemDefinitionId(string id)
    {
        return itemDefinitionMap.ContainsKey(id);
    }

    public Dictionary<string, DataStore> DataStores
    {
        get { return dataStoreMap; }
        set { dataStoreMap = value; }
    }

    public DataStore GetDataStore(string id)
    {
        return dataStoreMap.TryGetValue(id, out var dataStore) ? dataStore : null;
    }

    public void AddDataStore(string id, DataStore dataStore)
    {
        if (!string.IsNullOrEmpty(id))
        {
            dataStoreMap[id] = dataStore;
        }
    }

    public bool ContainsDataStore(string id)
    {
        return dataStoreMap.ContainsKey(id);
    }

    public List<Pool> Pools
    {
        get { return pools; }
        set { pools = value; }
    }

    public List<Import> Imports
    {
        get { return imports; }
        set { imports = value; }
    }

    public List<Interface> Interfaces
    {
        get { return interfaces; }
        set { interfaces = value; }
    }

    public List<Artifact> GlobalArtifacts
    {
        get { return globalArtifacts; }
        set { globalArtifacts = value; }
    }

    public void AddNamespace(string prefix, string uri)
    {
        namespaceMap[prefix] = uri;
    }

    public bool ContainsNamespacePrefix(string prefix)
    {
        return namespaceMap.ContainsKey(prefix);
    }

    public string GetNamespace(string prefix)
    {
        return namespaceMap.TryGetValue(prefix, out var uri) ? uri : null;
    }

    public Dictionary<string, string> Namespaces => namespaceMap;

    public string TargetNamespace
    {
        get { return targetNamespace; }
        set { targetNamespace = value; }
    }

    public string SourceSystemId
    {
        get { return sourceSystemId; }
        set { sourceSystemId = value; }
    }

    public List<string> UserTaskFormTypes
    {
        get { return userTaskFormTypes; }
        set { userTaskFormTypes = value; }
    }

    public List<string> StartEventFormTypes
    {
        get { return startEventFormTypes; }
        set { startEventFormTypes = value; }
    }

    [JsonIgnore]
    public object EventSupport
    {
        get { return eventSupport; }
        set { eventSupport = value; }
    }

    public string Exporter
    {
        get { return exporter; }
        set { exporter = value; }
    }

    public string ExporterVersion
    {
        get { return exporterVersion; }
        set { exporterVersion = value; }
    }
}
