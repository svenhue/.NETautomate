
public class EscalationEventDefinition : EventDefinition {

    protected String escalationCode;

    public String getEscalationCode() {
        return escalationCode;
    }

    public void setEscalationCode(String escalationCode) {
        this.escalationCode = escalationCode;
    }

    
    public override EscalationEventDefinition Clone() {
        EscalationEventDefinition clone = new EscalationEventDefinition();
        clone.setValues(this);
        return clone;
    }

    public void setValues(EscalationEventDefinition otherDefinition) {
        base.SetValues(otherDefinition);
        setEscalationCode(otherDefinition.getEscalationCode());
    }
}
