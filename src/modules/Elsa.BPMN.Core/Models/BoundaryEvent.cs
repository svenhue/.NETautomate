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

using System.Text.Json.Serialization;

/// <summary>
/// @author Tijs Rademakers
/// </summary>
public class BoundaryEvent : Event
{
    [JsonIgnore]
    protected Activity attachedToRef;
    protected string attachedToRefId;
    protected bool cancelActivity = true;

    public Activity AttachedToRef
    {
        get { return attachedToRef; }
        set { attachedToRef = value; }
    }

    public string AttachedToRefId
    {
        get { return attachedToRefId; }
        set { attachedToRefId = value; }
    }

    public bool CancelActivity
    {
        get { return cancelActivity; }
        set { cancelActivity = value; }
    }

    public override BoundaryEvent Clone()
    {
        var clone = new BoundaryEvent();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(BoundaryEvent otherEvent)
    {
        base.SetValues(otherEvent);
        AttachedToRefId = otherEvent.AttachedToRefId;
        AttachedToRef = otherEvent.AttachedToRef;
        CancelActivity = otherEvent.CancelActivity;
    }
}
