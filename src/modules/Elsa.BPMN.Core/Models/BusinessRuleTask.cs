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

/// <summary>
/// @author Tijs Rademakers
/// </summary>
public class BusinessRuleTask : Task
{
    protected string resultVariableName;
    protected bool exclude;
    protected List<string> ruleNames = new();
    protected List<string> inputVariables = new();
    protected string className;

    public bool Exclude
    {
        get { return exclude; }
        set { exclude = value; }
    }

    public string ResultVariableName
    {
        get { return resultVariableName; }
        set { resultVariableName = value; }
    }

    public List<string> RuleNames
    {
        get { return ruleNames; }
        set { ruleNames = value; }
    }

    public List<string> InputVariables
    {
        get { return inputVariables; }
        set { inputVariables = value; }
    }

    public string ClassName
    {
        get { return className; }
        set { className = value; }
    }

    public override BusinessRuleTask Clone()
    {
        var clone = new BusinessRuleTask();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(BusinessRuleTask otherElement)
    {
        base.SetValues(otherElement);
        ResultVariableName = otherElement.ResultVariableName;
        Exclude = otherElement.Exclude;
        ClassName = otherElement.ClassName;
        ruleNames = new List<string>(otherElement.RuleNames);
        inputVariables = new List<string>(otherElement.InputVariables);
    }
}
