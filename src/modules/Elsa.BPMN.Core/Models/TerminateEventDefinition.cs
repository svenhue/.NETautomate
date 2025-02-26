
public class TerminateEventDefinition : EventDefinition {

    /**
     * When true, this event will terminate all parent process instances (in the case of using call activity), thus ending the whole process instance.
     * 
     * By default false (BPMN spec compliant): the parent scope is terminated (subprocess: embedded or call activity)
     */
    protected bool terminateAll;

    /**
     * When true (and used within a multi instance), this event will terminate all multi instance instances of the embedded subprocess/call activity this event is used in.
     * 
     * In case of nested multi instance, only the first parent multi instance structure will be destroyed. In case of 'true' and not being in a multi instance construction: executes the default
     * behavior.
     * 
     * Note: if terminate all is set to true, this will have precedence over this.
     */
    protected bool terminateMultiInstance;


    public override TerminateEventDefinition Clone() {
        TerminateEventDefinition clone = new TerminateEventDefinition();
        clone.setValues(this);
        return clone;
    }

    public void setValues(TerminateEventDefinition otherDefinition) {
        base.SetValues(otherDefinition);
        this.terminateAll = otherDefinition.isTerminateAll();
        this.terminateMultiInstance = otherDefinition.isTerminateMultiInstance();
    }

    public bool isTerminateAll() {
        return terminateAll;
    }

    public void setTerminateAll(bool terminateAll) {
        this.terminateAll = terminateAll;
    }

    public bool isTerminateMultiInstance() {
        return terminateMultiInstance;
    }

    public void setTerminateMultiInstance(bool terminateMultiInstance) {
        this.terminateMultiInstance = terminateMultiInstance;
    }

}
