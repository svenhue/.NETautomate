
public class VariableAggregationDefinition {

    protected String implementationType;
    protected String implementation;

    protected String target;
    protected String targetExpression;
    protected List<BPMNVariable> definitions;

    protected bool storeAsTransientVariable;
    protected bool createOverviewVariable;

    public String getImplementationType() {
        return implementationType;
    }

    public void setImplementationType(String implementationType) {
        this.implementationType = implementationType;
    }

    public String getImplementation() {
        return implementation;
    }

    public void setImplementation(String implementation) {
        this.implementation = implementation;
    }

    public String getTarget() {
        return target;
    }

    public void setTarget(String target) {
        this.target = target;
    }

    public String getTargetExpression() {
        return targetExpression;
    }

    public void setTargetExpression(String targetExpression) {
        this.targetExpression = targetExpression;
    }

    public List<BPMNVariable> getDefinitions() {
        return definitions;
    }

    public void setDefinitions(List<BPMNVariable> definitions) {
        this.definitions = definitions;
    }

    public void addDefinition(BPMNVariable definition) {
        if (definitions == null) {
            definitions = new List<BPMNVariable>();
        }

        definitions.Add(definition);
    }

    public bool isStoreAsTransientVariable() {
        return storeAsTransientVariable;
    }

    public void setStoreAsTransientVariable(bool storeAsTransientVariable) {
        this.storeAsTransientVariable = storeAsTransientVariable;
    }

    public bool isCreateOverviewVariable() {
        return createOverviewVariable;
    }

    public void setCreateOverviewVariable(bool createOverviewVariable) {
        this.createOverviewVariable = createOverviewVariable;
    }


    public VariableAggregationDefinition clone() {
        VariableAggregationDefinition aggregation = new VariableAggregationDefinition();
        aggregation.setValues(this);
        return aggregation;
    }

    public void setValues(VariableAggregationDefinition otherVariableDefinitionAggregation) {
        setImplementationType(otherVariableDefinitionAggregation.getImplementationType());
        setImplementation(otherVariableDefinitionAggregation.getImplementation());
        setTarget(otherVariableDefinitionAggregation.getTarget());
        setTargetExpression(otherVariableDefinitionAggregation.getTargetExpression());
        List<BPMNVariable> otherDefinitions = otherVariableDefinitionAggregation.getDefinitions();
        if (otherDefinitions != null) {
            List<BPMNVariable> newDefinitions = new List<BPMNVariable>(otherDefinitions.Count());
            foreach (BPMNVariable otherDefinition in otherDefinitions) {
                newDefinitions.Add(otherDefinition.Clone());
            }

            setDefinitions(newDefinitions);
        }
        setStoreAsTransientVariable(otherVariableDefinitionAggregation.isStoreAsTransientVariable());
        setCreateOverviewVariable(otherVariableDefinitionAggregation.isCreateOverviewVariable());
    }

    public class BPMNVariable {

        protected String source;
        protected String target;
        protected String targetExpression;
        protected String sourceExpression;

        public String getSource() {
            return source;
        }

        public void setSource(String source) {
            this.source = source;
        }

        public String getTarget() {
            return target;
        }

        public void setTarget(String target) {
            this.target = target;
        }

        public String getTargetExpression() {
            return targetExpression;
        }

        public void setTargetExpression(String targetExpression) {
            this.targetExpression = targetExpression;
        }

        public String getSourceExpression() {
            return sourceExpression;
        }

        public void setSourceExpression(String sourceExpression) {
            this.sourceExpression = sourceExpression;
        }

 
        public BPMNVariable Clone() {
            BPMNVariable definition = new BPMNVariable();
            definition.setValues(this);
            return definition;
        }

        public void setValues(BPMNVariable otherDefinition) {
            setSource(otherDefinition.getSource());
            setSourceExpression(otherDefinition.getSourceExpression());
            setTarget(otherDefinition.getTarget());
            setTargetExpression(otherDefinition.getTargetExpression());
        }
    }

}
