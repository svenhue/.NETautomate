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
public class ScriptTask : Task
{
    protected string scriptFormat;
    protected string script;
    protected string resultVariable;
    protected string skipExpression;
    protected bool autoStoreVariables; // see https://activiti.atlassian.net/browse/ACT-1626

    public string ScriptFormat
    {
        get { return scriptFormat; }
        set { scriptFormat = value; }
    }

    public string Script
    {
        get { return script; }
        set { script = value; }
    }

    public string ResultVariable
    {
        get { return resultVariable; }
        set { resultVariable = value; }
    }

    public string SkipExpression
    {
        get { return skipExpression; }
        set { skipExpression = value; }
    }

    public bool AutoStoreVariables
    {
        get { return autoStoreVariables; }
        set { autoStoreVariables = value; }
    }

    public override ScriptTask Clone()
    {
        ScriptTask clone = new ScriptTask();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(ScriptTask otherElement)
    {
        base.SetValues(otherElement);
        ScriptFormat = otherElement.ScriptFormat;
        Script = otherElement.Script;
        ResultVariable = otherElement.ResultVariable;
        SkipExpression = otherElement.SkipExpression;
        AutoStoreVariables = otherElement.AutoStoreVariables;
    }
}
