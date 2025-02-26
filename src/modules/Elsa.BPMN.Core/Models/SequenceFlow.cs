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

using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// @author Tijs Rademakers
/// @author Joram Barrez
/// </summary>
public class SequenceFlow : FlowElement
{
    protected string conditionExpression;
    protected string conditionLanguage;
    protected string sourceRef;
    protected string targetRef;
    protected string skipExpression;

    // Actual flow elements that match the source and target ref
    // Set during process definition parsing
    [JsonIgnore]
    protected FlowElement sourceFlowElement;

    [JsonIgnore]
    protected FlowElement targetFlowElement;

    /// <summary>
    /// Graphical information: a list of waypoints: x1, y1, x2, y2, x3, y3, ..
    /// 
    /// Added during parsing of a process definition.
    /// </summary>
    protected List<int> waypoints = new List<int>();

    public SequenceFlow()
    {
    }

    public SequenceFlow(string sourceRef, string targetRef)
    {
        this.sourceRef = sourceRef;
        this.targetRef = targetRef;
    }

    public string ConditionExpression
    {
        get { return conditionExpression; }
        set { conditionExpression = value; }
    }

    public string ConditionLanguage
    {
        get { return conditionLanguage; }
        set { conditionLanguage = value; }
    }

    public string SourceRef
    {
        get { return sourceRef; }
        set { sourceRef = value; }
    }

    public string TargetRef
    {
        get { return targetRef; }
        set { targetRef = value; }
    }

    public string SkipExpression
    {
        get { return skipExpression; }
        set { skipExpression = value; }
    }

    public FlowElement SourceFlowElement
    {
        get { return sourceFlowElement; }
        set { sourceFlowElement = value; }
    }

    public FlowElement TargetFlowElement
    {
        get { return targetFlowElement; }
        set { targetFlowElement = value; }
    }

    public List<int> Waypoints
    {
        get { return waypoints; }
        set { waypoints = value; }
    }

    public override string ToString()
    {
        return sourceRef + " --> " + targetRef;
    }

    public override SequenceFlow Clone()
    {
        SequenceFlow clone = new SequenceFlow();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(SequenceFlow otherFlow)
    {
        base.SetValues(otherFlow);
        ConditionExpression = otherFlow.ConditionExpression;
        ConditionLanguage = otherFlow.ConditionLanguage;
        SourceRef = otherFlow.SourceRef;
        TargetRef = otherFlow.TargetRef;
        SkipExpression = otherFlow.SkipExpression;
    }
}
