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
public class IOParameter : BaseElement
{
    protected string source;
    protected string sourceExpression;
    protected string target;
    protected string targetExpression;
    protected bool isTransient;

    public string Source
    {
        get { return source; }
        set { source = value; }
    }

    public string Target
    {
        get { return target; }
        set { target = value; }
    }

    public string SourceExpression
    {
        get { return sourceExpression; }
        set { sourceExpression = value; }
    }

    public string TargetExpression
    {
        get { return targetExpression; }
        set { targetExpression = value; }
    }

    public bool IsTransient
    {
        get { return isTransient; }
        set { isTransient = value; }
    }

    public override IOParameter Clone()
    {
        IOParameter clone = new IOParameter();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(IOParameter otherElement)
    {
        base.SetValues(otherElement);
        Source = otherElement.Source;
        SourceExpression = otherElement.SourceExpression;
        Target = otherElement.Target;
        TargetExpression = otherElement.TargetExpression;
        IsTransient = otherElement.IsTransient;
    }
}
