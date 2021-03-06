﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logic.DataBaseWCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DataBaseWCF.IDBService")]
    public interface IDBService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBService/UpdateListPlane", ReplyAction="http://tempuri.org/IDBService/UpdateListPlaneResponse")]
        void UpdateListPlane(ContractsServer.Models.StationModel[] listPlanes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDBService/UpdateListPlane", ReplyAction="http://tempuri.org/IDBService/UpdateListPlaneResponse")]
        System.Threading.Tasks.Task UpdateListPlaneAsync(ContractsServer.Models.StationModel[] listPlanes);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDBServiceChannel : Logic.DataBaseWCF.IDBService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DBServiceClient : System.ServiceModel.ClientBase<Logic.DataBaseWCF.IDBService>, Logic.DataBaseWCF.IDBService {
        
        public DBServiceClient() {
        }
        
        public DBServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DBServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DBServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DBServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void UpdateListPlane(ContractsServer.Models.StationModel[] listPlanes) {
            base.Channel.UpdateListPlane(listPlanes);
        }
        
        public System.Threading.Tasks.Task UpdateListPlaneAsync(ContractsServer.Models.StationModel[] listPlanes) {
            return base.Channel.UpdateListPlaneAsync(listPlanes);
        }
    }
}
