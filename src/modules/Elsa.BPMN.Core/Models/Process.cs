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

using System.Collections.Generic;

/// <summary>
/// @author Tijs Rademakers
/// @author Joram Barrez
/// </summary>
public class Process : BaseElement, IFlowElementsContainer, IHasExecutionListeners
{
    protected string name;
    protected bool executable = true;
    protected string documentation;
    protected IOSpecification ioSpecification;
    protected List<FlowableListener> executionListeners = new List<FlowableListener>();
    protected List<Lane> lanes = new List<Lane>();
    protected List<FlowElement> flowElementList = new List<FlowElement>();
    protected List<ValuedDataObject> dataObjects = new List<ValuedDataObject>();
    protected List<Artifact> artifactList = new List<Artifact>();
    protected List<string> candidateStarterUsers = new List<string>();
    protected List<string> candidateStarterGroups = new List<string>();
    protected List<EventListener> eventListeners = new List<EventListener>();
    protected Dictionary<string, FlowElement> flowElementMap = new Dictionary<string, FlowElement>();
    protected Dictionary<string, Artifact> artifactMap = new Dictionary<string, Artifact>();

    // Added during process definition parsing
    protected FlowElement initialFlowElement;
    
    // Performance settings
    protected bool enableEagerExecutionTreeFetching;

    public Process()
    {
    }

