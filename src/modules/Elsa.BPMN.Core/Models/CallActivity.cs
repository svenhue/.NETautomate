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
/// @author Joram Barrez
/// </summary>
public class CallActivity : Activity, IHasOutParameters, IHasInParameters
{
    protected string calledElement;
    protected string calledElementType;
    protected bool inheritVariables;
    protected bool sameDeployment;
    protected List<IOParameter> inParameters = new();
    protected List<IOParameter> outParameters = new();
    protected string processInstanceName;
    protected string businessKey;
    protected bool inheritBusinessKey;
    protected bool useLocalScopeForOutParameters;
    protected bool completeAsync;
    protected bool? fallbackToDefaultTenant;
    protected string processInstanceIdVariableName;

    public string CalledElement
    {
        get { return calledElement; }
        set { calledElement = value; }
    }
    public IList<IOParameter> GetOutParameters()
    {
        throw new NotImplementedException();
    }

    public IList<IOParameter> GetInParameters()
    {
        throw new NotImplementedException();
    }

    public void SetOutParameters(IList<IOParameter> ioParameters)
    {
        throw new NotImplementedException();
    }

    public void SetInParameters(IList<IOParameter> ioParameters)
    {
        throw new NotImplementedException();
    }
    public bool InheritVariables
    {
        get { return inheritVariables; }
        set { inheritVariables = value; }
    }

    public bool SameDeployment
    {
        get { return sameDeployment; }
        set { sameDeployment = value; }
    }

    public List<IOParameter> InParameters
    {
        get { return inParameters; }
        set { inParameters = value; }
    }

    public void AddInParameter(IOParameter inParameter)
    {
        inParameters.Add(inParameter);
    }

    public List<IOParameter> OutParameters
    {
        get { return outParameters; }
        set { outParameters = value; }
    }

    public void AddOutParameter(IOParameter outParameter)
    {
        outParameters.Add(outParameter);
    }
    
    public string ProcessInstanceName
    {
        get { return processInstanceName; }
        set { processInstanceName = value; }
    }

    public string BusinessKey
    {
        get { return businessKey; }
        set { businessKey = value; }
    }

    public bool InheritBusinessKey
    {
        get { return inheritBusinessKey; }
        set { inheritBusinessKey = value; }
    }

    public bool UseLocalScopeForOutParameters
    {
        get { return useLocalScopeForOutParameters; }
        set { useLocalScopeForOutParameters = value; }
    }
    
    public bool CompleteAsync
    {
        get { return completeAsync; }
        set { completeAsync = value; }
    }

    public bool? FallbackToDefaultTenant
    {
        get { return fallbackToDefaultTenant; }
        set { fallbackToDefaultTenant = value; }
    }
    
    public string CalledElementType
    {
        get { return calledElementType; }
        set { calledElementType = value; }
    }

    public string ProcessInstanceIdVariableName
    {
        get { return processInstanceIdVariableName; }
        set { processInstanceIdVariableName = value; }
    }

    public override CallActivity Clone()
    {
        var clone = new CallActivity();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(CallActivity otherElement)
    {
        base.SetValues(otherElement);
        CalledElement = otherElement.CalledElement;
        CalledElementType = otherElement.CalledElementType;
        BusinessKey = otherElement.BusinessKey;
        InheritBusinessKey = otherElement.InheritBusinessKey;
        InheritVariables = otherElement.InheritVariables;
        SameDeployment = otherElement.SameDeployment;
        UseLocalScopeForOutParameters = otherElement.UseLocalScopeForOutParameters;
        CompleteAsync = otherElement.CompleteAsync;
        FallbackToDefaultTenant = otherElement.FallbackToDefaultTenant;

        inParameters = new List<IOParameter>();
        if (otherElement.InParameters != null && otherElement.InParameters.Count > 0)
        {
            foreach (var parameter in otherElement.InParameters)
            {
                inParameters.Add(parameter.Clone());
            }
        }

        outParameters = new List<IOParameter>();
        if (otherElement.OutParameters != null && otherElement.OutParameters.Count > 0)
        {
            foreach (var parameter in otherElement.OutParameters)
            {
                outParameters.Add(parameter.Clone());
            }
        }
    }
}
