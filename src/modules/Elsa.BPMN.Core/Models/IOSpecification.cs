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

public class IOSpecification : BaseElement
{
    protected List<DataSpec> dataInputs = new List<DataSpec>();
    protected List<DataSpec> dataOutputs = new List<DataSpec>();
    protected List<string> dataInputRefs = new List<string>();
    protected List<string> dataOutputRefs = new List<string>();

    public List<DataSpec> DataInputs
    {
        get { return dataInputs; }
        set { dataInputs = value; }
    }

    public List<DataSpec> DataOutputs
    {
        get { return dataOutputs; }
        set { dataOutputs = value; }
    }

    public List<string> DataInputRefs
    {
        get { return dataInputRefs; }
        set { dataInputRefs = value; }
    }

    public List<string> DataOutputRefs
    {
        get { return dataOutputRefs; }
        set { dataOutputRefs = value; }
    }

    public override IOSpecification Clone()
    {
        IOSpecification clone = new IOSpecification();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(IOSpecification otherSpec)
    {
        base.SetValues(otherSpec);
        dataInputs = new List<DataSpec>();
        if (otherSpec.DataInputs != null && otherSpec.DataInputs.Count > 0)
        {
            foreach (DataSpec dataSpec in otherSpec.DataInputs)
            {
                dataInputs.Add(dataSpec.Clone());
            }
        }

        dataOutputs = new List<DataSpec>();
        if (otherSpec.DataOutputs != null && otherSpec.DataOutputs.Count > 0)
        {
            foreach (DataSpec dataSpec in otherSpec.DataOutputs)
            {
                dataOutputs.Add(dataSpec.Clone());
            }
        }

        dataInputRefs = new List<string>(otherSpec.DataInputRefs);
        dataOutputRefs = new List<string>(otherSpec.DataOutputRefs);
    }
}
