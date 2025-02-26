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
/// @author Tijs Rademakers
/// </summary>
public class Association : Artifact
{
    protected AssociationDirection associationDirection = AssociationDirection.None;
    protected string sourceRef;
    protected string targetRef;

    public AssociationDirection AssociationDirection
    {
        get { return associationDirection; }
        set { associationDirection = value; }
    }

    public string SourceRef
    {
        get { return sourceRef; }
        set { sourceRef = value; }
    }

    public string TargetRef
    {
        get { return targetRef; }
        set { targetRef = value; }
    }

    public override Association Clone()
    {
        var clone = new Association();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(Association otherElement)
    {
        base.SetValues(otherElement);
        SourceRef = otherElement.SourceRef;
        TargetRef = otherElement.TargetRef;

        if (otherElement.AssociationDirection != null)
        {
            AssociationDirection = otherElement.AssociationDirection;
        }
    }
}
