
using Elsa.BPMN.Core.Models;


public class DataSpec : BaseElement {

    protected String name;
    protected String itemSubjectRef;
    protected bool isCollection;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getItemSubjectRef() {
        return itemSubjectRef;
    }

    public void setItemSubjectRef(String itemSubjectRef) {
        this.itemSubjectRef = itemSubjectRef;
    }

    public bool IsCollection() {
        return isCollection;
    }

    public void setCollection(bool isCollection) {
        this.isCollection = isCollection;
    }


    public override DataSpec Clone() {
        DataSpec clone = new DataSpec();
        clone.setValues(this);
        return clone;
    }

    public void setValues(DataSpec otherDataSpec) {
        base.SetValues(otherDataSpec);
        setName(otherDataSpec.getName());
        setItemSubjectRef(otherDataSpec.getItemSubjectRef());
        setCollection(otherDataSpec.IsCollection());
    }
}