    public string Documentation
    {
        get { return documentation; }
        set { documentation = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public bool Executable
    {
        get { return executable; }
        set { executable = value; }
    }

    public IOSpecification IoSpecification
    {
        get { return ioSpecification; }
        set { ioSpecification = value; }
    }

    public List<FlowableListener> ExecutionListeners
    {
        get { return executionListeners; }
        set { executionListeners = value; }
    }

    public List<Lane> Lanes
    {
        get { return lanes; }
        set { lanes = value; }
    }

    public Dictionary<string, FlowElement> FlowElementMap
    {
        get { return flowElementMap; }
        set { flowElementMap = value; }
    }

    public bool ContainsFlowElementId(string id)
    {
        return flowElementMap.ContainsKey(id);
    }

    public FlowElement GetFlowElement(string flowElementId)
    {
        return GetFlowElement(flowElementId, false);
    }

    /// <summary>
    /// Searches the whole process, including subprocesses if searchRecursive is true
    /// </summary>
    public FlowElement GetFlowElement(string flowElementId, bool searchRecursive)
    {
        if (searchRecursive)
        {
            return flowElementMap.ContainsKey(flowElementId) ? flowElementMap[flowElementId] : null;
        }
        else
        {
            return FindFlowElementInList(flowElementId);
        }
    }

    public List<Association> FindAssociationsWithSourceRefRecursive(string sourceRef)
    {
        return FindAssociationsWithSourceRefRecursive(this, sourceRef);
    }

    protected List<Association> FindAssociationsWithSourceRefRecursive(IFlowElementsContainer flowElementsContainer, string sourceRef)
    {
        List<Association> associations = new List<Association>();
        foreach (Artifact artifact in flowElementsContainer.GetArtifacts())
        {
            if (artifact is Association association)
            {
                if (association.SourceRef != null && association.TargetRef != null && association.SourceRef.Equals(sourceRef))
                {
                    associations.Add(association);
                }
            }
        }

        foreach (FlowElement flowElement in flowElementsContainer.GetFlowElements())
        {
            if (flowElement is IFlowElementsContainer container)
            {
                associations.AddRange(FindAssociationsWithSourceRefRecursive(container, sourceRef));
            }
        }
        return associations;
    }

    public List<Association> FindAssociationsWithTargetRefRecursive(string targetRef)
    {
        return FindAssociationsWithTargetRefRecursive(this, targetRef);
    }

    protected List<Association> FindAssociationsWithTargetRefRecursive(IFlowElementsContainer flowElementsContainer, string targetRef)
    {
        List<Association> associations = new List<Association>();
        foreach (Artifact artifact in flowElementsContainer.GetArtifacts())
        {
            if (artifact is Association association)
            {
                if (association.TargetRef != null && association.TargetRef.Equals(targetRef))
                {
                    associations.Add(association);
                }
            }
        }

        foreach (FlowElement flowElement in flowElementsContainer.GetFlowElements())
        {
            if (flowElement is IFlowElementsContainer container)
            {
                associations.AddRange(FindAssociationsWithTargetRefRecursive(container, targetRef));
            }
        }
        return associations;
    }

    /// <summary>
    /// Searches the whole process, including subprocesses
    /// </summary>
    public IFlowElementsContainer GetFlowElementsContainer(string flowElementId)
    {
        return GetFlowElementsContainer(this, flowElementId);
    }

    protected IFlowElementsContainer GetFlowElementsContainer(IFlowElementsContainer flowElementsContainer, string flowElementId)
    {
        foreach (FlowElement flowElement in flowElementsContainer.GetFlowElements())
        {
            if (flowElement.Id != null && flowElement.Id.Equals(flowElementId))
            {
                return flowElementsContainer;
            }
            else if (flowElement is IFlowElementsContainer container)
            {
                IFlowElementsContainer result = GetFlowElementsContainer(container, flowElementId);
                if (result != null)
                {
                    return result;
                }
            }
        }
        return null;
    }

    protected FlowElement FindFlowElementInList(string flowElementId)
    {
        foreach (FlowElement f in flowElementList)
        {
            if (f.Id != null && f.Id.Equals(flowElementId))
            {
                return f;
            }
        }
        return null;
    }

    public ICollection<FlowElement> GetFlowElements()
    {
        return flowElementList;
    }

    public void AddFlowElement(FlowElement element)
    {
        flowElementList.Add(element);
        element.ParentContainer = this;
        AddFlowElementToMap(element);
    }

    public void AddFlowElementToMap(FlowElement element)
    {
        if (element != null && !string.IsNullOrEmpty(element.Id))
        {
            flowElementMap[element.Id] = element;
        }
    }

    public void RemoveFlowElement(string elementId)
    {
        if (flowElementMap.ContainsKey(elementId))
        {
            FlowElement element = flowElementMap[elementId];
            flowElementList.Remove(element);
            flowElementMap.Remove(element.Id);
        }
    }

    public void RemoveFlowElementFromMap(string elementId)
    {
        if (!string.IsNullOrEmpty(elementId))
        {
            flowElementMap.Remove(elementId);
        }
    }

    public Artifact GetArtifact(string id)
    {
        Artifact foundArtifact = null;
        foreach (Artifact artifact in artifactList)
        {
            if (id.Equals(artifact.Id))
            {
                foundArtifact = artifact;
                break;
            }
        }
        return foundArtifact;
    }

    public ICollection<Artifact> GetArtifacts()
    {
        return artifactList;
    }
    
    public Dictionary<string, Artifact> GetArtifactMap()
    {
        return artifactMap;
    }

    public void AddArtifact(Artifact artifact)
    {
        artifactList.Add(artifact);
        AddArtifactToMap(artifact);
    }
    
    public void AddArtifactToMap(Artifact artifact)
    {
        if (artifact != null && !string.IsNullOrEmpty(artifact.Id))
        {
            artifactMap[artifact.Id] = artifact;
        }
    }

    public void RemoveArtifact(string artifactId)
    {
        Artifact artifact = GetArtifact(artifactId);
        if (artifact != null)
        {
            artifactList.Remove(artifact);
        }
    }

    public List<string> CandidateStarterUsers
    {
        get { return candidateStarterUsers; }
        set { candidateStarterUsers = value; }
    }

    public List<string> CandidateStarterGroups
    {
        get { return candidateStarterGroups; }
        set { candidateStarterGroups = value; }
    }

    public List<EventListener> EventListeners
    {
        get { return eventListeners; }
        set { eventListeners = value; }
    }

    public List<T> FindFlowElementsOfType<T>() where T : FlowElement
    {
        return FindFlowElementsOfType<T>(true);
    }

    public List<T> FindFlowElementsOfType<T>(bool goIntoSubprocesses) where T : FlowElement
    {
        List<T> foundFlowElements = new List<T>();
        foreach (FlowElement flowElement in this.GetFlowElements())
        {
            if (flowElement is T element)
            {
                foundFlowElements.Add(element);
            }

            if (flowElement is SubProcess subProcess)
            {
                if (goIntoSubprocesses)
                {
                    foundFlowElements.AddRange(FindFlowElementsInSubProcessOfType<T>(subProcess));
                }
            }
        }
        return foundFlowElements;
    }
    public Dictionary<String, FlowElement> GetFlowElementMap() {
        return flowElementMap;
    }
    
    public List<T> FindFlowElementsInSubProcessOfType<T>(SubProcess subProcess) where T : FlowElement
    {
        return FindFlowElementsInSubProcessOfType<T>(subProcess, true);
    }

    public List<T> FindFlowElementsInSubProcessOfType<T>(SubProcess subProcess, bool goIntoSubprocesses) where T : FlowElement
    {
        List<T> foundFlowElements = new List<T>();
        foreach (FlowElement flowElement in subProcess.GetFlowElements())
        {
            if (flowElement is T element)
            {
                foundFlowElements.Add(element);
            }
            if (flowElement is SubProcess childSubProcess)
            {
                if (goIntoSubprocesses)
                {
                    foundFlowElements.AddRange(FindFlowElementsInSubProcessOfType<T>(childSubProcess));
                }
            }
        }
        return foundFlowElements;
    }

    public IFlowElementsContainer FindParent(FlowElement childElement)
    {
        return FindParent(childElement, this);
    }

    public IFlowElementsContainer FindParent(FlowElement childElement, IFlowElementsContainer flowElementsContainer)
    {
        foreach (FlowElement flowElement in flowElementsContainer.GetFlowElements())
        {
            if (childElement.Id != null && childElement.Id.Equals(flowElement.Id))
            {
                return flowElementsContainer;
            }
            if (flowElement is IFlowElementsContainer container)
            {
                IFlowElementsContainer result = FindParent(childElement, container);
                if (result != null)
                {
                    return result;
                }
            }
        }
        return null;
    }

    public override Process Clone()
    {
        Process clone = new Process();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(Process otherElement)
    {
        base.SetValues(otherElement);

        // setBpmnModel(bpmnModel);
        Name = otherElement.Name;
        Executable = otherElement.Executable;
        Documentation = otherElement.Documentation;
        if (otherElement.IoSpecification != null)
        {
            IoSpecification = otherElement.IoSpecification.Clone();
        }

        executionListeners = new List<FlowableListener>();
        if (otherElement.ExecutionListeners != null && otherElement.ExecutionListeners.Count > 0)
        {
            foreach (FlowableListener listener in otherElement.ExecutionListeners)
            {
                executionListeners.Add(listener.Clone());
            }
        }

        candidateStarterUsers = new List<string>();
        if (otherElement.CandidateStarterUsers != null && otherElement.CandidateStarterUsers.Count > 0)
        {
            candidateStarterUsers.AddRange(otherElement.CandidateStarterUsers);
        }

        candidateStarterGroups = new List<string>();
        if (otherElement.CandidateStarterGroups != null && otherElement.CandidateStarterGroups.Count > 0)
        {
            candidateStarterGroups.AddRange(otherElement.CandidateStarterGroups);
        }
        
        enableEagerExecutionTreeFetching = otherElement.EnableEagerExecutionTreeFetching;

        eventListeners = new List<EventListener>();
        if (otherElement.EventListeners != null && otherElement.EventListeners.Count > 0)
        {
            foreach (EventListener listener in otherElement.EventListeners)
            {
                eventListeners.Add(listener.Clone());
            }
        }

        /*
         * This is required because data objects in Designer have no DI info and are added as properties, not flow elements
         * 
         * Determine the differences between the 2 elements' data object
         */
        foreach (ValuedDataObject thisObject in GetDataObjects())
        {
            bool exists = false;
            foreach (ValuedDataObject otherObject in otherElement.GetDataObjects())
            {
                if (thisObject.Id.Equals(otherObject.Id))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                // missing object
                RemoveFlowElement(thisObject.Id);
            }
        }

        dataObjects = new List<ValuedDataObject>();
        if (otherElement.GetDataObjects() != null && otherElement.GetDataObjects().Count > 0)
        {
            foreach (ValuedDataObject dataObject in otherElement.GetDataObjects())
            {
                ValuedDataObject clone = dataObject.Clone();
                dataObjects.Add(clone);
                // add it to the list of FlowElements
                // if it is already there, remove it first so order is same as
                // data object list
                RemoveFlowElement(clone.Id);
                AddFlowElement(clone);
            }
        }
    }

    public List<ValuedDataObject> GetDataObjects()
    {
        return dataObjects;
    }

    public void SetDataObjects(List<ValuedDataObject> dataObjects)
    {
        this.dataObjects = dataObjects;
    }

    public FlowElement InitialFlowElement
    {
        get { return initialFlowElement; }
        set { initialFlowElement = value; }
    }

    public bool EnableEagerExecutionTreeFetching
    {
        get { return enableEagerExecutionTreeFetching; }
        set { enableEagerExecutionTreeFetching = value; }
    }
}
