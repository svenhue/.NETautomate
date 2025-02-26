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
public class CaseServiceTask : ServiceTask, IHasOutParameters, IHasInParameters
{
    protected string caseDefinitionKey;
    protected string caseInstanceName;
    protected bool sameDeployment;
    protected string businessKey;
    protected bool inheritBusinessKey;
    protected bool fallbackToDefaultTenant;
    protected string caseInstanceIdVariableName;
    
    protected List<IOParameter> inParameters = new();
    protected List<IOParameter> outParameters = new();

    public string CaseDefinitionKey
    {
        get { return caseDefinitionKey; }
        set { caseDefinitionKey = value; }
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
    public string CaseInstanceName
    {
        get { return caseInstanceName; }
        set { caseInstanceName = value; }
    }

    public bool SameDeployment
    {
        get { return sameDeployment; }
        set { sameDeployment = value; }
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

    public bool FallbackToDefaultTenant
    {
        get { return fallbackToDefaultTenant; }
        set { fallbackToDefaultTenant = value; }
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

    public string CaseInstanceIdVariableName
    {
        get { return caseInstanceIdVariableName; }
        set { caseInstanceIdVariableName = value; }
    }

    public override CaseServiceTask Clone()
    {
        var clone = new CaseServiceTask();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(CaseServiceTask otherElement)
    {
        base.SetValues(otherElement);

        CaseDefinitionKey = otherElement.CaseDefinitionKey;
        CaseInstanceName = otherElement.CaseInstanceName;
        BusinessKey = otherElement.BusinessKey;
        InheritBusinessKey = otherElement.InheritBusinessKey;
        SameDeployment = otherElement.SameDeployment;
        FallbackToDefaultTenant = otherElement.FallbackToDefaultTenant;
        CaseInstanceIdVariableName = otherElement.CaseInstanceIdVariableName;

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
