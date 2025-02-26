
using Elsa.BPMN.Core.Models;

public class DoubleDataObject : ValuedDataObject {

    
    public override void SetValue(Object value)
    {
        throw new NotImplementedException();
    }


    public override DoubleDataObject Clone() {
        DoubleDataObject clone = new DoubleDataObject();
        clone.setValues(this);
        return clone;
    }
}
