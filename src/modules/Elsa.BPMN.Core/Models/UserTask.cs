using Elsa.BPMN.Core.Models;
public class UserTask : Task, HasValidateFormFields {

    protected String assignee;
    protected String owner;
    protected String priority;
    protected String formKey;
    protected bool sameDeployment = true;
    protected String dueDate;
    protected String businessCalendarName;
    protected String category;
    protected String extensionId;
    protected List<String> candidateUsers = new List<String>();
    protected List<String> candidateGroups = new List<String>();
    protected List<FormProperty> formProperties = new List<FormProperty>();
    protected List<FlowableListener> taskListeners = new List<FlowableListener>();
    protected String skipExpression;
    public string validateFormFields { get; set; }
    protected String taskIdVariableName;
    protected String taskCompleterVariableName;

    protected Dictionary<String, List<KeyValuePair<string, string>>> customUserIdentityLinks = new Dictionary<String, List<KeyValuePair<string, string>>>();
    protected Dictionary<String, List<KeyValuePair<string, string>>> customGroupIdentityLinks = new Dictionary<String, List<KeyValuePair<string, string>>>();

    protected List<CustomProperty> customProperties = new List<CustomProperty>();

    public String getAssignee() {
        return assignee;
    }

    public void setAssignee(String assignee) {
        this.assignee = assignee;
    }

    public String getOwner() {
        return owner;
    }

    public void setOwner(String owner) {
        this.owner = owner;
    }

    public String getPriority() {
        return priority;
    }

    public void setPriority(String priority) {
        this.priority = priority;
    }

    public String getFormKey() {
        return formKey;
    }

    public void setFormKey(String formKey) {
        this.formKey = formKey;
    }

    public bool isSameDeployment() {
        return sameDeployment;
    }

    public void setSameDeployment(bool sameDeployment) {
        this.sameDeployment = sameDeployment;
    }

    public String getDueDate() {
        return dueDate;
    }

    public void setDueDate(String dueDate) {
        this.dueDate = dueDate;
    }

    public String getBusinessCalendarName() {
        return businessCalendarName;
    }

    public void setBusinessCalendarName(String businessCalendarName) {
        this.businessCalendarName = businessCalendarName;
    }

    public String getCategory() {
        return category;
    }

    public void setCategory(String category) {
        this.category = category;
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

    public List<String> getCandidateUsers() {
        return candidateUsers;
    }

    public void setCandidateUsers(List<String> candidateUsers) {
        this.candidateUsers = candidateUsers;
    }

    public List<String> getCandidateGroups() {
        return candidateGroups;
    }

    public void setCandidateGroups(List<String> candidateGroups) {
        this.candidateGroups = candidateGroups;
    }

    public List<FormProperty> getFormProperties() {
        return formProperties;
    }

    public void setFormProperties(List<FormProperty> formProperties) {
        this.formProperties = formProperties;
    }

    public List<FlowableListener> getTaskListeners() {
        return taskListeners;
    }

    public void setTaskListeners(List<FlowableListener> taskListeners) {
        this.taskListeners = taskListeners;
    }

    public void addCustomUserIdentityLink(String userId, String type) {
        throw new NotImplementedException();
    }

    public void addCustomGroupIdentityLink(String groupId, String type)
    {
        throw new NotImplementedException();
    }

    public Dictionary<String, List<String>> getCustomUserIdentityLinks() {
        throw new NotImplementedException();
    }

    public void setCustomUserIdentityLinks(Dictionary<String, List<String>> customUserIdentityLinks) {
        throw new NotImplementedException();
    }

    public Dictionary<String, List<String>> getCustomGroupIdentityLinks() {
        throw new NotImplementedException();
    }

    public void setCustomGroupIdentityLinks(Dictionary<String, List<String>> customGroupIdentityLinks) {
        throw new NotImplementedException();
    }

    public List<CustomProperty> getCustomProperties() {
        return customProperties;
    }

    public void setCustomProperties(List<CustomProperty> customProperties) {
        this.customProperties = customProperties;
    }

    public String getSkipExpression() {
        return skipExpression;
    }

    public void setSkipExpression(String skipExpression) {
        this.skipExpression = skipExpression;
    }

    public string ValidateFormFields()
    {
        throw new NotImplementedException();
    }
    public String getValidateFormFields() {
        return validateFormFields;
    }

    public void setValidateFormFields(String validateFormFields) {
        this.validateFormFields = validateFormFields;
    }

    public String getTaskIdVariableName() {
        return taskIdVariableName;
    }

    public void setTaskIdVariableName(String taskIdVariableName) {
        this.taskIdVariableName = taskIdVariableName;
    }

    public String getTaskCompleterVariableName() {
        return taskCompleterVariableName;
    }

    public void setTaskCompleterVariableName(String taskCompleterVariableName) {
        this.taskCompleterVariableName = taskCompleterVariableName;
    }


    public override UserTask Clone() {
        UserTask clone = new UserTask();
        clone.setValues(this);
        return clone;
    }

    public void setValues(UserTask otherElement) {
        base.setValues(otherElement);
        setAssignee(otherElement.getAssignee());
        setOwner(otherElement.getOwner());
        setFormKey(otherElement.getFormKey());
        setSameDeployment(otherElement.isSameDeployment());
        setDueDate(otherElement.getDueDate());
        setPriority(otherElement.getPriority());
        setCategory(otherElement.getCategory());
        setTaskIdVariableName(otherElement.getTaskIdVariableName());
        setTaskCompleterVariableName(otherElement.getTaskCompleterVariableName());
        setExtensionId(otherElement.getExtensionId());
        setSkipExpression(otherElement.getSkipExpression());
        setValidateFormFields(otherElement.getValidateFormFields());

        setCandidateGroups(new List<string>(otherElement.getCandidateGroups()));
        setCandidateUsers(new List<string>(otherElement.getCandidateUsers()));

        //setCustomGroupIdentityLinks(otherElement.customGroupIdentityLinks);
        //setCustomUserIdentityLinks(otherElement.customUserIdentityLinks);

        formProperties = new List<FormProperty>();
        if (otherElement.getFormProperties() != null && !otherElement.getFormProperties().Count().Equals(0)) {
            foreach (FormProperty property in otherElement.getFormProperties()) {
                formProperties.Add(property.Clone());
            }
        }

        taskListeners = new List<FlowableListener>();
        if (otherElement.getTaskListeners() != null && !otherElement.getTaskListeners().Count().Equals(0)) {
            foreach(FlowableListener listener in otherElement.getTaskListeners()) {
                taskListeners.Add(listener.Clone());
            }
        }
    }
}
