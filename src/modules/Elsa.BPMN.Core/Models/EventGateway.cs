
using Elsa.BPMN.Core.Models;

public class EventGateway : Gateway {

    
    public override EventGateway Clone() {
        EventGateway clone = new EventGateway();
        clone.setValues(this);
        return clone;
    }

    public void setValues(EventGateway otherElement) {
        base.SetValues(otherElement);
    }
}
