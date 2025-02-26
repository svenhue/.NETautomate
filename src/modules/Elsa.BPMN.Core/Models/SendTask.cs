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
public class SendTask : TaskWithFieldExtensions
{
    protected string type;
    protected string implementationType;
    protected string operationRef;

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public string ImplementationType
    {
        get { return implementationType; }
        set { implementationType = value; }
    }

    public string OperationRef
    {
        get { return operationRef; }
        set { operationRef = value; }
    }

    public override SendTask Clone()
    {
        SendTask clone = new SendTask();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(SendTask otherElement)
    {
        base.SetValues(otherElement);
        Type = otherElement.Type;
        ImplementationType = otherElement.ImplementationType;
        OperationRef = otherElement.OperationRef;

        fieldExtensions = new List<FieldExtension>();
        if (otherElement.fieldExtensions != null && otherElement.fieldExtensions.Count > 0)
        {
            foreach (FieldExtension extension in otherElement.fieldExtensions)
            {
                fieldExtensions.Add(extension.Clone());
            }
        }
    }
}
