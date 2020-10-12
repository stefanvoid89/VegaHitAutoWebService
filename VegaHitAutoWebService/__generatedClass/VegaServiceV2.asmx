using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VegaHitAutoWebService.Classes
{
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Web.Services.WebServiceAttribute(Namespace = "http://hitauto.rs")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "VegaServiceV2Soap11Binding", 
                                                    Namespace = "http://hitauto.rs")]
    public  class VegaServiceV2 : System.Web.Services.WebService
    {

       
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
            "urn:getUsedAndCommissionVehicles", 
            RequestNamespace = "http://hitauto.rs", 
            ResponseNamespace = "http://hitauto.rs", 
            Use = System.Web.Services.Description.SoapBindingUse.Literal, 
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public  VehicleInvoice[] getUsedAndCommissionVehicles(
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string birNumber, 
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string fromDate, 
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string toDate)
        {
            return new VehicleInvoice[0];
        }

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
            "urn:checkBIRNumber", 
            RequestNamespace = "http://hitauto.rs", 
            ResponseNamespace = "http://hitauto.rs", 
            Use = System.Web.Services.Description.SoapBindingUse.Literal, 
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public  UserInfo checkBIRNumber(
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string birNumber)
        {
            return new UserInfo();
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
            "urn:getVersion", RequestNamespace = "http://hitauto.rs", 
            ResponseNamespace = "http://hitauto.rs", 
            Use = System.Web.Services.Description.SoapBindingUse.Literal, 
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public  string getVersion()
        {
            return "";
        }

 
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
            "urn:getNewVehicles", RequestNamespace = "http://hitauto.rs", 
            ResponseNamespace = "http://hitauto.rs", 
            Use = System.Web.Services.Description.SoapBindingUse.Literal, 
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public  VehicleInvoice[] getNewVehicles(
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string birNumber, 
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string fromDate, 
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string toDate)

         {
            return new VehicleInvoice[0];
        }

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
            "urn:checkBIRNumbers", 
            RequestNamespace = "http://hitauto.rs", 
            ResponseNamespace = "http://hitauto.rs", 
            Use = System.Web.Services.Description.SoapBindingUse.Literal, 
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public  UserInfo[] checkBIRNumbers(
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string birSearchString)
        {
            return new UserInfo[0];
        }

       
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:getWorkOrders", RequestNamespace = "http://hitauto.rs", ResponseNamespace = "http://hitauto.rs", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public  VehicleInvoice[] getWorkOrders(
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string birNumber, 
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string fromDate, 
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string toDate)
         {
            return new VehicleInvoice[0];
        }

    [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
            "urn:getAllBlockedCustomers", 
            RequestNamespace = "http://hitauto.rs", 
            ResponseNamespace = "http://hitauto.rs", 
            Use = System.Web.Services.Description.SoapBindingUse.Literal, 
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public  Customer[] getAllBlockedCustomers(
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string birNumber)
        {
            return new Customer[0];
        }
    }

}