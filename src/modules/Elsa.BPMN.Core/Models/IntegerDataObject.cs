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
/// @author Lori Small
/// </summary>
public class IntegerDataObject : ValuedDataObject
{
    public override void SetValue(object value)
    {
        if (value is string stringValue && !string.IsNullOrWhiteSpace(stringValue.Trim()))
        {
            this.value = int.Parse(value.ToString());
        }
        else if (value is int intValue)
        {
            this.value = intValue;
        }
    }

    public override IntegerDataObject Clone()
    {
        IntegerDataObject clone = new IntegerDataObject();
        clone.SetValues(this);
        return clone;
    }
}
