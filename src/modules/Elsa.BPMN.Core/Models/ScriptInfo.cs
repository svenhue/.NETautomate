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
/// Contains relevant information for script evaluation.
/// </summary>
/// <author>Arthur Hupka-Merle</author>
public class ScriptInfo : BaseElement
{
    protected string language;
    protected string resultVariable;
    protected string script;

    /// <summary>
    /// The script language
    /// </summary>
    public string Language
    {
        get { return language; }
        set { language = value; }
    }

    /// <summary>
    /// The name of the result variable where the
    /// script return value is written to.
    /// </summary>
    public string ResultVariable
    {
        get { return resultVariable; }
        set { resultVariable = value; }
    }

    /// <summary>
    /// The actual script payload in the provided language.
    /// </summary>
    public string Script
    {
        get { return script; }
        set { script = value; }
    }

    public override ScriptInfo Clone()
    {
        ScriptInfo clone = new ScriptInfo();
        clone.Language = this.language;
        clone.Script = this.script;
        clone.ResultVariable = this.resultVariable;
        return clone;
    }
}
