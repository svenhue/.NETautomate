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

public class Assignment : BaseElement
{
    protected string from;
    protected string to;

    public string From
    {
        get { return from; }
        set { from = value; }
    }

    public string To
    {
        get { return to; }
        set { to = value; }
    }

    public override Assignment Clone()
    {
        var clone = new Assignment();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(Assignment otherAssignment)
    {
        base.SetValues(otherAssignment);
        From = otherAssignment.From;
        To = otherAssignment.To;
    }
}
