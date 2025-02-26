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

using System;
using System.Text.Json;
using System.Text.Json.Nodes;

/// <summary>
/// @author Christophe DENEUX
/// </summary>
public class JsonDataObject : ValuedDataObject
{
    public override void SetValue(object value)
    {
        if (value is string stringValue && !string.IsNullOrWhiteSpace(stringValue.Trim()))
        {
            try
            {
                this.value = JsonNode.Parse(stringValue);
            }
            catch (JsonException e)
            {
                throw new ArgumentException("Invalid JSON expression to parse", e);
            }
        }
        else if (value is JsonNode)
        {
            this.value = value;
        }
        else
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string json = JsonSerializer.Serialize(value, options);
            this.value = JsonNode.Parse(json);
        }
    }

    public override JsonDataObject Clone()
    {
        JsonDataObject clone = new JsonDataObject();
        clone.SetValues(this);
        return clone;
    }
}
