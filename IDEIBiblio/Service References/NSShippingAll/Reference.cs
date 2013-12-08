﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDEIBiblio.NSShippingAll {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Name="server.ShippingAllPortType", Namespace="urn:server.ShippingAll", ConfigurationName="NSShippingAll.serverShippingAllPortType")]
    public interface serverShippingAllPortType {
        
        // CODEGEN: Generating message contract since the wrapper namespace (url:server.ShippingAll) of message getDeliveryPriceRequest does not match the default value (urn:server.ShippingAll)
        [System.ServiceModel.OperationContractAttribute(Action="url:server.ShippingAll#ShippingAll", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        IDEIBiblio.NSShippingAll.getDeliveryPriceResponse getDeliveryPrice(IDEIBiblio.NSShippingAll.getDeliveryPriceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="url:server.ShippingAll#ShippingAll", ReplyAction="*")]
        System.Threading.Tasks.Task<IDEIBiblio.NSShippingAll.getDeliveryPriceResponse> getDeliveryPriceAsync(IDEIBiblio.NSShippingAll.getDeliveryPriceRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getDeliveryPrice", WrapperNamespace="url:server.ShippingAll", IsWrapped=true)]
    public partial class getDeliveryPriceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public int qtd;
        
        public getDeliveryPriceRequest() {
        }
        
        public getDeliveryPriceRequest(int qtd) {
            this.qtd = qtd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getDeliveryPriceResponse", WrapperNamespace="url:server.ShippingAll", IsWrapped=true)]
    public partial class getDeliveryPriceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public int @return;
        
        public getDeliveryPriceResponse() {
        }
        
        public getDeliveryPriceResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface serverShippingAllPortTypeChannel : IDEIBiblio.NSShippingAll.serverShippingAllPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class serverShippingAllPortTypeClient : System.ServiceModel.ClientBase<IDEIBiblio.NSShippingAll.serverShippingAllPortType>, IDEIBiblio.NSShippingAll.serverShippingAllPortType {
        
        public serverShippingAllPortTypeClient() {
        }
        
        public serverShippingAllPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public serverShippingAllPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public serverShippingAllPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public serverShippingAllPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        IDEIBiblio.NSShippingAll.getDeliveryPriceResponse IDEIBiblio.NSShippingAll.serverShippingAllPortType.getDeliveryPrice(IDEIBiblio.NSShippingAll.getDeliveryPriceRequest request) {
            return base.Channel.getDeliveryPrice(request);
        }
        
        public int getDeliveryPrice(int qtd) {
            IDEIBiblio.NSShippingAll.getDeliveryPriceRequest inValue = new IDEIBiblio.NSShippingAll.getDeliveryPriceRequest();
            inValue.qtd = qtd;
            IDEIBiblio.NSShippingAll.getDeliveryPriceResponse retVal = ((IDEIBiblio.NSShippingAll.serverShippingAllPortType)(this)).getDeliveryPrice(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<IDEIBiblio.NSShippingAll.getDeliveryPriceResponse> IDEIBiblio.NSShippingAll.serverShippingAllPortType.getDeliveryPriceAsync(IDEIBiblio.NSShippingAll.getDeliveryPriceRequest request) {
            return base.Channel.getDeliveryPriceAsync(request);
        }
        
        public System.Threading.Tasks.Task<IDEIBiblio.NSShippingAll.getDeliveryPriceResponse> getDeliveryPriceAsync(int qtd) {
            IDEIBiblio.NSShippingAll.getDeliveryPriceRequest inValue = new IDEIBiblio.NSShippingAll.getDeliveryPriceRequest();
            inValue.qtd = qtd;
            return ((IDEIBiblio.NSShippingAll.serverShippingAllPortType)(this)).getDeliveryPriceAsync(inValue);
        }
    }
}
