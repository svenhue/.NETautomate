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
public class SendEventServiceTask : ServiceTask
{
    protected string eventType;
    protected string triggerEventType;
    protected bool sendSynchronously;
    protected List<IOParameter> eventInParameters = new List<IOParameter>();
    protected List<IOParameter> eventOutParameters = new List<IOParameter>();

    public string EventType
    {
        get { return eventType; }
        set { eventType = value; }
    }

    public string TriggerEventType
    {
        get { return triggerEventType; }
        set { triggerEventType = value; }
    }

    public bool SendSynchronously
    {
        get { return sendSynchronously; }
        set { sendSynchronously = value; }
    }

    public List<IOParameter> EventInParameters
    {
        get { return eventInParameters; }
        set { eventInParameters = value; }
    }
    
    public List<IOParameter> EventOutParameters
    {
        get { return eventOutParameters; }
        set { eventOutParameters = value; }
    }

    public override SendEventServiceTask Clone()
    {
        SendEventServiceTask clone = new SendEventServiceTask();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(SendEventServiceTask otherElement)
    {
        base.SetValues(otherElement);
        EventType = otherElement.EventType;
        TriggerEventType = otherElement.TriggerEventType;
        SendSynchronously = otherElement.SendSynchronously;
        
        eventInParameters = new List<IOParameter>();
        if (otherElement.EventInParameters != null && otherElement.EventInParameters.Count > 0)
        {
            foreach (IOParameter parameter in otherElement.EventInParameters)
            {
                eventInParameters.Add(parameter.Clone());
            }
        }
        
        eventOutParameters = new List<IOParameter>();
        if (otherElement.EventOutParameters != null && otherElement.EventOutParameters.Count > 0)
        {
            foreach (IOParameter parameter in otherElement.EventOutParameters)
            {
                eventOutParameters.Add(parameter.Clone());
            }
        }
    }
}
