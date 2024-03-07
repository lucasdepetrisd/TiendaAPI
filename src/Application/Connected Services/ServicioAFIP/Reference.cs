﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioAFIP
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Autorizacion", Namespace="http://schemas.datacontract.org/2004/07/SGE.Service.Contracts.Data")]
    internal partial class Autorizacion : object
    {
        
        private string ErrorField;
        
        private int PuntoVentaField;
        
        private string TokenField;
        
        private System.DateTime VencimientoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Error
        {
            get
            {
                return this.ErrorField;
            }
            set
            {
                this.ErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int PuntoVenta
        {
            get
            {
                return this.PuntoVentaField;
            }
            set
            {
                this.PuntoVentaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Token
        {
            get
            {
                return this.TokenField;
            }
            set
            {
                this.TokenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal System.DateTime Vencimiento
        {
            get
            {
                return this.VencimientoField;
            }
            set
            {
                this.VencimientoField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UltimoComprobante", Namespace="http://schemas.datacontract.org/2004/07/SGE.Service.Contracts.Data")]
    internal partial class UltimoComprobante : object
    {
        
        private ServicioAFIP.Comprobante[] ComprobantesField;
        
        private string ErrorField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal ServicioAFIP.Comprobante[] Comprobantes
        {
            get
            {
                return this.ComprobantesField;
            }
            set
            {
                this.ComprobantesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Error
        {
            get
            {
                return this.ErrorField;
            }
            set
            {
                this.ErrorField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Comprobante", Namespace="http://schemas.datacontract.org/2004/07/SGE.Service.Contracts.Data")]
    internal partial class Comprobante : object
    {
        
        private string DescripcionField;
        
        private int IdField;
        
        private int NumeroField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Descripcion
        {
            get
            {
                return this.DescripcionField;
            }
            set
            {
                this.DescripcionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal int Numero
        {
            get
            {
                return this.NumeroField;
            }
            set
            {
                this.NumeroField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SolicitudAutorizacion", Namespace="http://schemas.datacontract.org/2004/07/SGE.Service.Contracts.Data")]
    internal partial class SolicitudAutorizacion : object
    {
        
        private System.Nullable<System.DateTime> FechaField;
        
        private double ImporteIvaField;
        
        private double ImporteNetoField;
        
        private double ImporteTotalField;
        
        private long NumeroField;
        
        private long NumeroDocumentoField;
        
        private ServicioAFIP.TipoComprobante TipoComprobanteField;
        
        private ServicioAFIP.TipoDocumento TipoDocumentoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal System.Nullable<System.DateTime> Fecha
        {
            get
            {
                return this.FechaField;
            }
            set
            {
                this.FechaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal double ImporteIva
        {
            get
            {
                return this.ImporteIvaField;
            }
            set
            {
                this.ImporteIvaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal double ImporteNeto
        {
            get
            {
                return this.ImporteNetoField;
            }
            set
            {
                this.ImporteNetoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal double ImporteTotal
        {
            get
            {
                return this.ImporteTotalField;
            }
            set
            {
                this.ImporteTotalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal long Numero
        {
            get
            {
                return this.NumeroField;
            }
            set
            {
                this.NumeroField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal long NumeroDocumento
        {
            get
            {
                return this.NumeroDocumentoField;
            }
            set
            {
                this.NumeroDocumentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal ServicioAFIP.TipoComprobante TipoComprobante
        {
            get
            {
                return this.TipoComprobanteField;
            }
            set
            {
                this.TipoComprobanteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal ServicioAFIP.TipoDocumento TipoDocumento
        {
            get
            {
                return this.TipoDocumentoField;
            }
            set
            {
                this.TipoDocumentoField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoComprobante", Namespace="http://schemas.datacontract.org/2004/07/SGE.Fwk.Domain.Core")]
    internal enum TipoComprobante : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FacturaA = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FacturaB = 6,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoDocumento", Namespace="http://schemas.datacontract.org/2004/07/SGE.Fwk.Domain.Core")]
    internal enum TipoDocumento : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Cuit = 80,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Cuil = 86,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Dni = 96,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ConsumidorFinal = 99,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResultadoSolicitudAutorizacion", Namespace="http://schemas.datacontract.org/2004/07/SGE.Service.Contracts.Data")]
    internal partial class ResultadoSolicitudAutorizacion : object
    {
        
        private string CaeField;
        
        private string ErrorField;
        
        private System.Nullable<ServicioAFIP.EstadoSolicitud> EstadoField;
        
        private string FechaDeVencimientoField;
        
        private string ObservacionField;
        
        private System.Nullable<ServicioAFIP.TipoComprobante> TipoComprobanteField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Cae
        {
            get
            {
                return this.CaeField;
            }
            set
            {
                this.CaeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Error
        {
            get
            {
                return this.ErrorField;
            }
            set
            {
                this.ErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal System.Nullable<ServicioAFIP.EstadoSolicitud> Estado
        {
            get
            {
                return this.EstadoField;
            }
            set
            {
                this.EstadoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string FechaDeVencimiento
        {
            get
            {
                return this.FechaDeVencimientoField;
            }
            set
            {
                this.FechaDeVencimientoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Observacion
        {
            get
            {
                return this.ObservacionField;
            }
            set
            {
                this.ObservacionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal System.Nullable<ServicioAFIP.TipoComprobante> TipoComprobante
        {
            get
            {
                return this.TipoComprobanteField;
            }
            set
            {
                this.TipoComprobanteField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EstadoSolicitud", Namespace="http://schemas.datacontract.org/2004/07/SGE.Fwk.Domain.Core")]
    internal enum EstadoSolicitud : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Aprobada = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Rechazada = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AprobadaParcialmente = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ISTP1.Service.Contracts.Service", ConfigurationName="ServicioAFIP.ILoginService")]
    internal interface ILoginService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ISTP1.Service.Contracts.Service/ILoginService/SolicitarAutorizacion", ReplyAction="http://ISTP1.Service.Contracts.Service/ILoginService/SolicitarAutorizacionRespons" +
            "e")]
        System.Threading.Tasks.Task<ServicioAFIP.Autorizacion> SolicitarAutorizacionAsync(string codigo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ISTP1.Service.Contracts.Service/ILoginService/SolicitarUltimosComprobantes" +
            "", ReplyAction="http://ISTP1.Service.Contracts.Service/ILoginService/SolicitarUltimosComprobantes" +
            "Response")]
        System.Threading.Tasks.Task<ServicioAFIP.UltimoComprobante> SolicitarUltimosComprobantesAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ISTP1.Service.Contracts.Service/ILoginService/SolicitarCae", ReplyAction="http://ISTP1.Service.Contracts.Service/ILoginService/SolicitarCaeResponse")]
        System.Threading.Tasks.Task<ServicioAFIP.ResultadoSolicitudAutorizacion> SolicitarCaeAsync(string token, ServicioAFIP.SolicitudAutorizacion solicitud);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    internal interface ILoginServiceChannel : ServicioAFIP.ILoginService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    internal partial class LoginServiceClient : System.ServiceModel.ClientBase<ServicioAFIP.ILoginService>, ServicioAFIP.ILoginService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public LoginServiceClient() : 
                base(LoginServiceClient.GetDefaultBinding(), LoginServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.SGEAuthService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LoginServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(LoginServiceClient.GetBindingForEndpoint(endpointConfiguration), LoginServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LoginServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(LoginServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LoginServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(LoginServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LoginServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServicioAFIP.Autorizacion> SolicitarAutorizacionAsync(string codigo)
        {
            return base.Channel.SolicitarAutorizacionAsync(codigo);
        }
        
        public System.Threading.Tasks.Task<ServicioAFIP.UltimoComprobante> SolicitarUltimosComprobantesAsync(string token)
        {
            return base.Channel.SolicitarUltimosComprobantesAsync(token);
        }
        
        public System.Threading.Tasks.Task<ServicioAFIP.ResultadoSolicitudAutorizacion> SolicitarCaeAsync(string token, ServicioAFIP.SolicitudAutorizacion solicitud)
        {
            return base.Channel.SolicitarCaeAsync(token, solicitud);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.SGEAuthService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.SGEAuthService))
            {
                return new System.ServiceModel.EndpointAddress("http://istp1service.azurewebsites.net/LoginService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return LoginServiceClient.GetBindingForEndpoint(EndpointConfiguration.SGEAuthService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return LoginServiceClient.GetEndpointAddress(EndpointConfiguration.SGEAuthService);
        }
        
        public enum EndpointConfiguration
        {
            
            SGEAuthService,
        }
    }
}
