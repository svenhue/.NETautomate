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
public class Lane : BaseElement
{
    protected string name;
    protected Process parentProcess;
    protected List<string> flowReferences = new List<string>();

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    [JsonIgnore]
    public Process ParentProcess
    {
        get { return parentProcess; }
        set { parentProcess = value; }
    }

    public List<string> FlowReferences
    {
        get { return flowReferences; }
        set { flowReferences = value; }
    }

    public override Lane Clone()
    {
        Lane clone = new Lane();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(Lane otherElement)
    {
        base.SetValues(otherElement);
        Name = otherElement.Name;
        ParentProcess = otherElement.ParentProcess;

        flowReferences = new List<string>();
        if (otherElement.FlowReferences != null && otherElement.FlowReferences.Count > 0)
        {
            flowReferences.AddRange(otherElement.FlowReferences);
        }
    }
}
