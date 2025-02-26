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
/// @author Saeid Mirzaei
/// </summary>
public class MapExceptionEntry
{
    protected string errorCode;
    protected string className;
    protected bool andChildren;
    protected string rootCause;

    public MapExceptionEntry()
    {
    }

    public MapExceptionEntry(string errorCode, string className, bool andChildren, string rootCause)
    {
        this.errorCode = errorCode;
        this.className = className;
        this.andChildren = andChildren;
        this.rootCause = rootCause;
    }

    public string ErrorCode
    {
        get { return errorCode; }
        set { errorCode = value; }
    }

    public string ClassName
    {
        get { return className; }
        set { className = value; }
    }

    public bool AndChildren
    {
        get { return andChildren; }
        set { andChildren = value; }
    }

    public string RootCause
    {
        get { return rootCause; }
        set { rootCause = value; }
    }
}
