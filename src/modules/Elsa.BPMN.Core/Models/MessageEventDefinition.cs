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
public class MessageEventDefinition : EventDefinition
{
    protected string messageRef;
    protected string messageExpression;

    public string MessageRef
    {
        get { return messageRef; }
        set { messageRef = value; }
    }

    public string MessageExpression
    {
        get { return messageExpression; }
        set { messageExpression = value; }
    }

    public override MessageEventDefinition Clone()
    {
        MessageEventDefinition clone = new MessageEventDefinition();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(MessageEventDefinition otherDefinition)
    {
        base.SetValues(otherDefinition);
        MessageRef = otherDefinition.MessageRef;
        MessageExpression = otherDefinition.MessageExpression;
    }
}
