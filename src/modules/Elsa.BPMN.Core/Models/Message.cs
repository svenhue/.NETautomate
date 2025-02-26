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
public class Message : BaseElement
{
    protected string name;
    protected string itemRef;

    public Message()
    {
    }

    public Message(string id, string name, string itemRef)
    {
        this.id = id;
        this.name = name;
        this.itemRef = itemRef;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string ItemRef
    {
        get { return itemRef; }
        set { itemRef = value; }
    }

    public override Message Clone()
    {
        Message clone = new Message();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(Message otherElement)
    {
        base.SetValues(otherElement);
        Name = otherElement.Name;
        ItemRef = otherElement.ItemRef;
    }
}
