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

public class ItemDefinition : BaseElement
{
    protected string structureRef;
    protected string itemKind;

    public string StructureRef
    {
        get { return structureRef; }
        set { structureRef = value; }
    }

    public string ItemKind
    {
        get { return itemKind; }
        set { itemKind = value; }
    }

    public override ItemDefinition Clone()
    {
        ItemDefinition clone = new ItemDefinition();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(ItemDefinition otherElement)
    {
        base.SetValues(otherElement);
        StructureRef = otherElement.StructureRef;
        ItemKind = otherElement.ItemKind;
    }
}
