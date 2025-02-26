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
/// </summary>
public class VariableListenerEventDefinition : EventDefinition
{
    public const string CHANGE_TYPE_ALL = "all";
    public const string CHANGE_TYPE_UPDATE = "update";
    public const string CHANGE_TYPE_CREATE = "create";
    public const string CHANGE_TYPE_UPDATE_CREATE = "update-create";
    public const string CHANGE_TYPE_DELETE = "delete";
    
    public const string CHANGE_TYPE_PROPERTY = "changeType";

    protected string variableName;
    protected string variableChangeType;

    public string VariableName
    {
        get { return variableName; }
        set { variableName = value; }
    }

    public string VariableChangeType
    {
        get { return variableChangeType; }
        set { variableChangeType = value; }
    }

    public override VariableListenerEventDefinition Clone()
    {
        VariableListenerEventDefinition clone = new VariableListenerEventDefinition();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(VariableListenerEventDefinition otherDefinition)
    {
        base.SetValues(otherDefinition);
        VariableName = otherDefinition.VariableName;
        VariableChangeType = otherDefinition.VariableChangeType;
    }
}
