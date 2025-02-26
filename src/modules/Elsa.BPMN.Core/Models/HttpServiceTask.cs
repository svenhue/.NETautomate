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
public class HttpServiceTask : ServiceTask
{
    protected FlowableHttpRequestHandler httpRequestHandler;
    protected FlowableHttpResponseHandler httpResponseHandler;
    protected bool? parallelInSameTransaction;

    public FlowableHttpRequestHandler HttpRequestHandler
    {
        get { return httpRequestHandler; }
        set { httpRequestHandler = value; }
    }

    public FlowableHttpResponseHandler HttpResponseHandler
    {
        get { return httpResponseHandler; }
        set { httpResponseHandler = value; }
    }

    public bool? ParallelInSameTransaction
    {
        get { return parallelInSameTransaction; }
        set { parallelInSameTransaction = value; }
    }

    public override HttpServiceTask Clone()
    {
        HttpServiceTask clone = new HttpServiceTask();
        clone.SetValues(this);
        return clone;
    }

    public void SetValues(HttpServiceTask otherElement)
    {
        base.SetValues(otherElement);
        
        ParallelInSameTransaction = otherElement.ParallelInSameTransaction;

        if (otherElement.HttpRequestHandler != null)
        {
            HttpRequestHandler = otherElement.HttpRequestHandler.Clone();
        }
        
        if (otherElement.HttpResponseHandler != null)
        {
            HttpResponseHandler = otherElement.HttpResponseHandler.Clone();
        }
    }
}
