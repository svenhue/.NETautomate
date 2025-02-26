
namespace Elsa.BPMN.Core.Models;
public abstract class ValuedDataObject : DataObject {

    protected Object value;

    public Object getValue() {
        return value;
    }

    public abstract void SetValue(Object value);


    public override  abstract ValuedDataObject Clone();

    public void setValues(ValuedDataObject otherElement) {
        base.setValues(otherElement);
        if (otherElement.getValue() != null) {
            SetValue(otherElement.getValue());
        }
    }

    public String getType() {
        String structureRef = itemSubjectRef.StructureRef;
        return structureRef.Substring(structureRef.IndexOf(':') + 1);
    }


    public int hashCode() {
        int result = 0;
        result = 31 * result + (itemSubjectRef.StructureRef != null ? itemSubjectRef.StructureRef.GetHashCode() : 0);
        result = 31 * result + (id != null ? id.GetHashCode() : 0);
        result = 31 * result + (name != null ? name.GetHashCode() : 0);
        result = 31 * result + (value != null ? value.GetHashCode() : 0);
        return result;
    }
    

    public bool equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || o.GetType() != this.GetType()) {
            return false;
        }

        ValuedDataObject otherObject = (ValuedDataObject) o;

        if (!otherObject.getItemSubjectRef().StructureRef.Equals(this.itemSubjectRef.StructureRef)) {
            return false;
        }
        if (!otherObject.GetId().Equals(this.id)) {
            return false;
        }
        if (!otherObject.GetName().Equals(this.name)) {
            return false;
        }
        return otherObject.getValue().Equals(this.value.ToString());
    }
}
