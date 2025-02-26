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
/// @author Filip Hrisafov
/// </summary>
public class ExternalWorkerServiceTask : ServiceTask, IHasOutParameters, IHasInParameters
{
    protected string topic;
    protected bool doNotIncludeVariables;
    protected List<IOParameter> inParameters = new();
    protected List<IOParameter> outParameters = new();

    public string Topic
    {
        get { return topic; }
        set { topic = value; }
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
    
    
    public bool DoNotIncludeVariables
    {
        get { return doNotIncludeVariables; }
        set { doNotIncludeVariables = value; }
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

    public override ExternalWorkerServiceTask Clone()
    {
        var clone = new ExternalWorkerServiceTask();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(ExternalWorkerServiceTask otherElement)
    {
        base.SetValues(otherElement);
        Topic = otherElement.Topic;
        DoNotIncludeVariables = otherElement.DoNotIncludeVariables;
        
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
