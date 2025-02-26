
using Elsa.BPMN.Core.Models;

public class Signal : BaseElement {

    public static  String SCOPE_GLOBAL = "global";
    public static  String SCOPE_PROCESS_INSTANCE = "processInstance";

    protected String name;

    protected String scope;

    public Signal() {
    }

    public Signal(String id, String name) {
        this.id = id;
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getScope() {
        return scope;
    }

    public void setScope(String scope) {
        this.scope = scope;
    }

    public override Signal Clone() {
        Signal clone = new Signal();
        clone.setValues(this);
        return clone;
    }

    public void setValues(Signal otherElement) {
        base.SetValues(otherElement);
        setName(otherElement.getName());
        setScope(otherElement.getScope());
    }
}
