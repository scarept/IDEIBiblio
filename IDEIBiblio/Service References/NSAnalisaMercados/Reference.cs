﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDEIBiblio.NSAnalisaMercados {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Name="server.AnalisaMercadosPortType", Namespace="urn:server.AnalisaMercados", ConfigurationName="NSAnalisaMercados.serverAnalisaMercadosPortType")]
    public interface serverAnalisaMercadosPortType {
        
        // CODEGEN: Generating message contract since the wrapper namespace (url:server.AnalisaMercados) of message getUpdatePriceRequest does not match the default value (urn:server.AnalisaMercados)
        [System.ServiceModel.OperationContractAttribute(Action="url:server.AnalisaMercados#AnalisaMercados", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        IDEIBiblio.NSAnalisaMercados.getUpdatePriceResponse getUpdatePrice(IDEIBiblio.NSAnalisaMercados.getUpdatePriceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="url:server.AnalisaMercados#AnalisaMercados", ReplyAction="*")]
        System.Threading.Tasks.Task<IDEIBiblio.NSAnalisaMercados.getUpdatePriceResponse> getUpdatePriceAsync(IDEIBiblio.NSAnalisaMercados.getUpdatePriceRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:server.AnalisaMercados")]
    public partial class Valores : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int idField;
        
        private int vALORField;
        
        /// <remarks/>
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("ID");
            }
        }
        
        /// <remarks/>
        public int VALOR {
            get {
                return this.vALORField;
            }
            set {
                this.vALORField = value;
                this.RaisePropertyChanged("VALOR");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getUpdatePrice", WrapperNamespace="url:server.AnalisaMercados", IsWrapped=true)]
    public partial class getUpdatePriceRequest {
        
        public getUpdatePriceRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getUpdatePriceResponse", WrapperNamespace="url:server.AnalisaMercados", IsWrapped=true)]
    public partial class getUpdatePriceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public IDEIBiblio.NSAnalisaMercados.Valores @return;
        
        public getUpdatePriceResponse() {
        }
        
        public getUpdatePriceResponse(IDEIBiblio.NSAnalisaMercados.Valores @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface serverAnalisaMercadosPortTypeChannel : IDEIBiblio.NSAnalisaMercados.serverAnalisaMercadosPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class serverAnalisaMercadosPortTypeClient : System.ServiceModel.ClientBase<IDEIBiblio.NSAnalisaMercados.serverAnalisaMercadosPortType>, IDEIBiblio.NSAnalisaMercados.serverAnalisaMercadosPortType {
        
        public serverAnalisaMercadosPortTypeClient() {
        }
        
        public serverAnalisaMercadosPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public serverAnalisaMercadosPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public serverAnalisaMercadosPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public serverAnalisaMercadosPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        IDEIBiblio.NSAnalisaMercados.getUpdatePriceResponse IDEIBiblio.NSAnalisaMercados.serverAnalisaMercadosPortType.getUpdatePrice(IDEIBiblio.NSAnalisaMercados.getUpdatePriceRequest request) {
            return base.Channel.getUpdatePrice(request);
        }
        
        public IDEIBiblio.NSAnalisaMercados.Valores getUpdatePrice() {
            IDEIBiblio.NSAnalisaMercados.getUpdatePriceRequest inValue = new IDEIBiblio.NSAnalisaMercados.getUpdatePriceRequest();
            IDEIBiblio.NSAnalisaMercados.getUpdatePriceResponse retVal = ((IDEIBiblio.NSAnalisaMercados.serverAnalisaMercadosPortType)(this)).getUpdatePrice(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<IDEIBiblio.NSAnalisaMercados.getUpdatePriceResponse> IDEIBiblio.NSAnalisaMercados.serverAnalisaMercadosPortType.getUpdatePriceAsync(IDEIBiblio.NSAnalisaMercados.getUpdatePriceRequest request) {
            return base.Channel.getUpdatePriceAsync(request);
        }
        
        public System.Threading.Tasks.Task<IDEIBiblio.NSAnalisaMercados.getUpdatePriceResponse> getUpdatePriceAsync() {
            IDEIBiblio.NSAnalisaMercados.getUpdatePriceRequest inValue = new IDEIBiblio.NSAnalisaMercados.getUpdatePriceRequest();
            return ((IDEIBiblio.NSAnalisaMercados.serverAnalisaMercadosPortType)(this)).getUpdatePriceAsync(inValue);
        }
    }
}
