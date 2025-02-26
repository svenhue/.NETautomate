
namespace Elsa.BPMN.Core.Models;
public class StartEvent : Event {

    protected String initiator;
    protected String formKey;
    protected bool sameDeployment = true;
    protected bool isInterrupting;
    protected String validateFormFields;
    protected List<FormProperty> formProperties = new List<FormProperty>();

    public String getInitiator() {
        return initiator;
    }

    public void setInitiator(String initiator) {
        this.initiator = initiator;
    }

    public bool isSameDeployment() {
        return sameDeployment;
    }

    public void setSameDeployment(bool sameDeployment) {
        this.sameDeployment = sameDeployment;
    }

    public String getFormKey() {
        return formKey;
    }

    public void setFormKey(String formKey) {
        this.formKey = formKey;
    }

    public bool IsInterrupting() {
        return isInterrupting;
    }

    public void setInterrupting(bool isInterrupting) {
        this.isInterrupting = isInterrupting;
    }

    public List<FormProperty> getFormProperties() {
        return formProperties;
    }

    public void setFormProperties(List<FormProperty> formProperties) {
        this.formProperties = formProperties;
    }

    public String getValidateFormFields() {
        return validateFormFields;
    }

    public void setValidateFormFields(String validateFormFields) {
        this.validateFormFields = validateFormFields;
    }

 
    public override StartEvent Clone() {
        StartEvent clone = new StartEvent();
        clone.setValues(this);
        return clone;
    }

    public void setValues(StartEvent otherEvent) {
        base.setValues(otherEvent);
        setInitiator(otherEvent.getInitiator());
        setFormKey(otherEvent.getFormKey());
        setSameDeployment(otherEvent.isInterrupting);
        setInterrupting(otherEvent.IsInterrupting());
        setValidateFormFields(otherEvent.validateFormFields);

        formProperties = new List<FormProperty>();
        if (otherEvent.getFormProperties() != null && !otherEvent.getFormProperties().Count().Equals(0)) {
            foreach (FormProperty property in otherEvent.getFormProperties()) {
                formProperties.Add(property.Clone());
            }
        }
    }
}
