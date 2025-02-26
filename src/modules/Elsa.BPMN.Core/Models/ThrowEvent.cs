
public class ThrowEvent : Event {

    
    public override ThrowEvent Clone() {
        ThrowEvent clone = new ThrowEvent();
        clone.setValues(this);
        return clone;
    }

    public void setValues(ThrowEvent otherEvent) {
        base.setValues(otherEvent);
    }
}
