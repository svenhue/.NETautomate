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
/// Interface for accessing Element attributes.
/// 
/// @author Martin Grofcik
/// </summary>
public interface IHasExtensionAttributes
{
    /// <summary>
    /// Get element's attributes
    /// </summary>
    Dictionary<string, List<ExtensionAttribute>> Attributes { get; }

    /// <summary>
    /// Return value of the attribute from given namespace with given name.
    /// </summary>
    /// <param name="namespace">The namespace</param>
    /// <param name="name">The attribute name</param>
    /// <returns>Attribute value or null in case when attribute was not found</returns>
    string GetAttributeValue(string @namespace, string name);

    /// <summary>
    /// Add attribute to the object
    /// </summary>
    /// <param name="attribute">The attribute to add</param>
    void AddAttribute(ExtensionAttribute attribute);

    /// <summary>
    /// Set all object's attributes
    /// </summary>
    /// <param name="attributes">The attributes to set</param>
    void SetAttributes(Dictionary<string, List<ExtensionAttribute>> attributes);
}
