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
public class MessageFlow : BaseElement
{
    protected string name;
    protected string sourceRef;
    protected string targetRef;
    protected string messageRef;

    public MessageFlow()
    {
    }

    public MessageFlow(string sourceRef, string targetRef)
    {
        this.sourceRef = sourceRef;
        this.targetRef = targetRef;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
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

    public string MessageRef
    {
        get { return messageRef; }
        set { messageRef = value; }
    }

    public override string ToString()
    {
        return sourceRef + " --> " + targetRef;
    }

    public override MessageFlow Clone()
    {
        MessageFlow clone = new MessageFlow();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(MessageFlow otherFlow)
    {
        base.SetValues(otherFlow);
        Name = otherFlow.Name;
        SourceRef = otherFlow.SourceRef;
        TargetRef = otherFlow.TargetRef;
        MessageRef = otherFlow.MessageRef;
    }
}
