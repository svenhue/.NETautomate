
public class ErrorEventDefinition : EventDefinition {

    protected String errorCode;
    protected String errorVariableName;
    protected Boolean errorVariableTransient;
    protected Boolean errorVariableLocalScope;

    public String getErrorCode() {
        return errorCode;
    }

    public void setErrorCode(String errorCode) {
        this.errorCode = errorCode;
    }

    public String getErrorVariableName() {
        return errorVariableName;
    }

    public void setErrorVariableName(String errorVariableName) {
        this.errorVariableName = errorVariableName;
    }

    public Boolean getErrorVariableTransient() {
        return errorVariableTransient;
    }

    public void setErrorVariableTransient(Boolean errorVariableTransient) {
        this.errorVariableTransient = errorVariableTransient;
    }

    public Boolean getErrorVariableLocalScope() {
        return errorVariableLocalScope;
    }

    public void setErrorVariableLocalScope(Boolean errorVariableLocalScope) {
        this.errorVariableLocalScope = errorVariableLocalScope;
    }

    
    public override ErrorEventDefinition Clone() {
        ErrorEventDefinition clone = new ErrorEventDefinition();
        clone.setValues(this);
        return clone;
    }

    public void setValues(ErrorEventDefinition otherDefinition) {
        base.SetValues(otherDefinition);
        setErrorCode(otherDefinition.getErrorCode());
        setErrorVariableName(otherDefinition.getErrorVariableName());
        setErrorVariableLocalScope(otherDefinition.getErrorVariableLocalScope());
        setErrorVariableTransient(otherDefinition.getErrorVariableTransient());
    }
}
