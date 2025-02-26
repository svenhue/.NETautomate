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
using System.Text.Json.Serialization;

/// <summary>
/// @author Tijs Rademakers
/// </summary>
public abstract class FlowElement : BaseElement, IHasExecutionListeners
{
    protected string name;
    protected string documentation;
    protected List<FlowableListener> executionListeners = new();
    protected IFlowElementsContainer parentContainer;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string GetName()
    {
        return this.Name;
    }

    public void SetName(string Name)
    {
        this.Name = Name;
    }
    public string Documentation
    {
        get { return documentation; }
        set { documentation = value; }
    }

    public List<FlowableListener> ExecutionListeners
    {
        get { return executionListeners; }
        set { executionListeners = value; }
    }

    [JsonIgnore]
    public IFlowElementsContainer ParentContainer
    {
        get { return parentContainer; }
        set { parentContainer = value; }
    }

    public void SetParentContainer(IFlowElementsContainer container)
    {
        this.ParentContainer = container;
    }

    public IFlowElementsContainer GetParentContainer()
    {
        return ParentContainer;
    }
    [JsonIgnore]
    public SubProcess SubProcess
    {
        get
        {
            if (parentContainer is SubProcess subProcess)
            {
                return subProcess;
            }
            return null;
        }
    }

    public abstract override FlowElement Clone();

    public void SetValues(FlowElement otherElement)
    {
        base.SetValues(otherElement);
        Name = otherElement.Name;
        Documentation = otherElement.Documentation;

        executionListeners = new List<FlowableListener>();
        if (otherElement.ExecutionListeners != null && otherElement.ExecutionListeners.Count > 0)
        {
            foreach (var listener in otherElement.ExecutionListeners)
            {
                executionListeners.Add(listener.Clone());
            }
        }
    }
}
