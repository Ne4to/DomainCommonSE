﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceConfig.WCFLockService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ObjectIdentifier", Namespace="http://schemas.datacontract.org/2004/07/EntityObjectORM")]
    [System.SerializableAttribute()]
    public partial class ObjectIdentifier : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
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
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TryLockResult", Namespace="http://schemas.datacontract.org/2004/07/WCFLockService")]
    [System.SerializableAttribute()]
    public partial class TryLockResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndLockTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccessfulField;
        
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
        public System.DateTime EndLockTime {
            get {
                return this.EndLockTimeField;
            }
            set {
                if ((this.EndLockTimeField.Equals(value) != true)) {
                    this.EndLockTimeField = value;
                    this.RaisePropertyChanged("EndLockTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Successful {
            get {
                return this.SuccessfulField;
            }
            set {
                if ((this.SuccessfulField.Equals(value) != true)) {
                    this.SuccessfulField = value;
                    this.RaisePropertyChanged("Successful");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFLockService.ILockService", CallbackContract=typeof(ServiceConfig.WCFLockService.ILockServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ILockService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILockService/DoWork", ReplyAction="http://tempuri.org/ILockService/DoWorkResponse")]
        string DoWork(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILockService/TryLock", ReplyAction="http://tempuri.org/ILockService/TryLockResponse")]
        ServiceConfig.WCFLockService.TryLockResult TryLock(ServiceConfig.WCFLockService.ObjectIdentifier objectId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILockServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ILockService/LockIsAvailable")]
        void LockIsAvailable(ServiceConfig.WCFLockService.ObjectIdentifier objectId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILockServiceChannel : ServiceConfig.WCFLockService.ILockService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LockServiceClient : System.ServiceModel.DuplexClientBase<ServiceConfig.WCFLockService.ILockService>, ServiceConfig.WCFLockService.ILockService {
        
        public LockServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public LockServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public LockServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LockServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public LockServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public string DoWork(string value) {
            return base.Channel.DoWork(value);
        }
        
        public ServiceConfig.WCFLockService.TryLockResult TryLock(ServiceConfig.WCFLockService.ObjectIdentifier objectId) {
            return base.Channel.TryLock(objectId);
        }
    }
}