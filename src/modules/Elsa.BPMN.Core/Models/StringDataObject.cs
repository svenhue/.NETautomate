
using Elsa.BPMN.Core.Models;

public class StringDataObject : ValuedDataObject {


    public override void SetValue(Object value) {
        this.value = value.ToString();
    }


    public override StringDataObject Clone() {
        StringDataObject clone = new StringDataObject();
        clone.setValues(this);
        return clone;
    }
}
