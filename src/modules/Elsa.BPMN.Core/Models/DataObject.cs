
using Elsa.BPMN.Core.Models;

public class DataObject : FlowElement {

    protected ItemDefinition itemSubjectRef;

    public ItemDefinition getItemSubjectRef() {
        return itemSubjectRef;
    }

    public void setItemSubjectRef(ItemDefinition itemSubjectRef) {
        this.itemSubjectRef = itemSubjectRef;
    }

    
    public override DataObject Clone() {
        DataObject clone = new DataObject();
        clone.setValues(this);
        return clone;
    }

    public void setValues(DataObject otherElement) {
        base.SetValues(otherElement);

        SetId(otherElement.GetId());
        SetName(otherElement.GetName());
        setItemSubjectRef(otherElement.getItemSubjectRef());
    }
}
