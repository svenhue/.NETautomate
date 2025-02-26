
public class EndEvent : Event {

    
    public override EndEvent Clone() {
        EndEvent clone = new EndEvent();
        clone.setValues(this);
        return clone;
    }

    public void setValues(EndEvent otherEvent) {
        base.setValues(otherEvent);
    }
}
