
namespace Elsa.BPMN.Core.Models;

using System;
using System.Collections.Generic;
using System.Linq;

public abstract class 
    BaseElement : IHasExtensionAttributes
{
    protected string id;
    protected int xmlRowNumber;
    protected int xmlColumnNumber;
    protected Dictionary<string, List<ExtensionElement>> extensionElements = new();
    /// <summary>
    /// extension attributes could be part of each element
    /// </summary>
    protected Dictionary<string, List<ExtensionAttribute>> attributes = new();

    public void SetId(string Id)
    {
        this.id = Id;
    }

    public string GetId() { return this.id;}
    
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public int XmlRowNumber
    {
        get { return xmlRowNumber; }
        set { xmlRowNumber = value; }
    }

    public int XmlColumnNumber
    {
        get { return xmlColumnNumber; }
        set { xmlColumnNumber = value; }
    }

    public Dictionary<string, List<ExtensionElement>> ExtensionElements
    {
        get { return extensionElements; }
        set { extensionElements = value; }
    }

    public void AddExtensionElement(ExtensionElement extensionElement)
    {
        if (extensionElement != null && !string.IsNullOrEmpty(extensionElement.Name))
        {
            if (!this.extensionElements.ContainsKey(extensionElement.Name))
            {
                this.extensionElements[extensionElement.Name] = new List<ExtensionElement>();
            }
            this.extensionElements[extensionElement.Name].Add(extensionElement);
        }
    }

    public Dictionary<string, List<ExtensionAttribute>> Attributes
    {
        get { return attributes; }
        set { attributes = value; }
    }

    public string GetAttributeValue(string @namespace, string name)
    {
        if (Attributes.TryGetValue(name, out var attributes) && attributes.Any())
        {
            return attributes.FirstOrDefault(attribute =>
                (@namespace == null && attribute.getNamespace() == null) || @namespace.Equals(attribute.getNamespace())).getValue();
        }
        return null;
    }

    public void AddAttribute(ExtensionAttribute attribute)
    {
        if (attribute != null && !string.IsNullOrEmpty(attribute.getName()))
        {
            if (!this.attributes.ContainsKey(attribute.getName()))
            {
                this.attributes[attribute.getName()] = new List<ExtensionAttribute>();
            }
            this.attributes[attribute.getName()].Add(attribute);
        }
    }

    public void SetValues(BaseElement otherElement)
    {
        Id = otherElement.Id;

        extensionElements = new Dictionary<string, List<ExtensionElement>>();
        if (otherElement.ExtensionElements != null && otherElement.ExtensionElements.Any())
        {
            foreach (var key in otherElement.ExtensionElements.Keys)
            {
                var otherElementList = otherElement.ExtensionElements[key];
                if (otherElementList != null && otherElementList.Any())
                {
                    var elementList = otherElementList.Select(extensionElement => extensionElement.Clone()).ToList();
                    extensionElements[key] = elementList;
                }
            }
        }

        attributes = new Dictionary<string, List<ExtensionAttribute>>();
        if (otherElement.Attributes != null && otherElement.Attributes.Any())
        {
            foreach (var key in otherElement.Attributes.Keys)
            {
                var otherAttributeList = otherElement.Attributes[key];
                if (otherAttributeList != null && otherAttributeList.Any())
                {
                    var attributeList = otherAttributeList.Select(extensionAttribute => extensionAttribute.Clone()).ToList();
                    attributes[key] = attributeList;
                }
            }
        }
    }

    public void SetAttributes(Dictionary<String, List<ExtensionAttribute>> dictionary)
    {
        throw new NotImplementedException();
    }

    public abstract BaseElement Clone();
}
