
using Elsa.BPMN.Core.Models;

public abstract class TaskWithFieldExtensions : Task {

    protected List<FieldExtension> fieldExtensions = new List<FieldExtension>();

    public List<FieldExtension> getFieldExtensions() {
        return fieldExtensions;
    }

    public void setFieldExtensions(List<FieldExtension> fieldExtensions) {
        this.fieldExtensions = fieldExtensions;
    }

}
