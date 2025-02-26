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

public class ExtensionElement : BaseElement
{
    protected string name;
    protected string namespacePrefix;
    protected string @namespace;
    protected string elementText;
    protected Dictionary<string, List<ExtensionElement>> childElements = new();

    public string ElementText
    {
        get { return elementText; }
        set { elementText = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string NamespacePrefix
    {
        get { return namespacePrefix; }
        set { namespacePrefix = value; }
    }

    public string Namespace
    {
        get { return @namespace; }
        set { @namespace = value; }
    }

    public Dictionary<string, List<ExtensionElement>> ChildElements
    {
        get { return childElements; }
        set { childElements = value; }
    }

    public void AddChildElement(ExtensionElement childElement)
    {
        if (childElement != null && !string.IsNullOrEmpty(childElement.Name))
        {
            if (!this.childElements.ContainsKey(childElement.Name))
            {
                this.childElements[childElement.Name] = new List<ExtensionElement>();
            }
            this.childElements[childElement.Name].Add(childElement);
        }
    }

    public override ExtensionElement Clone()
    {
        var clone = new ExtensionElement();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(ExtensionElement otherElement)
    {
        base.SetValues(otherElement);
        Name = otherElement.Name;
        NamespacePrefix = otherElement.NamespacePrefix;
        Namespace = otherElement.Namespace;
        ElementText = otherElement.ElementText;

        childElements = new Dictionary<string, List<ExtensionElement>>();
        if (otherElement.ChildElements != null && otherElement.ChildElements.Count > 0)
        {
            foreach (var key in otherElement.ChildElements.Keys)
            {
                var otherElementList = otherElement.ChildElements[key];
                if (otherElementList != null && otherElementList.Count > 0)
                {
                    var elementList = new List<ExtensionElement>();
                    foreach (var extensionElement in otherElementList)
                    {
                        elementList.Add(extensionElement.Clone());
                    }
                    childElements[key] = elementList;
                }
            }
        }
    }
}
