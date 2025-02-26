
using Elsa.BPMN.Core.Models;

public class Escalation : BaseElement {

    protected String name;
    protected String escalationCode;

    public Escalation() {
    }

    public Escalation(String id, String name, String escalationCode) {
        this.id = id;
        this.name = name;
        this.escalationCode = escalationCode;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
    
    public String getEscalationCode() {
        return escalationCode;
    }

    public void setEscalationCode(String escalationCode) {
        this.escalationCode = escalationCode;
    }

    
    public override Escalation Clone() {
        Escalation clone = new Escalation();
        clone.setValues(this);
        return clone;
    }

    public void setValues(Escalation otherElement) {
        base.SetValues(otherElement);
        setName(otherElement.getName());
        setEscalationCode(otherElement.getEscalationCode());
    }
}
