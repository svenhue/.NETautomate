
using Elsa.BPMN.Core.Models;

public class ExclusiveGateway : Gateway {

    
    public override ExclusiveGateway Clone() {
        ExclusiveGateway clone = new ExclusiveGateway();
        clone.setValues(this);
        return clone;
    }

    public void setValues(ExclusiveGateway otherElement) {
        base.SetValues(otherElement);
    }
}
