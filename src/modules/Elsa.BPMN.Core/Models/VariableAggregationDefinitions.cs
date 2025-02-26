
using System.Collections.ObjectModel;


public class VariableAggregationDefinitions {

    protected List<VariableAggregationDefinition> aggregations = new List<VariableAggregationDefinition>();

    public List<VariableAggregationDefinition> getAggregations() {
        return aggregations;
    }

    public List<VariableAggregationDefinition> getOverviewAggregations()
    {
        return aggregations
            .FindAll(agg => agg.isCreateOverviewVariable() && !agg.isStoreAsTransientVariable());
    }

    public void setAggregations(List<VariableAggregationDefinition> aggregations) {
        this.aggregations = aggregations;
    }

    public VariableAggregationDefinitions Clone() {
        VariableAggregationDefinitions aggregations = new VariableAggregationDefinitions();
        aggregations.setValues(this);

        return aggregations;
    }

    public void setValues(VariableAggregationDefinitions otherAggregations) {
        foreach (VariableAggregationDefinition otherAggregation in otherAggregations.getAggregations()) {
            getAggregations().Add(otherAggregation.clone());
        }
    }
}
