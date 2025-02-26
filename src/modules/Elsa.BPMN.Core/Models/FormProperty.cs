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
public class FormProperty : BaseElement
{
    protected string name;
    protected string expression;
    protected string variable;
    protected string type;
    protected string defaultExpression;
    protected string datePattern;
    protected bool readable = true;
    protected bool writeable = true;
    protected bool required;
    protected List<FormValue> formValues = new();

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Expression
    {
        get { return expression; }
        set { expression = value; }
    }

    public string Variable
    {
        get { return variable; }
        set { variable = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public string DefaultExpression
    {
        get { return defaultExpression; }
        set { defaultExpression = value; }
    }

    public string DatePattern
    {
        get { return datePattern; }
        set { datePattern = value; }
    }

    public bool Readable
    {
        get { return readable; }
        set { readable = value; }
    }

    public bool Writeable
    {
        get { return writeable; }
        set { writeable = value; }
    }

    public bool Required
    {
        get { return required; }
        set { required = value; }
    }

    public List<FormValue> FormValues
    {
        get { return formValues; }
        set { formValues = value; }
    }

    public override FormProperty Clone()
    {
        var clone = new FormProperty();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(FormProperty otherProperty)
    {
        base.SetValues(otherProperty);
        Name = otherProperty.Name;
        Expression = otherProperty.Expression;
        Variable = otherProperty.Variable;
        Type = otherProperty.Type;
        DefaultExpression = otherProperty.DefaultExpression;
        DatePattern = otherProperty.DatePattern;
        Readable = otherProperty.Readable;
        Writeable = otherProperty.Writeable;
        Required = otherProperty.Required;

        formValues = new List<FormValue>();
        if (otherProperty.FormValues != null && otherProperty.FormValues.Count > 0)
        {
            foreach (var formValue in otherProperty.FormValues)
            {
                formValues.Add(formValue.Clone());
            }
        }
    }
}
