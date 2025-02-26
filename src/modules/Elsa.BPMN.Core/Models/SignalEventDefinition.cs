
public class SignalEventDefinition : EventDefinition {

    protected String signalRef;
    protected String signalExpression;
    protected bool async;

    public String getSignalRef() {
        return signalRef;
    }

    public void setSignalRef(String signalRef) {
        this.signalRef = signalRef;
    }

    public String getSignalExpression() {
        return signalExpression;
    }

    public void setSignalExpression(String signalExpression) {
        this.signalExpression = signalExpression;
    }

    public bool isAsync() {
        return async;
    }

    public void setAsync(bool async) {
        this.async = async;
    }


    public override SignalEventDefinition Clone() {
        SignalEventDefinition clone = new SignalEventDefinition();
        clone.setValues(this);
        return clone;
    }

    public void setValues(SignalEventDefinition otherDefinition) {
        base.SetValues(otherDefinition);
        setSignalRef(otherDefinition.getSignalRef());
        setSignalExpression(otherDefinition.getSignalExpression());
        setAsync(otherDefinition.isAsync());
    }
}
