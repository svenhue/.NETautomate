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
using System.Linq;
using System.Text.Json.Serialization;

/// <summary>
/// @author Tijs Rademakers
/// @author Joram Barrez
/// </summary>
public abstract class FlowNode : FlowElement
{
    protected bool asynchronous;
    protected bool asynchronousLeave;
    protected bool notExclusive;
    protected bool asynchronousLeaveNotExclusive;

    protected List<SequenceFlow> incomingFlows = new();
    protected List<SequenceFlow> outgoingFlows = new();

    [JsonIgnore]
    protected object behavior;

    public bool Asynchronous
    {
        get { return asynchronous; }
        set { asynchronous = value; }
    }

    public bool AsynchronousLeave
    {
        get { return asynchronousLeave; }
        set { asynchronousLeave = value; }
    }

    public bool Exclusive
    {
        get { return !notExclusive; }
        set { notExclusive = !value; }
    }

    public bool NotExclusive
    {
        get { return notExclusive; }
        set { notExclusive = value; }
    }
    
    public bool AsynchronousLeaveExclusive
    {
        get { return !asynchronousLeaveNotExclusive; }
        set { asynchronousLeaveNotExclusive = !value; }
    }

    public bool AsynchronousLeaveNotExclusive
    {
        get { return asynchronousLeaveNotExclusive; }
        set { asynchronousLeaveNotExclusive = value; }
    }

    public object Behavior
    {
        get { return behavior; }
        set { behavior = value; }
    }

    public List<SequenceFlow> IncomingFlows
    {
        get { return incomingFlows; }
        set { incomingFlows = value; }
    }

    public List<SequenceFlow> OutgoingFlows
    {
        get { return outgoingFlows; }
        set { outgoingFlows = value; }
    }

    public void SetValues(FlowNode otherNode)
    {
        base.SetValues(otherNode);
        Asynchronous = otherNode.Asynchronous;
        NotExclusive = otherNode.NotExclusive;
        AsynchronousLeave = otherNode.AsynchronousLeave;
        AsynchronousLeaveNotExclusive = otherNode.AsynchronousLeaveNotExclusive;

        if (otherNode.IncomingFlows != null)
        {
            IncomingFlows = otherNode.IncomingFlows
                .Select(flow => flow.Clone())
                .ToList();
        }

        if (otherNode.OutgoingFlows != null)
        {
            OutgoingFlows = otherNode.OutgoingFlows
                .Select(flow => flow.Clone())
                .ToList();
        }
    }
}
