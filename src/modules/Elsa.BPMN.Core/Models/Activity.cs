
using System.Collections;
using Elsa.BPMN.Core.Models;

public abstract class Activity : FlowNode {

    protected String defaultFlow;
    protected bool forCompensation;
    protected MultiInstanceLoopCharacteristics loopCharacteristics;
    protected IOSpecification ioSpecification;
    protected List<DataAssociation> dataInputAssociations = new List<DataAssociation>();
    protected List<DataAssociation> dataOutputAssociations = new List<DataAssociation>();
    protected List<BoundaryEvent> boundaryEvents = new List<BoundaryEvent>();
    protected String failedJobRetryTimeCycleValue;
    protected List<MapExceptionEntry> mapExceptions = new List<MapExceptionEntry>();

    public String getFailedJobRetryTimeCycleValue() {
        return failedJobRetryTimeCycleValue;
    }

    public void setFailedJobRetryTimeCycleValue(String failedJobRetryTimeCycleValue) {
        this.failedJobRetryTimeCycleValue = failedJobRetryTimeCycleValue;
    }

    public bool isForCompensation() {
        return forCompensation;
    }

    public void setForCompensation(bool forCompensation) {
        this.forCompensation = forCompensation;
    }

    public List<BoundaryEvent> getBoundaryEvents() {
        return boundaryEvents;
    }

    public void setBoundaryEvents(List<BoundaryEvent> boundaryEvents) {
        this.boundaryEvents = boundaryEvents;
    }

    public String getDefaultFlow() {
        return defaultFlow;
    }

    public void setDefaultFlow(String defaultFlow) {
        this.defaultFlow = defaultFlow;
    }

    public MultiInstanceLoopCharacteristics getLoopCharacteristics() {
        return loopCharacteristics;
    }

    public void setLoopCharacteristics(MultiInstanceLoopCharacteristics loopCharacteristics) {
        this.loopCharacteristics = loopCharacteristics;
    }

    public bool hasMultiInstanceLoopCharacteristics() {
        return getLoopCharacteristics() != null;
    }

    public IOSpecification getIoSpecification() {
        return ioSpecification;
    }

    public void setIoSpecification(IOSpecification ioSpecification) {
        this.ioSpecification = ioSpecification;
    }

    public List<DataAssociation> getDataInputAssociations() {
        return dataInputAssociations;
    }

    public void setDataInputAssociations(List<DataAssociation> dataInputAssociations) {
        this.dataInputAssociations = dataInputAssociations;
    }

    public List<DataAssociation> getDataOutputAssociations() {
        return dataOutputAssociations;
    }

    public void setDataOutputAssociations(List<DataAssociation> dataOutputAssociations) {
        this.dataOutputAssociations = dataOutputAssociations;
    }

    public List<MapExceptionEntry> getMapExceptions() {
        return mapExceptions;
    }

    public void setMapExceptions(List<MapExceptionEntry> mapExceptions) {
        this.mapExceptions = mapExceptions;
    }

    public void setValues(Activity otherActivity) {
        base.SetValues(otherActivity);
        setFailedJobRetryTimeCycleValue(otherActivity.getFailedJobRetryTimeCycleValue());
        setDefaultFlow(otherActivity.getDefaultFlow());
        setForCompensation(otherActivity.isForCompensation());
        if (otherActivity.getLoopCharacteristics() != null) {
            setLoopCharacteristics(otherActivity.getLoopCharacteristics().Clone());
        }
        if (otherActivity.getIoSpecification() != null) {
            setIoSpecification(otherActivity.getIoSpecification().Clone());
        }

        dataInputAssociations = new List<DataAssociation>();
        if (otherActivity.getDataInputAssociations() != null && !otherActivity.getDataInputAssociations().Count().Equals(0) ) {
            foreach(DataAssociation association in otherActivity.getDataInputAssociations()) {
                dataInputAssociations.Add(association.Clone());
            }
        }

        dataOutputAssociations = new List<DataAssociation>();
        if (otherActivity.getDataOutputAssociations() != null && !otherActivity.getDataOutputAssociations().Count().Equals(0)) {
            foreach (DataAssociation association in otherActivity.getDataOutputAssociations()) {
                dataOutputAssociations.Add(association.Clone());
            }
        }

        boundaryEvents.Clear();
        boundaryEvents.AddRange(otherActivity.getBoundaryEvents());
    }
}
