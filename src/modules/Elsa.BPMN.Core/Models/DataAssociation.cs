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

public class DataAssociation : BaseElement
{
    protected string sourceRef;
    protected string targetRef;
    protected string transformation;
    protected List<Assignment> assignments = new();

    public string SourceRef
    {
        get { return sourceRef; }
        set { sourceRef = value; }
    }

    public string TargetRef
    {
        get { return targetRef; }
        set { targetRef = value; }
    }

    public string Transformation
    {
        get { return transformation; }
        set { transformation = value; }
    }

    public List<Assignment> Assignments
    {
        get { return assignments; }
        set { assignments = value; }
    }

    public override DataAssociation Clone()
    {
        var clone = new DataAssociation();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(DataAssociation otherAssociation)
    {
        base.SetValues(otherAssociation);
        SourceRef = otherAssociation.SourceRef;
        TargetRef = otherAssociation.TargetRef;
        Transformation = otherAssociation.Transformation;

        assignments = new List<Assignment>();
        if (otherAssociation.Assignments != null && otherAssociation.Assignments.Count > 0)
        {
            foreach (var assignment in otherAssociation.Assignments)
            {
                assignments.Add(assignment.Clone());
            }
        }
    }
}
