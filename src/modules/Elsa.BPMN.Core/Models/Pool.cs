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
public class Pool : BaseElement
{
    protected string name;
    protected string processRef;
    protected bool executable = true;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string ProcessRef
    {
        get { return processRef; }
        set { processRef = value; }
    }

    public bool Executable
    {
        get { return executable; }
        set { executable = value; }
    }

    public override Pool Clone()
    {
        Pool clone = new Pool();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(Pool otherElement)
    {
        base.SetValues(otherElement);
        Name = otherElement.Name;
        ProcessRef = otherElement.ProcessRef;
        Executable = otherElement.Executable;
    }
}
