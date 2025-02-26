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

public class Import : BaseElement
{
    protected string importType;
    protected string location;
    protected string @namespace;

    public string ImportType
    {
        get { return importType; }
        set { importType = value; }
    }

    public string Location
    {
        get { return location; }
        set { location = value; }
    }

    public string Namespace
    {
        get { return @namespace; }
        set { @namespace = value; }
    }

    public override Import Clone()
    {
        Import clone = new Import();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(Import otherElement)
    {
        base.SetValues(otherElement);
        ImportType = otherElement.ImportType;
        Location = otherElement.Location;
        Namespace = otherElement.Namespace;
    }
}
