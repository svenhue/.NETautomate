
using Elsa.BPMN.Core.Models;


public class DataStore : BaseElement {

    protected String name;
    protected String dataState;
    protected String itemSubjectRef;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDataState() {
        return dataState;
    }

    public void setDataState(String dataState) {
        this.dataState = dataState;
    }

    public String getItemSubjectRef() {
        return itemSubjectRef;
    }

    public void setItemSubjectRef(String itemSubjectRef) {
        this.itemSubjectRef = itemSubjectRef;
    }

 
    public override DataStore Clone() {
        DataStore clone = new DataStore();
        clone.setValues(this);
        return clone;
    }

    public void setValues(DataStore otherElement) {
        base.SetValues(otherElement);
        setName(otherElement.getName());
        setDataState(otherElement.getDataState());
        setItemSubjectRef(otherElement.getItemSubjectRef());
    }

}
