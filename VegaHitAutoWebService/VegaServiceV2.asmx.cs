using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VegaHitAutoWebService.Classes;
using VegaHitAutoWebService.LinqClasses;

namespace VegaHitAutoWebService
{
   
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Web.Services.WebServiceAttribute(Namespace = "http://hitauto.rs")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "VegaServiceV2Soap11Binding",
                                                    Namespace = "http://hitauto.rs")]
    public class VegaServiceV2 : System.Web.Services.WebService
    {


        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
            "urn:getUsedAndCommissionVehicles",
            RequestNamespace = "http://hitauto.rs",
            ResponseNamespace = "http://hitauto.rs",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(
            "return" , IsNullable = true)]
        public VehicleInvoice[] getUsedAndCommissionVehicles(
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
        public UserInfo checkBIRNumber(
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
        public string getVersion()
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
        public VehicleInvoice[] getNewVehicles(
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
        public UserInfo[] checkBIRNumbers(
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string birSearchString)
        {
            return new UserInfo[0];
        }


        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
            "urn:getWorkOrders", 
            RequestNamespace = "http://hitauto.rs", 
            ResponseNamespace = "http://hitauto.rs", 
            Use = System.Web.Services.Description.SoapBindingUse.Literal, 
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
            [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public VehicleInvoice[] getWorkOrders(
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string birNumber,
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string fromDate,
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string toDate)
        {

            try
            {
                List<VehicleInvoice> vehicleInvoiceList = new List<VehicleInvoice>();
                VehicleInvoiceDataContext vehicleInvoiceContext = new VehicleInvoiceDataContext();
                CustomerDataContext customerContext = new CustomerDataContext();
                PositionDataContext positionDataContext = new PositionDataContext();


                var st = System.Configuration.ConfigurationManager.ConnectionStrings["ICARDMSConnectionString"].ConnectionString;

                var workOrders = (from _RI_Vega_VehicleData in vehicleInvoiceContext._RI_Vega_VehicleDatas
               
                                  select _RI_Vega_VehicleData)
                          
                                ;

                foreach (var workOrder in workOrders)
                {
                    VehicleInvoice vehicleInvoice = new VehicleInvoice();
                    Customer customer = new Customer();
                    List<Position> positions = new List<Position>();

                    var customerData = (from _RI_Vega_Customer in customerContext._RI_Vega_Customers
                                        where _RI_Vega_Customer.ID == workOrder._payer
                                        select _RI_Vega_Customer).FirstOrDefault();

                    customer.birthDate = customerData.birthDate.ToString();
                    customer.city = customerData.City;
                    customer.eMail1 = customerData.eMAil1;
                    customer.eMail2 = customerData.eMail2;
                    customer.firstName = customerData.FirstName;
                    customer.id = (int)customerData.ID;
                    customer.lastName = customerData.lastName;
                    customer.marketingComment = customerData.marketingComment;
                    customer.marketingEMail = customerData.marketingEMail;
                    customer.marketingFax = customerData.marketingFax;
                    customer.marketingMail = customerData.marketingMail;
                    customer.marketingPhone = customerData.marketingPhone;
                    customer.marketingPreferred = customerData.marketingPreferred;
                    customer.marketingSMSMMS = customerData.marketingSMSMMS.ToString();
                    customer.marketingWelcomeTerminal = customerData.marketingWelcomeTerminal;
                    customer.mobilePhone1 = customerData.mobilePhone1;
                    customer.mobilePhone2 = customerData.mobilePhone2;
                    customer.name = customerData.name;
                    customer.phone1 = customerData.Phone1;
                    customer.phone2 = customerData.Phone2;
                    customer.sex = customerData.Sex.ToString();
                    customer.street = customerData.Street;
                    customer.taxNumber = customerData.TaxNumber;
                   // customer.taxPayer = customerData.TaxPayer;
                   // customer.useMaketingData = customerData.marketing;
                    customer.zip = customerData.ZipCide;



                    var workOrderPositions = (from _RI_Vega_Position in positionDataContext._RI_Vega_Positions
                                              where _RI_Vega_Position.numintOt == workOrder._positions
                                              select _RI_Vega_Position);

                    foreach (var workOrderPosition in workOrderPositions)
                    {
                        Position position = new Position();
                        position.code = workOrderPosition.Code;
                        position.descirption = workOrderPosition.Description;
                      //  position.labourTime = (double)workOrderPosition.labourTime;
                        position.partFamily = workOrderPosition.partFamily.ToString();
                     //   position.price = (double)workOrderPosition.price;
                        position.type = workOrderPosition.Type;
                        positions.Add(position);

                    }




                    vehicleInvoice.customer = customer;
                    vehicleInvoice.positions = positions.ToArray();
                    //vehicleInvoice.payer = workOrder.payer;
                    //vehicleInvoice.problemsLight = workOrder.problemsLight;
                    //vehicleInvoice.problemsSevere = workOrder.problemsSevere;


               //     vehicleInvoice.invoiceAmount =(double)workOrder.InvoiceAmount;
                    vehicleInvoice.invoiceCode = workOrder.InvoiceCode;
                    vehicleInvoice.invoiceDate = workOrder.Invoicedate.ToString();
                    vehicleInvoice.invoiceId = (int)workOrder.InvoiceID;
                    vehicleInvoice.invoiceType = workOrder.Inovicetype;
            
                    vehicleInvoice.repairOrderNumber = (int)workOrder.repairOrderNumber;
                    vehicleInvoice.requestType = workOrder.requestType;
                    vehicleInvoice.salesPersonId = workOrder.salesPersionId;
                    vehicleInvoice.salesPersonName = workOrder.salesPersonName;
                    vehicleInvoice.team = workOrder.Team;
                    vehicleInvoice.vehicleBatteryBuy = workOrder.vehicleBatteryBuy;
                    vehicleInvoice.vehicleBatteryId = workOrder.vehicleBatteryId;
                    vehicleInvoice.vehicleCommercialType = workOrder.vehicleCommercialType;
                    vehicleInvoice.vehicleFuelType = workOrder.vehicleFuelType;
                    vehicleInvoice.vehicleMake = workOrder.vehicleMake;
                    vehicleInvoice.vehicleMilage = (int)workOrder.vehicleMilage;
                    vehicleInvoice.vehicleNextCheckDate = workOrder.vehicleNextCheckDate;
                    vehicleInvoice.vehicleRegistrationNumber = workOrder.vehicleRegistrationNumber;
                    vehicleInvoice.vehicleTechnicalType = workOrder.vehicleTechnicalType;
                    vehicleInvoice.vehicleType = workOrder.vehicleType;
                    vehicleInvoice.vehicleTypeDescription = workOrder.vehicleTypeDescription;
                    vehicleInvoice.vehicleTypeDescriptionLong = workOrder.vehicleTypeDescriptionLong;
                    vehicleInvoice.vehicleVIN = workOrder.vehicleVIN;
                    vehicleInvoice.vehicleYear = workOrder.vehicleYear.ToString();
                    vehicleInvoice.workingArea = workOrder.workingArea;








                    vehicleInvoiceList.Add(vehicleInvoice);


                }



                return vehicleInvoiceList.ToArray();
            }
            
            catch(Exception ex)
            {
                VehicleInvoice vehicleInvoice = new VehicleInvoice();
                vehicleInvoice.errorCode = "901";
                if(ex is FormatException) vehicleInvoice.errorText = "Doslo je do greske u formatu";
                else if(ex is System.Data.SqlClient.SqlException) vehicleInvoice.errorText = "Greska u povezivanju na sql " + ex.Message ;
                else vehicleInvoice.errorText = "Opsta greska " + ex.Message;
                VehicleInvoice[] vehicleInvoices = new VehicleInvoice[1];
                vehicleInvoices[0] = vehicleInvoice;
                return vehicleInvoices;
            }
         
        }

        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
                "urn:getAllBlockedCustomers",
                RequestNamespace = "http://hitauto.rs",
                ResponseNamespace = "http://hitauto.rs",
                Use = System.Web.Services.Description.SoapBindingUse.Literal,
                ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public Customer[] getAllBlockedCustomers(
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string birNumber)
        {
            return new Customer[0];
        }
    }

}
