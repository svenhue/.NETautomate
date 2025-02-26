
using Elsa.BPMN.Core.Models;

public class EventListener : BaseElement {

    protected String events;
    protected String implementationType;
    protected String implementation;
    protected String entityType;
    protected String onTransaction;

    public String getEvents() {
        return events;
    }

    public void setEvents(String events) {
        this.events = events;
    }

    public String getImplementationType() {
        return implementationType;
    }

    public void setImplementationType(String implementationType) {
        this.implementationType = implementationType;
    }

    public String getImplementation() {
        return implementation;
    }

    public void setImplementation(String implementation) {
        this.implementation = implementation;
    }

    public void setEntityType(String entityType) {
        this.entityType = entityType;
    }

    public String getEntityType() {
        return entityType;
    }
    
    public String getOnTransaction() {
        return onTransaction;
    }

    public void setOnTransaction(String onTransaction) {
        this.onTransaction = onTransaction;
    }


    public override EventListener Clone() {
        EventListener clone = new EventListener();
        clone.setValues(this);
        return clone;
    }

    public void setValues(EventListener otherListener) {
        base.SetValues(otherListener);
        setEvents(otherListener.getEvents());
        setImplementation(otherListener.getImplementation());
        setImplementationType(otherListener.getImplementationType());
        setEntityType(otherListener.getEntityType());
        setOnTransaction(otherListener.getOnTransaction());
    }
}
