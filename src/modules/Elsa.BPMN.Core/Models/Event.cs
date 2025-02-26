
using Elsa.BPMN.Core.Models;

public abstract class Event : FlowNode, IHasOutParameters, IHasInParameters {

    protected List<EventDefinition> eventDefinitions = new List<EventDefinition>();
    protected IList<IOParameter> inParameters = new List<IOParameter>();
    protected IList<IOParameter> outParameters = new List<IOParameter>();

    public List<EventDefinition> getEventDefinitions() {
        return eventDefinitions;
    }

    public void setEventDefinitions(List<EventDefinition> eventDefinitions) {
        this.eventDefinitions = eventDefinitions;
    }

    public void addEventDefinition(EventDefinition eventDefinition) {
        eventDefinitions.Add(eventDefinition);
    }
    

    public IList<IOParameter> GetInParameters() {
        return inParameters;
    }


    public void AddInParameter(IOParameter inParameter) {
        inParameters.Add(inParameter);
    }


    public void SetInParameters(IList<IOParameter> inParameters) {
        this.inParameters = inParameters;
    }


    public IList<IOParameter> GetOutParameters() {
        return outParameters;
    }


    public void AddOutParameter(IOParameter outParameter) {
        this.outParameters.Add(outParameter);
    }


    public void SetOutParameters(IList<IOParameter> outParameters) {
        this.outParameters = outParameters;
    }

    public void setValues(Event otherEvent) {
        base.SetValues(otherEvent);

        eventDefinitions = new List<EventDefinition>();
        if (otherEvent.getEventDefinitions() != null && !otherEvent.getEventDefinitions().Count().Equals(0)) {
            foreach(EventDefinition eventDef in otherEvent.getEventDefinitions()) {
                eventDefinitions.Add(eventDef.Clone());
            }
        }
        
        inParameters = new List<IOParameter>();
        if (otherEvent.GetInParameters() != null && !otherEvent.GetInParameters().Count().Equals(0)) {
            foreach(IOParameter parameter in otherEvent.GetInParameters()) {
                inParameters.Add(parameter.Clone());
            }
        }

        outParameters = new List<IOParameter>();
        if (otherEvent.GetOutParameters() != null && !otherEvent.GetOutParameters().Count().Equals(0)) {
            foreach (IOParameter parameter in otherEvent.GetOutParameters()) {
                outParameters.Add(parameter.Clone());
            }
        }
    }
}
