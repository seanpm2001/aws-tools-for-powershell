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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Generates suggestions for addresses and points of interest based on partial or misspelled
    /// free-form text. This operation is also known as autocomplete, autosuggest, or fuzzy
    /// matching.
    /// 
    ///  
    /// <para>
    /// Optional parameters let you narrow your search results by bounding box or country,
    /// or bias your search toward a specific position on the globe.
    /// </para><note><para>
    /// You can search for suggested place names near a specified position by using <code>BiasPosition</code>,
    /// or filter results within a bounding box by using <code>FilterBBox</code>. These parameters
    /// are mutually exclusive; using both <code>BiasPosition</code> and <code>FilterBBox</code>
    /// in the same command returns an error.
    /// </para></note>
    /// </summary>
    [Cmdlet("Search", "LOCPlaceIndexForSuggestion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsResponse")]
    [AWSCmdlet("Calls the Amazon Location Service SearchPlaceIndexForSuggestions API operation.", Operation = new[] {"SearchPlaceIndexForSuggestions"}, SelectReturnType = typeof(Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsResponse",
        "This cmdlet returns an Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchLOCPlaceIndexForSuggestionCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter BiasPosition
        /// <summary>
        /// <para>
        /// <para>An optional parameter that indicates a preference for place suggestions that are closer
        /// to a specified position.</para><para> If provided, this parameter must contain a pair of numbers. The first number represents
        /// the X coordinate, or longitude; the second number represents the Y coordinate, or
        /// latitude.</para><para>For example, <code>[-123.1174, 49.2847]</code> represents the position with longitude
        /// <code>-123.1174</code> and latitude <code>49.2847</code>.</para><note><para><code>BiasPosition</code> and <code>FilterBBox</code> are mutually exclusive. Specifying
        /// both options results in an error. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] BiasPosition { get; set; }
        #endregion
        
        #region Parameter FilterBBox
        /// <summary>
        /// <para>
        /// <para>An optional parameter that limits the search results by returning only suggestions
        /// within a specified bounding box.</para><para> If provided, this parameter must contain a total of four consecutive numbers in two
        /// pairs. The first pair of numbers represents the X and Y coordinates (longitude and
        /// latitude, respectively) of the southwest corner of the bounding box; the second pair
        /// of numbers represents the X and Y coordinates (longitude and latitude, respectively)
        /// of the northeast corner of the bounding box.</para><para>For example, <code>[-12.7935, -37.4835, -12.0684, -36.9542]</code> represents a bounding
        /// box where the southwest corner has longitude <code>-12.7935</code> and latitude <code>-37.4835</code>,
        /// and the northeast corner has longitude <code>-12.0684</code> and latitude <code>-36.9542</code>.</para><note><para><code>FilterBBox</code> and <code>BiasPosition</code> are mutually exclusive. Specifying
        /// both options results in an error. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] FilterBBox { get; set; }
        #endregion
        
        #region Parameter FilterCountry
        /// <summary>
        /// <para>
        /// <para>An optional parameter that limits the search results by returning only suggestions
        /// within the provided list of countries.</para><ul><li><para>Use the <a href="https://www.iso.org/iso-3166-country-codes.html">ISO 3166</a> 3-digit
        /// country code. For example, Australia uses three upper-case characters: <code>AUS</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCountries")]
        public System.String[] FilterCountry { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the place index resource you want to use for the search.</para>
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
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The preferred language used to return results. The value must be a valid <a href="https://tools.ietf.org/search/bcp47">BCP
        /// 47</a> language tag, for example, <code>en</code> for English.</para><para>This setting affects the languages used in the results. It does not change which results
        /// are returned. If the language is not specified, or not supported for a particular
        /// result, the partner automatically chooses a language for the result.</para><para>Used only when the partner selected is Here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Language { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>The free-form partial text to use to generate place suggestions. For example, <code>eiffel
        /// tow</code>.</para>
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
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional parameter. The maximum number of results returned per request. </para><para>The default: <code>5</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IndexName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IndexName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IndexName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-LOCPlaceIndexForSuggestion (SearchPlaceIndexForSuggestions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsResponse, SearchLOCPlaceIndexForSuggestionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IndexName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BiasPosition != null)
            {
                context.BiasPosition = new List<System.Double>(this.BiasPosition);
            }
            if (this.FilterBBox != null)
            {
                context.FilterBBox = new List<System.Double>(this.FilterBBox);
            }
            if (this.FilterCountry != null)
            {
                context.FilterCountry = new List<System.String>(this.FilterCountry);
            }
            context.IndexName = this.IndexName;
            #if MODULAR
            if (this.IndexName == null && ParameterWasBound(nameof(this.IndexName)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Language = this.Language;
            context.MaxResult = this.MaxResult;
            context.Text = this.Text;
            #if MODULAR
            if (this.Text == null && ParameterWasBound(nameof(this.Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsRequest();
            
            if (cmdletContext.BiasPosition != null)
            {
                request.BiasPosition = cmdletContext.BiasPosition;
            }
            if (cmdletContext.FilterBBox != null)
            {
                request.FilterBBox = cmdletContext.FilterBBox;
            }
            if (cmdletContext.FilterCountry != null)
            {
                request.FilterCountries = cmdletContext.FilterCountry;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
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
        
        private Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "SearchPlaceIndexForSuggestions");
            try
            {
                #if DESKTOP
                return client.SearchPlaceIndexForSuggestions(request);
                #elif CORECLR
                return client.SearchPlaceIndexForSuggestionsAsync(request).GetAwaiter().GetResult();
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
            public List<System.Double> BiasPosition { get; set; }
            public List<System.Double> FilterBBox { get; set; }
            public List<System.String> FilterCountry { get; set; }
            public System.String IndexName { get; set; }
            public System.String Language { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String Text { get; set; }
            public System.Func<Amazon.LocationService.Model.SearchPlaceIndexForSuggestionsResponse, SearchLOCPlaceIndexForSuggestionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}