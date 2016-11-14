﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MailBo.MailBoServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/MailBoService")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageBodyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RecieverField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubjectField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MessageBody {
            get {
                return this.MessageBodyField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageBodyField, value) != true)) {
                    this.MessageBodyField = value;
                    this.RaisePropertyChanged("MessageBody");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Reciever {
            get {
                return this.RecieverField;
            }
            set {
                if ((object.ReferenceEquals(this.RecieverField, value) != true)) {
                    this.RecieverField = value;
                    this.RaisePropertyChanged("Reciever");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sender {
            get {
                return this.SenderField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderField, value) != true)) {
                    this.SenderField = value;
                    this.RaisePropertyChanged("Sender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Subject {
            get {
                return this.SubjectField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectField, value) != true)) {
                    this.SubjectField = value;
                    this.RaisePropertyChanged("Subject");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MailBoServiceRef.ISignOnService", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ISignOnService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISignOnService/Login", ReplyAction="http://tempuri.org/ISignOnService/LoginResponse")]
        bool Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISignOnService/Login", ReplyAction="http://tempuri.org/ISignOnService/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/ISignOnService/GetNews", ReplyAction="http://tempuri.org/ISignOnService/GetNewsResponse")]
        MailBo.MailBoServiceRef.Message[] GetNews();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/ISignOnService/GetNews", ReplyAction="http://tempuri.org/ISignOnService/GetNewsResponse")]
        System.Threading.Tasks.Task<MailBo.MailBoServiceRef.Message[]> GetNewsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISignOnServiceChannel : MailBo.MailBoServiceRef.ISignOnService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SignOnServiceClient : System.ServiceModel.ClientBase<MailBo.MailBoServiceRef.ISignOnService>, MailBo.MailBoServiceRef.ISignOnService {
        
        public SignOnServiceClient() {
        }
        
        public SignOnServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SignOnServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SignOnServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SignOnServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string username, string password) {
            return base.Channel.LoginAsync(username, password);
        }
        
        public MailBo.MailBoServiceRef.Message[] GetNews() {
            return base.Channel.GetNews();
        }
        
        public System.Threading.Tasks.Task<MailBo.MailBoServiceRef.Message[]> GetNewsAsync() {
            return base.Channel.GetNewsAsync();
        }
    }
}
