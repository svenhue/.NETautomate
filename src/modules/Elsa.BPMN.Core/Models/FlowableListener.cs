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

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// @author Tijs Rademakers
/// </summary>
public class FlowableListener : BaseElement, IHasScriptInfo
{
    protected string @event;
    protected string implementationType;
    protected string implementation;
    protected List<FieldExtension> fieldExtensions = new();
    protected string onTransaction;
    protected string customPropertiesResolverImplementationType;
    protected string customPropertiesResolverImplementation;

    [JsonIgnore]
    protected object instance; // Can be used to set an instance of the listener directly. That instance will then always be reused.

    /// <summary>
    /// ScriptInfo is populated for implementationType 'script'
    /// </summary>
    protected ScriptInfo scriptInfo;

    public FlowableListener()
    {
        // Always generate a random identifier to look up the listener while executing the logic
        Id = Guid.NewGuid().ToString();
    }

    public string Event
    {
        get { return @event; }
        set { @event = value; }
    }

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

    public string OnTransaction
    {
        get { return onTransaction; }
        set { onTransaction = value; }
    }

    public string CustomPropertiesResolverImplementationType
    {
        get { return customPropertiesResolverImplementationType; }
        set { customPropertiesResolverImplementationType = value; }
    }

    public string CustomPropertiesResolverImplementation
    {
        get { return customPropertiesResolverImplementation; }
        set { customPropertiesResolverImplementation = value; }
    }

    public object Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    /// <summary>
    /// Return the script info, if present.
    /// ScriptInfo must be populated, when &lt;executionListener type="script" ...&gt; e.g. when
    /// implementationType is 'script'.
    /// </summary>
    public ScriptInfo ScriptInfo
    {
        get { return scriptInfo; }
        set { scriptInfo = value; }
    }

    public override FlowableListener Clone()
    {
        var clone = new FlowableListener();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(FlowableListener otherListener)
    {
        base.SetValues(otherListener);
        Event = otherListener.Event;
        Implementation = otherListener.Implementation;
        ImplementationType = otherListener.ImplementationType;
        if (otherListener.ScriptInfo != null)
        {
            ScriptInfo = otherListener.ScriptInfo.Clone();
        }
        
        fieldExtensions = new List<FieldExtension>();
        if (otherListener.FieldExtensions != null && otherListener.FieldExtensions.Count > 0)
        {
            foreach (var extension in otherListener.FieldExtensions)
            {
                fieldExtensions.Add(extension.Clone());
            }
        }

        OnTransaction = otherListener.OnTransaction;
        CustomPropertiesResolverImplementationType = otherListener.CustomPropertiesResolverImplementationType;
        CustomPropertiesResolverImplementation = otherListener.CustomPropertiesResolverImplementation;
    }
}
