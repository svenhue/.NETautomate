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

public class InterfaceDefinition : BaseElement
{
    protected string name;
    protected string implementationRef;
    protected List<Operation> operations = new List<Operation>();

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string ImplementationRef
    {
        get { return implementationRef; }
        set { implementationRef = value; }
    }

    public List<Operation> Operations
    {
        get { return operations; }
        set { operations = value; }
    }

    public override InterfaceDefinition Clone()
    {
        InterfaceDefinition clone = new InterfaceDefinition();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(InterfaceDefinition otherElement)
    {
        base.SetValues(otherElement);
        Name = otherElement.Name;
        ImplementationRef = otherElement.ImplementationRef;

        operations = new List<Operation>();
        if (otherElement.Operations != null && otherElement.Operations.Count > 0)
        {
            foreach (Operation operation in otherElement.Operations)
            {
                operations.Add(operation.Clone());
            }
        }
    }
}
