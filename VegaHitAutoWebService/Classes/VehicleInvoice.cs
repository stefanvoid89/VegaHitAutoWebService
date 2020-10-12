using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VegaHitAutoWebService.Classes
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://hitauto.rs/vehInv")]
    
    public partial class VehicleInvoice
    {
        
        private Customer customerField;

        private string errorCodeField;

        private string errorTextField;

        private double invoiceAmountField;

        private bool invoiceAmountFieldSpecified;

        private string invoiceCodeField;

        private string invoiceDateField;

        private int invoiceIdField;

        private bool invoiceIdFieldSpecified;

        private string invoiceTypeField;

        private Customer payerField;

        private Position[] positionsField;

        private Problem[] problemsLightField;

        private Problem[] problemsSevereField;

        private int repairOrderNumberField;

        private bool repairOrderNumberFieldSpecified;

        private string requestTypeField;

        private string salesPersonIdField;

        private string salesPersonNameField;

        private string teamField;

        private string vehicleBatteryBuyField;

        private string vehicleBatteryIdField;

        private string vehicleCommercialTypeField;

        private string vehicleFuelTypeField;

        private string vehicleMakeField;

        private int vehicleMilageField;

        private bool vehicleMilageFieldSpecified;

        private string vehicleNextCheckDateField;

        private string vehicleRegistrationNumberField;

        private string vehicleTechnicalTypeField;

        private string vehicleTypeField;

        private string vehicleTypeDescriptionField;

        private string vehicleTypeDescriptionLongField;

        private string vehicleVINField;

        private string vehicleYearField;

        private string workingAreaField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Customer customer
        {
            get
            {
                return this.customerField;
            }
            set
            {
                this.customerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string errorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string errorText
        {
            get
            {
                return this.errorTextField;
            }
            set
            {
                this.errorTextField = value;
            }
        }

        /// <remarks/>
        public double invoiceAmount
        {
            get
            {
                return this.invoiceAmountField;
            }
            set
            {
                this.invoiceAmountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool invoiceAmountSpecified
        {
            get
            {
                return this.invoiceAmountFieldSpecified;
            }
            set
            {
                this.invoiceAmountFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string invoiceCode
        {
            get
            {
                return this.invoiceCodeField;
            }
            set
            {
                this.invoiceCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string invoiceDate
        {
            get
            {
                return this.invoiceDateField;
            }
            set
            {
                this.invoiceDateField = value;
            }
        }

        /// <remarks/>
        public int invoiceId
        {
            get
            {
                return this.invoiceIdField;
            }
            set
            {
                this.invoiceIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool invoiceIdSpecified
        {
            get
            {
                return this.invoiceIdFieldSpecified;
            }
            set
            {
                this.invoiceIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string invoiceType
        {
            get
            {
                return this.invoiceTypeField;
            }
            set
            {
                this.invoiceTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Customer payer
        {
            get
            {
                return this.payerField;
            }
            set
            {
                this.payerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("positions", IsNullable = true)]
        public Position[] positions
        {
            get
            {
                return this.positionsField;
            }
            set
            {
                this.positionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("problemsLight", IsNullable = true)]
        public Problem[] problemsLight
        {
            get
            {
                return this.problemsLightField;
            }
            set
            {
                this.problemsLightField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("problemsSevere", IsNullable = true)]
        public Problem[] problemsSevere
        {
            get
            {
                return this.problemsSevereField;
            }
            set
            {
                this.problemsSevereField = value;
            }
        }

        /// <remarks/>
        public int repairOrderNumber
        {
            get
            {
                return this.repairOrderNumberField;
            }
            set
            {
                this.repairOrderNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool repairOrderNumberSpecified
        {
            get
            {
                return this.repairOrderNumberFieldSpecified;
            }
            set
            {
                this.repairOrderNumberFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string requestType
        {
            get
            {
                return this.requestTypeField;
            }
            set
            {
                this.requestTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string salesPersonId
        {
            get
            {
                return this.salesPersonIdField;
            }
            set
            {
                this.salesPersonIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string salesPersonName
        {
            get
            {
                return this.salesPersonNameField;
            }
            set
            {
                this.salesPersonNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string team
        {
            get
            {
                return this.teamField;
            }
            set
            {
                this.teamField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleBatteryBuy
        {
            get
            {
                return this.vehicleBatteryBuyField;
            }
            set
            {
                this.vehicleBatteryBuyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleBatteryId
        {
            get
            {
                return this.vehicleBatteryIdField;
            }
            set
            {
                this.vehicleBatteryIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleCommercialType
        {
            get
            {
                return this.vehicleCommercialTypeField;
            }
            set
            {
                this.vehicleCommercialTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleFuelType
        {
            get
            {
                return this.vehicleFuelTypeField;
            }
            set
            {
                this.vehicleFuelTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleMake
        {
            get
            {
                return this.vehicleMakeField;
            }
            set
            {
                this.vehicleMakeField = value;
            }
        }

        /// <remarks/>
        public int vehicleMilage
        {
            get
            {
                return this.vehicleMilageField;
            }
            set
            {
                this.vehicleMilageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool vehicleMilageSpecified
        {
            get
            {
                return this.vehicleMilageFieldSpecified;
            }
            set
            {
                this.vehicleMilageFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleNextCheckDate
        {
            get
            {
                return this.vehicleNextCheckDateField;
            }
            set
            {
                this.vehicleNextCheckDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleRegistrationNumber
        {
            get
            {
                return this.vehicleRegistrationNumberField;
            }
            set
            {
                this.vehicleRegistrationNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleTechnicalType
        {
            get
            {
                return this.vehicleTechnicalTypeField;
            }
            set
            {
                this.vehicleTechnicalTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleType
        {
            get
            {
                return this.vehicleTypeField;
            }
            set
            {
                this.vehicleTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleTypeDescription
        {
            get
            {
                return this.vehicleTypeDescriptionField;
            }
            set
            {
                this.vehicleTypeDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleTypeDescriptionLong
        {
            get
            {
                return this.vehicleTypeDescriptionLongField;
            }
            set
            {
                this.vehicleTypeDescriptionLongField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleVIN
        {
            get
            {
                return this.vehicleVINField;
            }
            set
            {
                this.vehicleVINField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string vehicleYear
        {
            get
            {
                return this.vehicleYearField;
            }
            set
            {
                this.vehicleYearField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string workingArea
        {
            get
            {
                return this.workingAreaField;
            }
            set
            {
                this.workingAreaField = value;
            }
        }
    }
}