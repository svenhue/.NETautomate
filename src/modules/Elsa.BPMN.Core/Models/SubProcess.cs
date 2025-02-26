
using System.Collections.ObjectModel;
using Elsa.BPMN.Core.Models;

public class SubProcess : Activity, IFlowElementsContainer {

    protected Dictionary<String, FlowElement> flowElementMap = new Dictionary<String, FlowElement>();
    protected List<FlowElement> flowElementList = new List<FlowElement>();
    protected Dictionary<String, Artifact> artifactMap = new Dictionary<String, Artifact>();
    protected List<Artifact> artifactList = new List<Artifact>();
    protected List<ValuedDataObject> dataObjects = new List<ValuedDataObject>();


    public FlowElement GetFlowElement(String id) {
        FlowElement foundElement = null;
        if (String.IsNullOrEmpty(id ) == false) {
            foundElement = flowElementMap.FirstOrDefault(e => e.Equals(id)).Value;
        }
        return foundElement;
    }


    public ICollection<FlowElement> GetFlowElements() {
        return flowElementList;
    }


    public void AddFlowElement(FlowElement element) {
        flowElementList.Add(element);
        element.SetParentContainer(this);
        AddFlowElementToMap(element);
    }


    public void AddFlowElementToMap(FlowElement element) {
        if (element != null && String.IsNullOrEmpty(element.GetId()) == false) {
            flowElementMap.Add(element.GetId(), element);
            if (base.ParentContainer != null) {
                ParentContainer.AddFlowElementToMap(element);
            }
        }
    }


    public void RemoveFlowElement(String elementId) {
        FlowElement element = GetFlowElement(elementId);
        if (element != null) {
            flowElementList.Remove(element);
            flowElementMap.Remove(elementId);
            if (element.GetParentContainer() != null) {
                element.GetParentContainer().RemoveFlowElementFromMap(elementId);
            }
        }
    }


    public void RemoveFlowElementFromMap(String elementId) {
        if (String.IsNullOrEmpty(elementId) == false) {
            flowElementMap.Remove(elementId);
        }
    }


    public Dictionary<String, FlowElement> GetFlowElementMap() {
        return flowElementMap;
    }

    public void setFlowElementMap(Dictionary<String, FlowElement> flowElementMap) {
        this.flowElementMap = flowElementMap;
    }

    public bool containsFlowElementId(String id) {
        return flowElementMap.ContainsKey(id);
    }
    /*
    public <T extends FlowElement> T findFirstSubFlowElementInFlowMapOfType(Class<T> clazz) {
        Optional<FlowElement> first = flowElementMap.values().stream()
            .filter(subFlowElement -> clazz.isInstance(subFlowElement))
            .findFirst();
        return (T) first.orElse(null);
    }
    

    public <T extends FlowElement> List<T> findAllSubFlowElementInFlowMapOfType(Class<T> clazz) {
        return flowElementMap.values().stream()
            .filter(clazz::isInstance)
            .map(subFlowElement -> (T) subFlowElement)
            .collect(Collectors.toList());
    }
*/

    public Artifact getArtifact(String id) {
        Artifact foundArtifact = null;
        foreach(Artifact artifact in artifactList) {
            if (id.Equals(artifact.GetId())) {
                foundArtifact = artifact;
                break;
            }
        }
        return foundArtifact;
    }

   
    public List<Artifact> getArtifacts() {
        return artifactList;
    }
    

    public Dictionary<String, Artifact> getArtifactMap() {
        return artifactMap;
    }


    public void addArtifact(Artifact artifact) {
        artifactList.Add(artifact);
        addArtifactToMap(artifact);
    }
    
 
    public void addArtifactToMap(Artifact artifact) {
        if (artifact != null && String.IsNullOrEmpty(artifact.GetId()) == false) {
            artifactMap.Add(artifact.GetId(), artifact);
            if (GetParentContainer() != null) {
                GetParentContainer().AddArtifactToMap(artifact);
            }
        }
    }


    public void removeArtifact(String artifactId) {
        Artifact artifact = getArtifact(artifactId);
        if (artifact != null) {
            artifactList.Remove(artifact);
        }
    }


    public override SubProcess Clone() {
        SubProcess clone = new SubProcess();
        clone.setValues(this);
        return clone;
    }

    public void setValues(SubProcess otherElement) {
        base.setValues(otherElement);

        /*
         * This is required because data objects in Designer have no DI info and are added as properties, not flow elements
         * 
         * Determine the differences between the 2 elements' data object
         */
        foreach (ValuedDataObject thisObject in getDataObjects()) {
            bool exists = false;
            foreach(ValuedDataObject otherObject in otherElement.getDataObjects()) {
                if (thisObject.GetId().Equals(otherObject.GetId())) {
                    exists = true;
                    break;
                }
            }
            if (!exists) {
                // missing object
                RemoveFlowElement(thisObject.GetId());
            }
        }

        dataObjects = new List<ValuedDataObject>();
        if (otherElement.getDataObjects() != null && !otherElement.getDataObjects().Count().Equals(0)) {
            foreach (ValuedDataObject dataObject in otherElement.getDataObjects()) {
                ValuedDataObject clone = dataObject.Clone();
                dataObjects.Add(clone);
                // add it to the list of FlowElements
                // if it is already there, remove it first so order is same as
                // data object list
                RemoveFlowElement(clone.GetId());
                AddFlowElement(clone);
            }
        }

        flowElementList.Clear();
        foreach (FlowElement flowElement in otherElement.GetFlowElements()) {
            AddFlowElement(flowElement.Clone());
        }

        artifactList.Clear();
        foreach (Artifact artifact in otherElement.getArtifacts()) {
            addArtifact(artifact.Clone());
        }
    }

    public List<ValuedDataObject> getDataObjects() {
        return dataObjects;
    }

    public void setDataObjects(List<ValuedDataObject> dataObjects) {
        this.dataObjects = dataObjects;
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

}
