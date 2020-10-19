using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.Services;
using VegaHitAutoWebService.Classes;


namespace VegaHitAutoWebService
{
   
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.Web.Services.WebServiceAttribute(Namespace = "http://hitauto.rs")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "VegaServiceV2Soap11Binding",
                                                    Namespace = "http://hitauto.rs")]
    public class VegaServiceV2 : System.Web.Services.WebService
    {


        static string connetion_string = System.Configuration.ConfigurationManager.ConnectionStrings["ICARDMSConnectionString"].ConnectionString;
        static string BIR = "89150020";
        static int no_of_days = 31;

        #region non_transactional_data
        [System.Web.Services.WebMethodAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute(
            "urn:getVersion", RequestNamespace = "http://hitauto.rs",
            ResponseNamespace = "http://hitauto.rs",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public string getVersion()
        {
            return "2.0";
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

        #endregion

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
            try
            {

                if (birNumber != BIR) throw new Exception("Nepostojeci BIR broj");

                DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                string dateFrom = DateTime.UtcNow.ToString("yyyy-MM-dd");
                if (String.IsNullOrEmpty(fromDate)) fromDate = dateFrom;
                if (String.IsNullOrEmpty(toDate)) toDate = dateFrom;


                if (System.Data.Linq.SqlClient.SqlMethods.DateDiffDay(DateTime.Parse(fromDate), DateTime.Parse(toDate)) > no_of_days) throw new Exception("Prevelik vremenski period"); ;

                DataTable data_table_vehicle_data;
                List<VehicleInvoice> vehicleInvoiceList = new List<VehicleInvoice>();

                string query_vehicle_data = @"SELECT _CustomerID	,ErrorCode	,Errortext	,InvoiceAmount	,InvoiceCode	,invoiceDate	,InvoiceID	,invoiceType	,_payer	,_positions	" +
                    ",repairOrderNumber	,requestType	,salesPersionId	,salesPersonName	,Team	,vehicleBatteryBuy	,vehicleBatteryId	" +
                    ",vehicleCommercialType	,vehicleFuelType	,vehicleMake	,vehicleMilage	,vehicleNextCheckDate	,vehicleRegistrationNumber	,vehicleTechnicalType	" +
                    ",vehicleType	,vehicleTypeDescription	,vehicleTypeDescriptionLong	,vehicleVIN	,vehicleYear	,workingArea  " +
                    "FROM [_RI_VEGA_table_UsedVehicleInvoiceData] where invoicedate between @fromDate and @toDate";

                try
                {

                    using (SqlConnection connection = new SqlConnection(connetion_string))
                    using (SqlCommand command = new SqlCommand(query_vehicle_data, connection))
                    {
                        command.Parameters.AddWithValue("@fromDate", fromDate);
                        command.Parameters.AddWithValue("@toDate", toDate);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        data_table_vehicle_data = new DataTable();
                        adapter.Fill(data_table_vehicle_data);
                    }
                }

                catch (Exception)
                {
                    throw;
                }


                foreach (DataRow workOrder in data_table_vehicle_data.Rows)
                {
                    VehicleInvoice vehicleInvoice = new VehicleInvoice();
                    Customer customer = new Customer();
                    Customer payer = new Customer();

                    #region customer


                    string query_customer_data = @"SELECT birthDate  ,City   ,eMAil1 ,eMail2 ,FirstName  ,ID ,lastName   ,marketingComment" +
                    ",marketingEMail ,marketingFax   ,marketingMail  ,marketingPhone ,marketingPreferred ,marketingSMSMMS    ,marketingWelcomeTerminal" +
                    ",mobilePhone1   ,mobilePhone2   ,name   ,Phone1 ,Phone2 ,Sex    ,Street ,TaxNumber  ,TaxPayer   ,useMarketingData   ,ZipCide " +
                    "from [_RI_Vega_table_Customer] where ID = @customer";

                    DataTable data_table_customer_data;

                    try
                    {

                        using (SqlConnection connection = new SqlConnection(connetion_string))
                        using (SqlCommand command = new SqlCommand(query_customer_data, connection))
                        {
                            command.Parameters.AddWithValue("@customer", workOrder["_CustomerID"]);
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            data_table_customer_data = new DataTable();
                            adapter.Fill(data_table_customer_data);
                        }
                    }

                    catch (Exception)
                    {
                        throw;
                    }




                    DataRow customerData = data_table_customer_data.Rows[0];

                    customer.birthDate = customerData["birthDate"].ToString();
                    customer.city = customerData["City"].ToString();
                    customer.eMail1 = customerData["eMAil1"].ToString();
                    customer.eMail2 = customerData["eMail2"].ToString();
                    customer.firstName = customerData["FirstName"].ToString();
                    customer.id = (int)customerData["ID"];
                    customer.lastName = customerData["lastName"].ToString();
                    customer.marketingComment = customerData["marketingComment"].ToString();
                    customer.marketingEMail = customerData["marketingEMail"].ToString();
                    customer.marketingFax = customerData["marketingFax"].ToString();
                    customer.marketingMail = customerData["marketingMail"].ToString();
                    customer.marketingPhone = customerData["marketingPhone"].ToString();
                    customer.marketingPreferred = customerData["marketingPreferred"].ToString();
                    customer.marketingSMSMMS = customerData["marketingSMSMMS"].ToString();
                    customer.marketingWelcomeTerminal = customerData["marketingWelcomeTerminal"].ToString();
                    customer.mobilePhone1 = customerData["mobilePhone1"].ToString();
                    customer.mobilePhone2 = customerData["mobilePhone2"].ToString();
                    customer.name = customerData["name"].ToString();
                    customer.phone1 = customerData["Phone1"].ToString();
                    customer.phone2 = customerData["Phone2"].ToString();
                    customer.sex = customerData["Sex"].ToString();
                    customer.street = customerData["Street"].ToString();
                    customer.taxNumber = customerData["TaxNumber"].ToString();
                    customer.zip = customerData["ZipCide"].ToString();

                    #endregion


                    #region payer


                    string query_payer_data = @"SELECT birthDate  ,City   ,eMAil1 ,eMail2 ,FirstName  ,ID ,lastName   ,marketingComment" +
                    ",marketingEMail ,marketingFax   ,marketingMail  ,marketingPhone ,marketingPreferred ,marketingSMSMMS    ,marketingWelcomeTerminal" +
                    ",mobilePhone1   ,mobilePhone2   ,name   ,Phone1 ,Phone2 ,Sex    ,Street ,TaxNumber  ,TaxPayer   ,useMarketingData   ,ZipCide " +
                    "from [_RI_Vega_table_Customer] where ID = @payer";

                    DataTable data_table_payer_data;

                    try
                    {

                        using (SqlConnection connection = new SqlConnection(connetion_string))
                        using (SqlCommand command = new SqlCommand(query_payer_data, connection))
                        {
                            command.Parameters.AddWithValue("@payer", workOrder["_payer"]);
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            data_table_payer_data = new DataTable();
                            adapter.Fill(data_table_payer_data);
                        }
                    }

                    catch (Exception)
                    {
                        throw;
                    }




                    DataRow payerData = data_table_payer_data.Rows[0];

                    payer.birthDate = payerData["birthDate"].ToString();
                    payer.city = payerData["City"].ToString();
                    payer.eMail1 = payerData["eMAil1"].ToString();
                    payer.eMail2 = payerData["eMail2"].ToString();
                    payer.firstName = payerData["FirstName"].ToString();
                    payer.id = (int)payerData["ID"];
                    payer.lastName = payerData["lastName"].ToString();
                    payer.marketingComment = payerData["marketingComment"].ToString();
                    payer.marketingEMail = payerData["marketingEMail"].ToString();
                    payer.marketingFax = payerData["marketingFax"].ToString();
                    payer.marketingMail = payerData["marketingMail"].ToString();
                    payer.marketingPhone = payerData["marketingPhone"].ToString();
                    payer.marketingPreferred = payerData["marketingPreferred"].ToString();
                    payer.marketingSMSMMS = payerData["marketingSMSMMS"].ToString();
                    payer.marketingWelcomeTerminal = payerData["marketingWelcomeTerminal"].ToString();
                    payer.mobilePhone1 = payerData["mobilePhone1"].ToString();
                    payer.mobilePhone2 = payerData["mobilePhone2"].ToString();
                    payer.name = payerData["name"].ToString();
                    payer.phone1 = payerData["Phone1"].ToString();
                    payer.phone2 = payerData["Phone2"].ToString();
                    payer.sex = payerData["Sex"].ToString();
                    payer.street = payerData["Street"].ToString();
                    payer.taxNumber = payerData["TaxNumber"].ToString();
                    payer.zip = payerData["ZipCide"].ToString();

                    #endregion



                    vehicleInvoice.customer = customer;
                    vehicleInvoice.payer = payer;

                    //vehicleInvoice.payer = workOrder.payer;
                    //vehicleInvoice.problemsLight = workOrder.problemsLight;
                    //vehicleInvoice.problemsSevere = workOrder.problemsSevere;


                    vehicleInvoice.invoiceAmount = (double)workOrder["InvoiceAmount"];
                    vehicleInvoice.invoiceCode = workOrder["InvoiceCode"].ToString();
                    vehicleInvoice.invoiceDate = workOrder["Invoicedate"].ToString();
                    vehicleInvoice.invoiceId = (int)workOrder["InvoiceID"];
                    vehicleInvoice.invoiceType = workOrder["invoiceType"].ToString();


                    vehicleInvoice.repairOrderNumber = (int)workOrder["repairOrderNumber"];
                    vehicleInvoice.requestType = workOrder["requestType"].ToString();
                    vehicleInvoice.salesPersonId = workOrder["salesPersionId"].ToString();
                    vehicleInvoice.salesPersonName = workOrder["salesPersonName"].ToString();
                    vehicleInvoice.team = workOrder["Team"].ToString();
                    vehicleInvoice.vehicleBatteryBuy = workOrder["vehicleBatteryBuy"].ToString();
                    vehicleInvoice.vehicleBatteryId = workOrder["vehicleBatteryId"].ToString();
                    vehicleInvoice.vehicleCommercialType = workOrder["vehicleCommercialType"].ToString();
                    vehicleInvoice.vehicleFuelType = workOrder["vehicleFuelType"].ToString();
                    vehicleInvoice.vehicleMake = workOrder["vehicleMake"].ToString();
                    vehicleInvoice.vehicleMilage = (int)workOrder["vehicleMilage"];
                    vehicleInvoice.vehicleNextCheckDate = workOrder["vehicleNextCheckDate"].ToString();
                    vehicleInvoice.vehicleRegistrationNumber = workOrder["vehicleRegistrationNumber"].ToString();
                    vehicleInvoice.vehicleTechnicalType = workOrder["vehicleTechnicalType"].ToString();
                    vehicleInvoice.vehicleType = workOrder["vehicleType"].ToString();
                    vehicleInvoice.vehicleTypeDescription = workOrder["vehicleTypeDescription"].ToString();
                    vehicleInvoice.vehicleTypeDescriptionLong = workOrder["vehicleTypeDescriptionLong"].ToString();
                    vehicleInvoice.vehicleVIN = workOrder["vehicleVIN"].ToString();
                    vehicleInvoice.vehicleYear = workOrder["vehicleYear"].ToString();
                    vehicleInvoice.workingArea = workOrder["workingArea"].ToString();


                    vehicleInvoiceList.Add(vehicleInvoice);

                }

                return vehicleInvoiceList.ToArray();
            }

            catch (Exception ex)
            {
                VehicleInvoice vehicleInvoice = new VehicleInvoice();
                vehicleInvoice.errorCode = "901";
                if (ex is FormatException) vehicleInvoice.errorText = "Doslo je do greske u formatu datuma";
                else if (ex is System.Data.SqlClient.SqlException) vehicleInvoice.errorText = "Doslo je do greske u sql-u " + ex.Message;
                else vehicleInvoice.errorText = "Opsta greska " + ex.Message;
                VehicleInvoice[] vehicleInvoices = new VehicleInvoice[1];
                vehicleInvoices[0] = vehicleInvoice;
                return vehicleInvoices;
            }
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
            try
            {

                if (birNumber != BIR) throw new Exception("Nepostojeci BIR broj");

                DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                string dateFrom = DateTime.UtcNow.ToString("yyyy-MM-dd");
                if (String.IsNullOrEmpty(fromDate)) fromDate = dateFrom;
                if (String.IsNullOrEmpty(toDate)) toDate = dateFrom;


                if (System.Data.Linq.SqlClient.SqlMethods.DateDiffDay(DateTime.Parse(fromDate), DateTime.Parse(toDate)) > no_of_days) throw new Exception("Prevelik vremenski period"); ;

                DataTable data_table_vehicle_data;
                List<VehicleInvoice> vehicleInvoiceList = new List<VehicleInvoice>();

                string query_vehicle_data = @"SELECT _CustomerID	,ErrorCode	,Errortext	,InvoiceAmount	,InvoiceCode	,invoiceDate	,InvoiceID	,invoiceType	,_payer	,_positions	" +
                    ",repairOrderNumber	,requestType	,salesPersionId	,salesPersonName	,Team	,vehicleBatteryBuy	,vehicleBatteryId	" +
                    ",vehicleCommercialType	,vehicleFuelType	,vehicleMake	,vehicleMilage	,vehicleNextCheckDate	,vehicleRegistrationNumber	,vehicleTechnicalType	" +
                    ",vehicleType	,vehicleTypeDescription	,vehicleTypeDescriptionLong	,vehicleVIN	,vehicleYear	,workingArea  " +
                    "FROM [_RI_VEGA_table_NewVehicleInvoiceData] where invoicedate between @fromDate and @toDate";


                try
                {

                    using (SqlConnection connection = new SqlConnection(connetion_string))
                    using (SqlCommand command = new SqlCommand(query_vehicle_data, connection))
                    {
                        command.Parameters.AddWithValue("@fromDate", fromDate);
                        command.Parameters.AddWithValue("@toDate", toDate);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        data_table_vehicle_data = new DataTable();
                        adapter.Fill(data_table_vehicle_data);
                    }
                }

                catch (Exception)
                {
                    throw;
                }


                foreach (DataRow workOrder in data_table_vehicle_data.Rows)
                {
                    VehicleInvoice vehicleInvoice = new VehicleInvoice();
                    Customer customer = new Customer();
                    Customer payer = new Customer();

                    #region customer


                    string query_customer_data = @"SELECT birthDate  ,City   ,eMAil1 ,eMail2 ,FirstName  ,ID ,lastName   ,marketingComment" +
                    ",marketingEMail ,marketingFax   ,marketingMail  ,marketingPhone ,marketingPreferred ,marketingSMSMMS    ,marketingWelcomeTerminal" +
                    ",mobilePhone1   ,mobilePhone2   ,name   ,Phone1 ,Phone2 ,Sex    ,Street ,TaxNumber  ,TaxPayer   ,useMarketingData   ,ZipCide " +
                    "from [_RI_Vega_table_Customer] where ID = @customer";

                    DataTable data_table_customer_data;

                    try
                    {

                        using (SqlConnection connection = new SqlConnection(connetion_string))
                        using (SqlCommand command = new SqlCommand(query_customer_data, connection))
                        {
                            command.Parameters.AddWithValue("@customer", workOrder["_CustomerID"]);
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            data_table_customer_data = new DataTable();
                            adapter.Fill(data_table_customer_data);
                        }
                    }

                    catch (Exception)
                    {
                        throw;
                    }




                    DataRow customerData = data_table_customer_data.Rows[0];

                    customer.birthDate = customerData["birthDate"].ToString();
                    customer.city = customerData["City"].ToString();
                    customer.eMail1 = customerData["eMAil1"].ToString();
                    customer.eMail2 = customerData["eMail2"].ToString();
                    customer.firstName = customerData["FirstName"].ToString();
                    customer.id = (int)customerData["ID"];
                    customer.lastName = customerData["lastName"].ToString();
                    customer.marketingComment = customerData["marketingComment"].ToString();
                    customer.marketingEMail = customerData["marketingEMail"].ToString();
                    customer.marketingFax = customerData["marketingFax"].ToString();
                    customer.marketingMail = customerData["marketingMail"].ToString();
                    customer.marketingPhone = customerData["marketingPhone"].ToString();
                    customer.marketingPreferred = customerData["marketingPreferred"].ToString();
                    customer.marketingSMSMMS = customerData["marketingSMSMMS"].ToString();
                    customer.marketingWelcomeTerminal = customerData["marketingWelcomeTerminal"].ToString();
                    customer.mobilePhone1 = customerData["mobilePhone1"].ToString();
                    customer.mobilePhone2 = customerData["mobilePhone2"].ToString();
                    customer.name = customerData["name"].ToString();
                    customer.phone1 = customerData["Phone1"].ToString();
                    customer.phone2 = customerData["Phone2"].ToString();
                    customer.sex = customerData["Sex"].ToString();
                    customer.street = customerData["Street"].ToString();
                    customer.taxNumber = customerData["TaxNumber"].ToString();
                    customer.zip = customerData["ZipCide"].ToString();

                    #endregion


                    #region payer


                    string query_payer_data = @"SELECT birthDate  ,City   ,eMAil1 ,eMail2 ,FirstName  ,ID ,lastName   ,marketingComment" +
                    ",marketingEMail ,marketingFax   ,marketingMail  ,marketingPhone ,marketingPreferred ,marketingSMSMMS    ,marketingWelcomeTerminal" +
                    ",mobilePhone1   ,mobilePhone2   ,name   ,Phone1 ,Phone2 ,Sex    ,Street ,TaxNumber  ,TaxPayer   ,useMarketingData   ,ZipCide " +
                    "from [_RI_Vega_table_Customer] where ID = @payer";

                    DataTable data_table_payer_data;

                    try
                    {

                        using (SqlConnection connection = new SqlConnection(connetion_string))
                        using (SqlCommand command = new SqlCommand(query_payer_data, connection))
                        {
                            command.Parameters.AddWithValue("@payer", workOrder["_payer"]);
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            data_table_payer_data = new DataTable();
                            adapter.Fill(data_table_payer_data);
                        }
                    }

                    catch (Exception)
                    {
                        throw;
                    }




                    DataRow payerData = data_table_payer_data.Rows[0];

                    payer.birthDate = payerData["birthDate"].ToString();
                    payer.city = payerData["City"].ToString();
                    payer.eMail1 = payerData["eMAil1"].ToString();
                    payer.eMail2 = payerData["eMail2"].ToString();
                    payer.firstName = payerData["FirstName"].ToString();
                    payer.id = (int)payerData["ID"];
                    payer.lastName = payerData["lastName"].ToString();
                    payer.marketingComment = payerData["marketingComment"].ToString();
                    payer.marketingEMail = payerData["marketingEMail"].ToString();
                    payer.marketingFax = payerData["marketingFax"].ToString();
                    payer.marketingMail = payerData["marketingMail"].ToString();
                    payer.marketingPhone = payerData["marketingPhone"].ToString();
                    payer.marketingPreferred = payerData["marketingPreferred"].ToString();
                    payer.marketingSMSMMS = payerData["marketingSMSMMS"].ToString();
                    payer.marketingWelcomeTerminal = payerData["marketingWelcomeTerminal"].ToString();
                    payer.mobilePhone1 = payerData["mobilePhone1"].ToString();
                    payer.mobilePhone2 = payerData["mobilePhone2"].ToString();
                    payer.name = payerData["name"].ToString();
                    payer.phone1 = payerData["Phone1"].ToString();
                    payer.phone2 = payerData["Phone2"].ToString();
                    payer.sex = payerData["Sex"].ToString();
                    payer.street = payerData["Street"].ToString();
                    payer.taxNumber = payerData["TaxNumber"].ToString();
                    payer.zip = payerData["ZipCide"].ToString();

                    #endregion



                    vehicleInvoice.customer = customer;
                    vehicleInvoice.payer = payer;
                 
                    //vehicleInvoice.payer = workOrder.payer;
                    //vehicleInvoice.problemsLight = workOrder.problemsLight;
                    //vehicleInvoice.problemsSevere = workOrder.problemsSevere;


                    vehicleInvoice.invoiceAmount = (double)workOrder["InvoiceAmount"];
                    vehicleInvoice.invoiceCode = workOrder["InvoiceCode"].ToString();
                    vehicleInvoice.invoiceDate = workOrder["Invoicedate"].ToString();
                    vehicleInvoice.invoiceId = (int)workOrder["InvoiceID"];
                    vehicleInvoice.invoiceType = workOrder["invoiceType"].ToString();


                    vehicleInvoice.repairOrderNumber = (int)workOrder["repairOrderNumber"];
                    vehicleInvoice.requestType = workOrder["requestType"].ToString();
                    vehicleInvoice.salesPersonId = workOrder["salesPersionId"].ToString();
                    vehicleInvoice.salesPersonName = workOrder["salesPersonName"].ToString();
                    vehicleInvoice.team = workOrder["Team"].ToString();
                    vehicleInvoice.vehicleBatteryBuy = workOrder["vehicleBatteryBuy"].ToString();
                    vehicleInvoice.vehicleBatteryId = workOrder["vehicleBatteryId"].ToString();
                    vehicleInvoice.vehicleCommercialType = workOrder["vehicleCommercialType"].ToString();
                    vehicleInvoice.vehicleFuelType = workOrder["vehicleFuelType"].ToString();
                    vehicleInvoice.vehicleMake = workOrder["vehicleMake"].ToString();
                    vehicleInvoice.vehicleMilage = (int)workOrder["vehicleMilage"];
                    vehicleInvoice.vehicleNextCheckDate = workOrder["vehicleNextCheckDate"].ToString();
                    vehicleInvoice.vehicleRegistrationNumber = workOrder["vehicleRegistrationNumber"].ToString();
                    vehicleInvoice.vehicleTechnicalType = workOrder["vehicleTechnicalType"].ToString();
                    vehicleInvoice.vehicleType = workOrder["vehicleType"].ToString();
                    vehicleInvoice.vehicleTypeDescription = workOrder["vehicleTypeDescription"].ToString();
                    vehicleInvoice.vehicleTypeDescriptionLong = workOrder["vehicleTypeDescriptionLong"].ToString();
                    vehicleInvoice.vehicleVIN = workOrder["vehicleVIN"].ToString();
                    vehicleInvoice.vehicleYear = workOrder["vehicleYear"].ToString();
                    vehicleInvoice.workingArea = workOrder["workingArea"].ToString();


                    vehicleInvoiceList.Add(vehicleInvoice);

                }

                return vehicleInvoiceList.ToArray();
            }

            catch (Exception ex)
            {
                VehicleInvoice vehicleInvoice = new VehicleInvoice();
                vehicleInvoice.errorCode = "901";
                if (ex is FormatException) vehicleInvoice.errorText = "Doslo je do greske u formatu datuma";
                else if (ex is System.Data.SqlClient.SqlException) vehicleInvoice.errorText = "Doslo je do greske u sql-u " + ex.Message;
                else vehicleInvoice.errorText = "Opsta greska " + ex.Message;
                VehicleInvoice[] vehicleInvoices = new VehicleInvoice[1];
                vehicleInvoices[0] = vehicleInvoice;
                return vehicleInvoices;
            }
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

                if (birNumber != BIR) throw new Exception("Nepostojeci BIR broj");

                DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                string dateFrom = DateTime.UtcNow.ToString("yyyy-MM-dd");
                if (String.IsNullOrEmpty(fromDate)) fromDate = dateFrom;
                if (String.IsNullOrEmpty(toDate)) toDate = dateFrom;


                if (System.Data.Linq.SqlClient.SqlMethods.DateDiffDay(DateTime.Parse(fromDate), DateTime.Parse(toDate)) > no_of_days) throw new Exception("Prevelik vremenski period"); ;

                DataTable data_table_vehicle_data;
                List<VehicleInvoice> vehicleInvoiceList = new List<VehicleInvoice>();

                string query_vehicle_data = @"SELECT _CustomerID	,ErrorCode	,Errortext	,InvoiceAmount	,InvoiceCode	,invoiceDate	,InvoiceID	,Inovicetype	,_payer	,_positions	" +
                    ",problemsLight	,problemsSevere	,repairOrderNumber	,requestType	,salesPersionId	,salesPersonName	,Team	,vehicleBatteryBuy	,vehicleBatteryId	" +
                    ",vehicleCommercialType	,vehicleFuelType	,vehicleMake	,vehicleMilage	,vehicleNextCheckDate	,vehicleRegistrationNumber	,vehicleTechnicalType	" +
                    ",vehicleType	,vehicleTypeDescription	,vehicleTypeDescriptionLong	,vehicleVIN	,vehicleYear	,workingArea	,numinterno  " +
                    "FROM [_RI_Vega_table_VehicleData] where invoicedate between @fromDate and @toDate";


                try
                {
        
                    using (SqlConnection connection = new SqlConnection(connetion_string))
                    using (SqlCommand command = new SqlCommand(query_vehicle_data, connection))
                    {
                        command.Parameters.AddWithValue("@fromDate", fromDate);
                        command.Parameters.AddWithValue("@toDate", toDate);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        data_table_vehicle_data = new DataTable();
                        adapter.Fill(data_table_vehicle_data);
                    }
                }

                catch (Exception)
                {
                    throw;
                }


                foreach (DataRow workOrder in data_table_vehicle_data.Rows)
                {
                    VehicleInvoice vehicleInvoice = new VehicleInvoice();
                    Customer customer = new Customer();
                    Customer payer = new Customer();
                    List<Position> positions = new List<Position>();


                    #region customer


                    string query_customer_data = @"SELECT birthDate  ,City   ,eMAil1 ,eMail2 ,FirstName  ,ID ,lastName   ,marketingComment" +
                    ",marketingEMail ,marketingFax   ,marketingMail  ,marketingPhone ,marketingPreferred ,marketingSMSMMS    ,marketingWelcomeTerminal" +   
                    ",mobilePhone1   ,mobilePhone2   ,name   ,Phone1 ,Phone2 ,Sex    ,Street ,TaxNumber  ,TaxPayer   ,useMarketingData   ,ZipCide " +
                    "from [_RI_Vega_table_Customer] where ID = @customer";

                    DataTable data_table_customer_data;

                    try
                    {

                        using (SqlConnection connection = new SqlConnection(connetion_string))
                        using (SqlCommand command = new SqlCommand(query_customer_data, connection))
                        {
                            command.Parameters.AddWithValue("@customer", workOrder["_CustomerID"]);
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            data_table_customer_data = new DataTable();
                            adapter.Fill(data_table_customer_data);
                        }
                    }

                    catch (Exception)
                    {
                        throw;
                    }




                    DataRow customerData = data_table_customer_data.Rows[0];

                    customer.birthDate = customerData["birthDate"].ToString();
                    customer.city = customerData["City"].ToString();
                    customer.eMail1 = customerData["eMAil1"].ToString();
                    customer.eMail2 = customerData["eMail2"].ToString();
                    customer.firstName = customerData["FirstName"].ToString();
                    customer.id = (int)customerData["ID"];
                    customer.lastName = customerData["lastName"].ToString();
                    customer.marketingComment = customerData["marketingComment"].ToString();
                    customer.marketingEMail = customerData["marketingEMail"].ToString();
                    customer.marketingFax = customerData["marketingFax"].ToString();
                    customer.marketingMail = customerData["marketingMail"].ToString();
                    customer.marketingPhone = customerData["marketingPhone"].ToString();
                    customer.marketingPreferred = customerData["marketingPreferred"].ToString();
                    customer.marketingSMSMMS = customerData["marketingSMSMMS"].ToString();
                    customer.marketingWelcomeTerminal = customerData["marketingWelcomeTerminal"].ToString();
                    customer.mobilePhone1 = customerData["mobilePhone1"].ToString();
                    customer.mobilePhone2 = customerData["mobilePhone2"].ToString();
                    customer.name = customerData["name"].ToString();
                    customer.phone1 = customerData["Phone1"].ToString();
                    customer.phone2 = customerData["Phone2"].ToString();
                    customer.sex = customerData["Sex"].ToString();
                    customer.street = customerData["Street"].ToString();
                    customer.taxNumber = customerData["TaxNumber"].ToString();
                    customer.zip = customerData["ZipCide"].ToString();

                    #endregion


                    #region payer


                    string query_payer_data = @"SELECT birthDate  ,City   ,eMAil1 ,eMail2 ,FirstName  ,ID ,lastName   ,marketingComment" +
                    ",marketingEMail ,marketingFax   ,marketingMail  ,marketingPhone ,marketingPreferred ,marketingSMSMMS    ,marketingWelcomeTerminal" +
                    ",mobilePhone1   ,mobilePhone2   ,name   ,Phone1 ,Phone2 ,Sex    ,Street ,TaxNumber  ,TaxPayer   ,useMarketingData   ,ZipCide " +
                    "from [_RI_Vega_table_Customer] where ID = @payer";

                    DataTable data_table_payer_data;

                    try
                    {

                        using (SqlConnection connection = new SqlConnection(connetion_string))
                        using (SqlCommand command = new SqlCommand(query_payer_data, connection))
                        {
                            command.Parameters.AddWithValue("@payer", workOrder["_payer"]);
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            data_table_payer_data = new DataTable();
                            adapter.Fill(data_table_payer_data);
                        }
                    }

                    catch (Exception)
                    {
                        throw;
                    }




                    DataRow payerData = data_table_payer_data.Rows[0];

                    payer.birthDate = payerData["birthDate"].ToString();
                    payer.city = payerData["City"].ToString();
                    payer.eMail1 = payerData["eMAil1"].ToString();
                    payer.eMail2 = payerData["eMail2"].ToString();
                    payer.firstName = payerData["FirstName"].ToString();
                    payer.id = (int)payerData["ID"];
                    payer.lastName = payerData["lastName"].ToString();
                    payer.marketingComment = payerData["marketingComment"].ToString();
                    payer.marketingEMail = payerData["marketingEMail"].ToString();
                    payer.marketingFax = payerData["marketingFax"].ToString();
                    payer.marketingMail = payerData["marketingMail"].ToString();
                    payer.marketingPhone = payerData["marketingPhone"].ToString();
                    payer.marketingPreferred = payerData["marketingPreferred"].ToString();
                    payer.marketingSMSMMS = payerData["marketingSMSMMS"].ToString();
                    payer.marketingWelcomeTerminal = payerData["marketingWelcomeTerminal"].ToString();
                    payer.mobilePhone1 = payerData["mobilePhone1"].ToString();
                    payer.mobilePhone2 = payerData["mobilePhone2"].ToString();
                    payer.name = payerData["name"].ToString();
                    payer.phone1 = payerData["Phone1"].ToString();
                    payer.phone2 = payerData["Phone2"].ToString();
                    payer.sex = payerData["Sex"].ToString();
                    payer.street = payerData["Street"].ToString();
                    payer.taxNumber = payerData["TaxNumber"].ToString();
                    payer.zip = payerData["ZipCide"].ToString();

                    #endregion


                    #region positions

                    string query_positions_data = @"SELECT numintOt,Code,Description,labourTime,labourTimeType,partFamily,price,priceFinal,Type " +
                    "from [_RI_Vega_table_Positions] where numintOt = @positions";

                    DataTable data_table_positions_data;

                    try
                    {

                        using (SqlConnection connection = new SqlConnection(connetion_string))
                        using (SqlCommand command = new SqlCommand(query_positions_data, connection))
                        {
                            command.Parameters.AddWithValue("@positions", workOrder["_positions"]);
                            SqlDataAdapter adapter = new SqlDataAdapter(command);

                            data_table_positions_data = new DataTable();
                            adapter.Fill(data_table_positions_data);
                        }
                    }

                    catch (Exception)
                    {
                        throw;
                    }



                    foreach (DataRow workOrderPosition in data_table_positions_data.Rows)
                    {
                        Position position = new Position();
                        position.code = workOrderPosition["Code"].ToString();
                        position.descirption = workOrderPosition["Description"].ToString();
                        position.labourTime = (double)workOrderPosition["labourTime"];
                        position.partFamily = workOrderPosition["partFamily"].ToString();
                        position.price = (double)workOrderPosition["price"];
                        position.type = workOrderPosition["Type"].ToString();
                        positions.Add(position);

                    }

                    #endregion


                    vehicleInvoice.customer = customer; 
                    vehicleInvoice.payer = payer;
                    vehicleInvoice.positions = positions.ToArray();
                    //vehicleInvoice.payer = workOrder.payer;
                    //vehicleInvoice.problemsLight = workOrder.problemsLight;
                    //vehicleInvoice.problemsSevere = workOrder.problemsSevere;


                    vehicleInvoice.invoiceAmount =(double)workOrder["InvoiceAmount"];
                    vehicleInvoice.invoiceCode = workOrder["InvoiceCode"].ToString();
                    vehicleInvoice.invoiceDate = workOrder["Invoicedate"].ToString();
                    vehicleInvoice.invoiceId = (int)workOrder["InvoiceID"];
                    vehicleInvoice.invoiceType = workOrder["Inovicetype"].ToString();


                    vehicleInvoice.repairOrderNumber = (int)workOrder["repairOrderNumber"];
                    vehicleInvoice.requestType = workOrder["requestType"].ToString();
                    vehicleInvoice.salesPersonId = workOrder["salesPersionId"].ToString();
                    vehicleInvoice.salesPersonName = workOrder["salesPersonName"].ToString();
                    vehicleInvoice.team = workOrder["Team"].ToString();
                    vehicleInvoice.vehicleBatteryBuy = workOrder["vehicleBatteryBuy"].ToString();
                    vehicleInvoice.vehicleBatteryId = workOrder["vehicleBatteryId"].ToString();
                    vehicleInvoice.vehicleCommercialType = workOrder["vehicleCommercialType"].ToString();
                    vehicleInvoice.vehicleFuelType = workOrder["vehicleFuelType"].ToString();
                    vehicleInvoice.vehicleMake = workOrder["vehicleMake"].ToString();
                    vehicleInvoice.vehicleMilage = (int)workOrder["vehicleMilage"];
                    vehicleInvoice.vehicleNextCheckDate = workOrder["vehicleNextCheckDate"].ToString();
                    vehicleInvoice.vehicleRegistrationNumber = workOrder["vehicleRegistrationNumber"].ToString();
                    vehicleInvoice.vehicleTechnicalType = workOrder["vehicleTechnicalType"].ToString();
                    vehicleInvoice.vehicleType = workOrder["vehicleType"].ToString();
                    vehicleInvoice.vehicleTypeDescription = workOrder["vehicleTypeDescription"].ToString();
                    vehicleInvoice.vehicleTypeDescriptionLong = workOrder["vehicleTypeDescriptionLong"].ToString();
                    vehicleInvoice.vehicleVIN = workOrder["vehicleVIN"].ToString();
                    vehicleInvoice.vehicleYear = workOrder["vehicleYear"].ToString();
                    vehicleInvoice.workingArea = workOrder["workingArea"].ToString();


                    vehicleInvoiceList.Add(vehicleInvoice);

                }

                return vehicleInvoiceList.ToArray();
            }
            
            catch(Exception ex)
            {
                VehicleInvoice vehicleInvoice = new VehicleInvoice();
                vehicleInvoice.errorCode = "901";
                if(ex is FormatException) vehicleInvoice.errorText = "Doslo je do greske u formatu datuma";
                else if (ex is System.Data.SqlClient.SqlException) vehicleInvoice.errorText = "Doslo je do greske u sql-u " + ex.Message;
                else vehicleInvoice.errorText = "Opsta greska " + ex.Message;
                VehicleInvoice[] vehicleInvoices = new VehicleInvoice[1];
                vehicleInvoices[0] = vehicleInvoice;
                return vehicleInvoices;
            }
         
        }
    }

}
