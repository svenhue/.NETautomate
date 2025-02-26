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
public class GraphicInfo
{
    protected double x;
    protected double y;
    protected double height;
    protected double width;
    protected BaseElement element;
    protected bool? expanded;
    protected int xmlRowNumber;
    protected int xmlColumnNumber;
    protected double rotation;
    
    public GraphicInfo() {}

    public GraphicInfo(double x, double y, double height, double width)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public GraphicInfo(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public double Y
    {
        get { return y; }
        set { y = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public bool? Expanded
    {
        get { return expanded; }
        set { expanded = value; }
    }

    public BaseElement Element
    {
        get { return element; }
        set { element = value; }
    }

    public int XmlRowNumber
    {
        get { return xmlRowNumber; }
        set { xmlRowNumber = value; }
    }

    public int XmlColumnNumber
    {
        get { return xmlColumnNumber; }
        set { xmlColumnNumber = value; }
    }

    public double Rotation
    {
        get { return rotation; }
        set { rotation = value; }
    }

    public bool Equals(GraphicInfo ginfo)
    {
        if (this.X != ginfo.X)
        {
            return false;
        }
        if (this.Y != ginfo.Y)
        {
            return false;
        }
        if (this.Height != ginfo.Height)
        {
            return false;
        }
        if (this.Width != ginfo.Width)
        {
            return false;
        }
        if (this.Rotation != ginfo.Rotation)
        {
            return false;
        }

        // check for zero value in case we are comparing model value to BPMN DI value
        // model values do not have xml location information
        if (0 != this.XmlColumnNumber && 0 != ginfo.XmlColumnNumber && this.XmlColumnNumber != ginfo.XmlColumnNumber)
        {
            return false;
        }
        if (0 != this.XmlRowNumber && 0 != ginfo.XmlRowNumber && this.XmlRowNumber != ginfo.XmlRowNumber)
        {
            return false;
        }

        // only check for elements that support this value
        if (null != this.Expanded && null != ginfo.Expanded && !this.Expanded.Equals(ginfo.Expanded))
        {
            return false;
        }
        return true;
    }
}
