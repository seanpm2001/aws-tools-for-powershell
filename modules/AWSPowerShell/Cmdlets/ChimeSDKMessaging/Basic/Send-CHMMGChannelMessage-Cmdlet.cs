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
using Amazon.ChimeSDKMessaging;
using Amazon.ChimeSDKMessaging.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMG
{
    /// <summary>
    /// Sends a message to a particular channel that the member is a part of.
    /// 
    ///  <note><para>
    /// The <code>x-amz-chime-bearer</code> request header is mandatory. Use the <code>AppInstanceUserArn</code>
    /// of the user that makes the API call as the value in the header.
    /// </para><para>
    /// Also, <code>STANDARD</code> messages can contain 4KB of data and the 1KB of metadata.
    /// <code>CONTROL</code> messages can contain 30 bytes of data and no metadata.
    /// </para></note>
    /// </summary>
    [Cmdlet("Send", "CHMMGChannelMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Messaging SendChannelMessage API operation.", Operation = new[] {"SendChannelMessage"}, SelectReturnType = typeof(Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse",
        "This cmdlet returns an Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendCHMMGChannelMessageCmdlet : AmazonChimeSDKMessagingClientCmdlet, IExecutor
    {
        
        #region Parameter PushNotification_Body
        /// <summary>
        /// <para>
        /// <para>The body of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PushNotification_Body { get; set; }
        #endregion
        
        #region Parameter ChannelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the channel.</para>
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
        public System.String ChannelArn { get; set; }
        #endregion
        
        #region Parameter ChimeBearer
        /// <summary>
        /// <para>
        /// <para>The <code>AppInstanceUserArn</code> of the user that makes the API call.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ChimeBearer { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The <code>Idempotency</code> token for each client request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The content of the message.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter MessageAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes for the message, used for message filtering along with a <code>FilterRule</code>
        /// defined in the <code>PushNotificationPreferences</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageAttributes")]
        public System.Collections.Hashtable MessageAttribute { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The optional metadata for each message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Metadata { get; set; }
        #endregion
        
        #region Parameter Persistence
        /// <summary>
        /// <para>
        /// <para>Boolean that controls whether the message is persisted on the back end. Required.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.ChannelMessagePersistenceType")]
        public Amazon.ChimeSDKMessaging.ChannelMessagePersistenceType Persistence { get; set; }
        #endregion
        
        #region Parameter PushNotification_Title
        /// <summary>
        /// <para>
        /// <para>The title of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PushNotification_Title { get; set; }
        #endregion
        
        #region Parameter PushNotification_Type
        /// <summary>
        /// <para>
        /// <para>Enum value that indicates the type of the push notification for a message. <code>DEFAULT</code>:
        /// Normal mobile push notification. <code>VOIP</code>: VOIP mobile push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.PushNotificationType")]
        public Amazon.ChimeSDKMessaging.PushNotificationType PushNotification_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of message, <code>STANDARD</code> or <code>CONTROL</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.ChannelMessageType")]
        public Amazon.ChimeSDKMessaging.ChannelMessageType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChannelArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChannelArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChannelArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CHMMGChannelMessage (SendChannelMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse, SendCHMMGChannelMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChannelArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChannelArn = this.ChannelArn;
            #if MODULAR
            if (this.ChannelArn == null && ParameterWasBound(nameof(this.ChannelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChimeBearer = this.ChimeBearer;
            #if MODULAR
            if (this.ChimeBearer == null && ParameterWasBound(nameof(this.ChimeBearer)))
            {
                WriteWarning("You are passing $null as a value for parameter ChimeBearer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.Content = this.Content;
            #if MODULAR
            if (this.Content == null && ParameterWasBound(nameof(this.Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MessageAttribute != null)
            {
                context.MessageAttribute = new Dictionary<System.String, Amazon.ChimeSDKMessaging.Model.MessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageAttribute.Keys)
                {
                    context.MessageAttribute.Add((String)hashKey, (MessageAttributeValue)(this.MessageAttribute[hashKey]));
                }
            }
            context.Metadata = this.Metadata;
            context.Persistence = this.Persistence;
            #if MODULAR
            if (this.Persistence == null && ParameterWasBound(nameof(this.Persistence)))
            {
                WriteWarning("You are passing $null as a value for parameter Persistence which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PushNotification_Body = this.PushNotification_Body;
            context.PushNotification_Title = this.PushNotification_Title;
            context.PushNotification_Type = this.PushNotification_Type;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ChimeSDKMessaging.Model.SendChannelMessageRequest();
            
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
            }
            if (cmdletContext.ChimeBearer != null)
            {
                request.ChimeBearer = cmdletContext.ChimeBearer;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.MessageAttribute != null)
            {
                request.MessageAttributes = cmdletContext.MessageAttribute;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.Persistence != null)
            {
                request.Persistence = cmdletContext.Persistence;
            }
            
             // populate PushNotification
            var requestPushNotificationIsNull = true;
            request.PushNotification = new Amazon.ChimeSDKMessaging.Model.PushNotificationConfiguration();
            System.String requestPushNotification_pushNotification_Body = null;
            if (cmdletContext.PushNotification_Body != null)
            {
                requestPushNotification_pushNotification_Body = cmdletContext.PushNotification_Body;
            }
            if (requestPushNotification_pushNotification_Body != null)
            {
                request.PushNotification.Body = requestPushNotification_pushNotification_Body;
                requestPushNotificationIsNull = false;
            }
            System.String requestPushNotification_pushNotification_Title = null;
            if (cmdletContext.PushNotification_Title != null)
            {
                requestPushNotification_pushNotification_Title = cmdletContext.PushNotification_Title;
            }
            if (requestPushNotification_pushNotification_Title != null)
            {
                request.PushNotification.Title = requestPushNotification_pushNotification_Title;
                requestPushNotificationIsNull = false;
            }
            Amazon.ChimeSDKMessaging.PushNotificationType requestPushNotification_pushNotification_Type = null;
            if (cmdletContext.PushNotification_Type != null)
            {
                requestPushNotification_pushNotification_Type = cmdletContext.PushNotification_Type;
            }
            if (requestPushNotification_pushNotification_Type != null)
            {
                request.PushNotification.Type = requestPushNotification_pushNotification_Type;
                requestPushNotificationIsNull = false;
            }
             // determine if request.PushNotification should be set to null
            if (requestPushNotificationIsNull)
            {
                request.PushNotification = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse CallAWSServiceOperation(IAmazonChimeSDKMessaging client, Amazon.ChimeSDKMessaging.Model.SendChannelMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Messaging", "SendChannelMessage");
            try
            {
                #if DESKTOP
                return client.SendChannelMessage(request);
                #elif CORECLR
                return client.SendChannelMessageAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelArn { get; set; }
            public System.String ChimeBearer { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Content { get; set; }
            public Dictionary<System.String, Amazon.ChimeSDKMessaging.Model.MessageAttributeValue> MessageAttribute { get; set; }
            public System.String Metadata { get; set; }
            public Amazon.ChimeSDKMessaging.ChannelMessagePersistenceType Persistence { get; set; }
            public System.String PushNotification_Body { get; set; }
            public System.String PushNotification_Title { get; set; }
            public Amazon.ChimeSDKMessaging.PushNotificationType PushNotification_Type { get; set; }
            public Amazon.ChimeSDKMessaging.ChannelMessageType Type { get; set; }
            public System.Func<Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse, SendCHMMGChannelMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}