/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.CodeGuruSecurity;
using Amazon.CodeGuruSecurity.Model;

namespace Amazon.PowerShell.Cmdlets.CGS
{
    /// <summary>
    /// Returns a list of all the standard scans in an account. Does not return express scans.
    /// </summary>
    [Cmdlet("Get", "CGSScanList")]
    [OutputType("Amazon.CodeGuruSecurity.Model.ScanSummary")]
    [AWSCmdlet("Calls the Amazon CodeGuru Security ListScans API operation.", Operation = new[] {"ListScans"}, SelectReturnType = typeof(Amazon.CodeGuruSecurity.Model.ListScansResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruSecurity.Model.ScanSummary or Amazon.CodeGuruSecurity.Model.ListScansResponse",
        "This cmdlet returns a collection of Amazon.CodeGuruSecurity.Model.ScanSummary objects.",
        "The service call response (type Amazon.CodeGuruSecurity.Model.ListScansResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCGSScanListCmdlet : AmazonCodeGuruSecurityClientCmdlet, IExecutor
    {
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in the response. Use this parameter when paginating
        /// results. If additional results exist beyond the number you specify, the <code>nextToken</code>
        /// element is returned in the response. Use <code>nextToken</code> in a subsequent request
        /// to retrieve additional results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to use for paginating results that are returned in the response. Set the value
        /// of this parameter to null for the first request. For subsequent calls, use the <code>nextToken</code>
        /// value returned from the previous request to continue listing results after the first
        /// page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruSecurity.Model.ListScansResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruSecurity.Model.ListScansResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Summaries";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeGuruSecurity.Model.ListScansResponse, GetCGSScanListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodeGuruSecurity.Model.ListScansRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CodeGuruSecurity.Model.ListScansResponse CallAWSServiceOperation(IAmazonCodeGuruSecurity client, Amazon.CodeGuruSecurity.Model.ListScansRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Security", "ListScans");
            try
            {
                #if DESKTOP
                return client.ListScans(request);
                #elif CORECLR
                return client.ListScansAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.CodeGuruSecurity.Model.ListScansResponse, GetCGSScanListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summaries;
        }
        
    }
}
