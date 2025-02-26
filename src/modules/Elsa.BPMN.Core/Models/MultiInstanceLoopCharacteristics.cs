/* Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Elsa.BPMN.Core.Models;

/// <summary>
/// @author Tijs Rademakers
/// @author Joram Barrez
/// </summary>
public class MultiInstanceLoopCharacteristics : BaseElement
{
    protected string inputDataItem;
    protected string collectionString;
    protected CollectionHandler collectionHandler;
    protected string loopCardinality;
    protected string completionCondition;
    protected string elementVariable;
    protected string elementIndexVariable;
    protected bool sequential;
    protected bool noWaitStatesAsyncLeave;

    protected VariableAggregationDefinitions aggregations;

    public string InputDataItem
    {
        get { return inputDataItem; }
        set { inputDataItem = value; }
    }

    public string CollectionString
    {
        get { return collectionString; }
        set { collectionString = value; }
    }

    public CollectionHandler Handler
    {
        get { return collectionHandler; }
        set { collectionHandler = value; }
    }

    public string LoopCardinality
    {
        get { return loopCardinality; }
        set { loopCardinality = value; }
    }

    public string CompletionCondition
    {
        get { return completionCondition; }
        set { completionCondition = value; }
    }

    public string ElementVariable
    {
        get { return elementVariable; }
        set { elementVariable = value; }
    }

    public string ElementIndexVariable
    {
        get { return elementIndexVariable; }
        set { elementIndexVariable = value; }
    }

    public bool Sequential
    {
        get { return sequential; }
        set { sequential = value; }
    }

    public bool NoWaitStatesAsyncLeave
    {
        get { return noWaitStatesAsyncLeave; }
        set { noWaitStatesAsyncLeave = value; }
    }

    public VariableAggregationDefinitions Aggregations
    {
        get { return aggregations; }
        set { aggregations = value; }
    }

    public void AddAggregation(VariableAggregationDefinition aggregation)
    {
        if (this.aggregations == null)
        {
            this.aggregations = new VariableAggregationDefinitions();
        }

        this.aggregations.getAggregations().Add(aggregation);
    }

    public override MultiInstanceLoopCharacteristics Clone()
    {
        MultiInstanceLoopCharacteristics clone = new MultiInstanceLoopCharacteristics();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(MultiInstanceLoopCharacteristics otherLoopCharacteristics)
    {
        base.SetValues(otherLoopCharacteristics);
        InputDataItem = otherLoopCharacteristics.InputDataItem;
        CollectionString = otherLoopCharacteristics.CollectionString;
        if (otherLoopCharacteristics.Handler != null)
        {
            Handler = otherLoopCharacteristics.Handler.Clone();
        }
        LoopCardinality = otherLoopCharacteristics.LoopCardinality;
        CompletionCondition = otherLoopCharacteristics.CompletionCondition;
        ElementVariable = otherLoopCharacteristics.ElementVariable;
        ElementIndexVariable = otherLoopCharacteristics.ElementIndexVariable;
        Sequential = otherLoopCharacteristics.Sequential;
        NoWaitStatesAsyncLeave = otherLoopCharacteristics.NoWaitStatesAsyncLeave;

        if (otherLoopCharacteristics.Aggregations != null)
        {
            Aggregations = otherLoopCharacteristics.Aggregations.Clone();
        }
    }
}
