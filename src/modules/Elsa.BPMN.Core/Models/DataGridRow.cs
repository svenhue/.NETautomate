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
public class DataGridRow
{
    protected int index;
    protected List<DataGridField> fields = new();

    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    public List<DataGridField> Fields
    {
        get { return fields; }
        set { fields = value; }
    }

    public DataGridRow Clone()
    {
        var clone = new DataGridRow();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(DataGridRow otherRow)
    {
        Index = otherRow.Index;

        fields = new List<DataGridField>();
        if (otherRow.Fields != null && otherRow.Fields.Count > 0)
        {
            foreach (var field in otherRow.Fields)
            {
                fields.Add(field.Clone());
            }
        }
    }
}
