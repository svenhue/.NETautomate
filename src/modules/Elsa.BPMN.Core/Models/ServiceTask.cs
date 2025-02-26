
using Elsa.BPMN.Core.Models;

public class ServiceTask : TaskWithFieldExtensions {

    public static  String DMN_TASK = "dmn";
    public static  String MAIL_TASK = "mail";
    public static  String HTTP_TASK = "http";
    public static  String SHELL_TASK = "shell";
    public static  String CASE_TASK = "case";
    public static  String SEND_EVENT_TASK = "send-event";
    public static  String EXTERNAL_WORKER_TASK = "external-worker";
    public static  String EXTERNAL_WORKER_TASK_LEGACY = "external";
    public static  String CAMEL = "camel";

    protected String implementation;
    protected String implementationType;
    protected String resultVariableName;
    protected String type;
    protected String operationRef;
    protected String extensionId;
    protected List<CustomProperty> customProperties = new List<CustomProperty>();
    protected String skipExpression;
    protected bool useLocalScopeForResultVariable;
    protected bool triggerable;
    protected bool storeResultVariableAsTransient;

    public String getImplementation() {
        return implementation;
    }

    public void setImplementation(String implementation) {
        this.implementation = implementation;
    }

    public String getImplementationType() {
        return implementationType;
    }

    public void setImplementationType(String implementationType) {
        this.implementationType = implementationType;
    }

    public String getResultVariableName() {
        return resultVariableName;
    }

    public void setResultVariableName(String resultVariableName) {
        this.resultVariableName = resultVariableName;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public List<CustomProperty> getCustomProperties() {
        return customProperties;
    }

    public void setCustomProperties(List<CustomProperty> customProperties) {
        this.customProperties = customProperties;
    }

    public String getOperationRef() {
        return operationRef;
    }

    public void setOperationRef(String operationRef) {
        this.operationRef = operationRef;
    }

    public String getExtensionId() {
        return extensionId;
    }

    public void setExtensionId(String extensionId) {
        this.extensionId = extensionId;
    }

    public bool isExtended() {
        return extensionId != null && !extensionId.Count().Equals(0);
    }

    public String getSkipExpression() {
        return skipExpression;
    }

    public void setSkipExpression(String skipExpression) {
        this.skipExpression = skipExpression;
    }

    public bool isUseLocalScopeForResultVariable() {
        return useLocalScopeForResultVariable;
    }

    public void setUseLocalScopeForResultVariable(bool useLocalScopeForResultVariable) {
        this.useLocalScopeForResultVariable = useLocalScopeForResultVariable;
    }

    public bool isTriggerable() {
        return triggerable;
    }

    public void setTriggerable(bool triggerable) {
        this.triggerable = triggerable;
    }

    public bool isStoreResultVariableAsTransient() {
        return storeResultVariableAsTransient;
    }

    public void setStoreResultVariableAsTransient(bool storeResultVariableAsTransient) {
        this.storeResultVariableAsTransient = storeResultVariableAsTransient;
    }


    public override ServiceTask Clone() {
        ServiceTask clone = new ServiceTask();
        clone.setValues(this);
        return clone;
    }

    public void setValues(ServiceTask otherElement) {
        base.setValues(otherElement);
        setImplementation(otherElement.getImplementation());
        setImplementationType(otherElement.getImplementationType());
        setResultVariableName(otherElement.getResultVariableName());
        setType(otherElement.getType());
        setOperationRef(otherElement.getOperationRef());
        setExtensionId(otherElement.getExtensionId());
        setSkipExpression(otherElement.getSkipExpression());
        setUseLocalScopeForResultVariable(otherElement.isUseLocalScopeForResultVariable());
        setTriggerable(otherElement.isTriggerable());
        setStoreResultVariableAsTransient(otherElement.isStoreResultVariableAsTransient());

        fieldExtensions = new List<FieldExtension>();
        if (otherElement.getFieldExtensions() != null && !otherElement.getFieldExtensions().Count().Equals(0)) {
            foreach (FieldExtension extension in otherElement.getFieldExtensions()) {
                fieldExtensions.Add(extension.Clone());
            }
        }

        customProperties = new List<CustomProperty>();
        if (otherElement.getCustomProperties() != null && !otherElement.getCustomProperties().Count().Equals(0)) {
            foreach (CustomProperty property in otherElement.getCustomProperties()) {
                customProperties.Add(property.Clone());
            }
        }
    }
}
