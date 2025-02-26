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

public class Operation : BaseElement
{
    protected string name;
    protected string implementationRef;
    protected string inMessageRef;
    protected string outMessageRef;
    protected List<string> errorMessageRef = new List<string>();

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

    public string InMessageRef
    {
        get { return inMessageRef; }
        set { inMessageRef = value; }
    }

    public string OutMessageRef
    {
        get { return outMessageRef; }
        set { outMessageRef = value; }
    }

    public List<string> ErrorMessageRef
    {
        get { return errorMessageRef; }
        set { errorMessageRef = value; }
    }

    public override Operation Clone()
    {
        Operation clone = new Operation();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(Operation otherElement)
    {
        base.SetValues(otherElement);
        Name = otherElement.Name;
        ImplementationRef = otherElement.ImplementationRef;
        InMessageRef = otherElement.InMessageRef;
        OutMessageRef = otherElement.OutMessageRef;

        errorMessageRef = new List<string>();
        if (otherElement.ErrorMessageRef != null && otherElement.ErrorMessageRef.Count > 0)
        {
            errorMessageRef.AddRange(otherElement.ErrorMessageRef);
        }
    }
}
