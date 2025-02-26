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
/// A scriptable element supporting the type="script" implementation type.
/// </summary>
public interface IHasScriptInfo
{
    /// <summary>
    /// Return the script info, if present.
    /// <para>
    /// ScriptInfo must be populated, when &lt;element type="script" ...&gt; is set
    /// on the element. Meta information and the script payload are provided in the ScriptInfo object.
    /// </para>
    /// </summary>
    ScriptInfo ScriptInfo { get; set; }
}
