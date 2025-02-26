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
public class CollectionHandler : BaseElement
{
    protected string implementationType;
    protected string implementation;

    public string ImplementationType
    {
        get { return implementationType; }
        set { implementationType = value; }
    }

    public string Implementation
    {
        get { return implementation; }
        set { implementation = value; }
    }

    public void SetValues(CollectionHandler otherParser)
    {
        base.SetValues(otherParser);
        Implementation = otherParser.Implementation;
        ImplementationType = otherParser.ImplementationType;
    }
    
    public override CollectionHandler Clone()
    {
        var clone = new CollectionHandler();
        clone.SetValues(this);
        return clone;
    }
}
