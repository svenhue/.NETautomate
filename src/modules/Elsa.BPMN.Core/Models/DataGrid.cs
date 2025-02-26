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
public class DataGrid : IComplexDataType
{
    protected List<DataGridRow> rows = new();

    public List<DataGridRow> Rows
    {
        get { return rows; }
        set { rows = value; }
    }

    public DataGrid Clone()
    {
        var clone = new DataGrid();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(DataGrid otherGrid)
    {
        rows = new List<DataGridRow>();
        if (otherGrid.Rows != null && otherGrid.Rows.Count > 0)
        {
            foreach (var row in otherGrid.Rows)
            {
                rows.Add(row.Clone());
            }
        }
    }
}
