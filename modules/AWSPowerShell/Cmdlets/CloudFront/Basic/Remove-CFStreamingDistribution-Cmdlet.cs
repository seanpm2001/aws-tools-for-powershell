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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Delete a streaming distribution. To delete an RTMP distribution using the CloudFront
    /// API, perform the following steps.
    /// 
    ///  
    /// <para><b>To delete an RTMP distribution using the CloudFront API</b>:
    /// </para><ol><li><para>
    /// Disable the RTMP distribution.
    /// </para></li><li><para>
    /// Submit a <code>GET Streaming Distribution Config</code> request to get the current
    /// configuration and the <code>Etag</code> header for the distribution. 
    /// </para></li><li><para>
    /// Update the XML document that was returned in the response to your <code>GET Streaming
    /// Distribution Config</code> request to change the value of <code>Enabled</code> to
    /// <code>false</code>.
    /// </para></li><li><para>
    /// Submit a <code>PUT Streaming Distribution Config</code> request to update the configuration
    /// for your distribution. In the request body, include the XML document that you updated
    /// in Step 3. Then set the value of the HTTP <code>If-Match</code> header to the value
    /// of the <code>ETag</code> header that CloudFront returned when you submitted the <code>GET
    /// Streaming Distribution Config</code> request in Step 2.
    /// </para></li><li><para>
    /// Review the response to the <code>PUT Streaming Distribution Config</code> request
    /// to confirm that the distribution was successfully disabled.
    /// </para></li><li><para>
    /// Submit a <code>GET Streaming Distribution Config</code> request to confirm that your
    /// changes have propagated. When propagation is complete, the value of <code>Status</code>
    /// is <code>Deployed</code>.
    /// </para></li><li><para>
    /// Submit a <code>DELETE Streaming Distribution</code> request. Set the value of the
    /// HTTP <code>If-Match</code> header to the value of the <code>ETag</code> header that
    /// CloudFront returned when you submitted the <code>GET Streaming Distribution Config</code>
    /// request in Step 2.
    /// </para></li><li><para>
    /// Review the response to your <code>DELETE Streaming Distribution</code> request to
    /// confirm that the distribution was successfully deleted.
    /// </para></li></ol><para>
    /// For information about deleting a distribution using the CloudFront console, see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/HowToDeleteDistribution.html">Deleting
    /// a Distribution</a> in the <i>Amazon CloudFront Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "CFStreamingDistribution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudFront DeleteStreamingDistribution API operation.", Operation = new[] {"DeleteStreamingDistribution"}, SelectReturnType = typeof(Amazon.CloudFront.Model.DeleteStreamingDistributionResponse))]
    [AWSCmdletOutput("None or Amazon.CloudFront.Model.DeleteStreamingDistributionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudFront.Model.DeleteStreamingDistributionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveCFStreamingDistributionCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The distribution ID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IfMatch
        /// <summary>
        /// <para>
        /// <para>The value of the <code>ETag</code> header that you received when you disabled the
        /// streaming distribution. For example: <code>E2QWRUHAPOMQZL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String IfMatch { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.DeleteStreamingDistributionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-CFStreamingDistribution (DeleteStreamingDistribution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.DeleteStreamingDistributionResponse, RemoveCFStreamingDistributionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IfMatch = this.IfMatch;
            
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
            var request = new Amazon.CloudFront.Model.DeleteStreamingDistributionRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IfMatch != null)
            {
                request.IfMatch = cmdletContext.IfMatch;
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
        
        private Amazon.CloudFront.Model.DeleteStreamingDistributionResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.DeleteStreamingDistributionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "DeleteStreamingDistribution");
            try
            {
                #if DESKTOP
                return client.DeleteStreamingDistribution(request);
                #elif CORECLR
                return client.DeleteStreamingDistributionAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String IfMatch { get; set; }
            public System.Func<Amazon.CloudFront.Model.DeleteStreamingDistributionResponse, RemoveCFStreamingDistributionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
