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

/// <summary>
/// The Resource class is used to specify resources that can be referenced by Activities. These Resources can be Human Resources as well as any other resource
/// assigned to Activities during Process execution time.
/// </summary>
/// <author>Tim Stephenson</author>
public class Resource : BaseElement
{
    protected string name;

    public Resource(string resourceId, string resourceName)
    {
        Id = resourceId;
        Name = resourceName;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override BaseElement Clone()
    {
        Resource clone = new Resource(id, name);
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(Resource otherResource)
    {
        base.SetValues(otherResource);
    }
}
