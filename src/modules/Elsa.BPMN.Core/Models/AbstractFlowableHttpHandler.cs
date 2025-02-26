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
public abstract class AbstractFlowableHttpHandler : BaseElement, IHasScriptInfo
{
    protected string implementationType;
    protected string implementation;
    protected List<FieldExtension> fieldExtensions = new List<FieldExtension>();
    protected ScriptInfo scriptInfo;

    [JsonIgnore]
    protected object instance; // Can be used to set an instance of the listener directly. That instance will then always be reused.

    public string ImplementationType
    {
        get { return implementationType; }
        set { implementationType = value; }
    }

    public string Implementation
    {
        get { return implementation; }
        set { implementation = value; }
    }

    public List<FieldExtension> FieldExtensions
    {
        get { return fieldExtensions; }
        set { fieldExtensions = value; }
    }

    public object Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    public ScriptInfo ScriptInfo
    {
        get { return scriptInfo; }
        set { scriptInfo = value; }
    }

    public override AbstractFlowableHttpHandler Clone()
    {
        throw new NotImplementedException();
    }

    public void SetValues(AbstractFlowableHttpHandler otherHandler)
    {
        base.SetValues(otherHandler);
        Implementation = otherHandler.Implementation;
        ImplementationType = otherHandler.ImplementationType;
        if (otherHandler.ScriptInfo != null)
        {
            ScriptInfo = otherHandler.ScriptInfo.Clone();
        }
        fieldExtensions = new List<FieldExtension>();
        if (otherHandler.FieldExtensions != null && otherHandler.FieldExtensions.Count > 0)
        {
            foreach (var extension in otherHandler.FieldExtensions)
            {
                fieldExtensions.Add(extension.Clone());
            }
        }
    }
}
