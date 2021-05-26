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
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://hitauto.rs/cust")]


    public partial class MarketingInformation
    {

        private string brandCodeField;

        private string brandTextField;

        private string marketingAftersalesField;

        private string marketingAnalyticField;

        private string marketingCommentField;

        private string marketingEMailField;

        private string marketingFaxField;

        private string marketingInCarField;

        private string marketingMailField;

        private string marketingMessengerField;

        private string marketingPhoneField;

        private string marketingPreferredField;

        private string marketingSMSMMSField;

        private string marketingVehicleSalesField;

        private bool useMaketingDataField;

        private bool useMaketingDataFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string brandCode
        {
            get
            {
                return this.brandCodeField;
            }
            set
            {
                this.brandCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string brandText
        {
            get
            {
                return this.brandTextField;
            }
            set
            {
                this.brandTextField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingAftersales
        {
            get
            {
                return this.marketingAftersalesField;
            }
            set
            {
                this.marketingAftersalesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingAnalytic
        {
            get
            {
                return this.marketingAnalyticField;
            }
            set
            {
                this.marketingAnalyticField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingComment
        {
            get
            {
                return this.marketingCommentField;
            }
            set
            {
                this.marketingCommentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingEMail
        {
            get
            {
                return this.marketingEMailField;
            }
            set
            {
                this.marketingEMailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingFax
        {
            get
            {
                return this.marketingFaxField;
            }
            set
            {
                this.marketingFaxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingInCar
        {
            get
            {
                return this.marketingInCarField;
            }
            set
            {
                this.marketingInCarField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingMail
        {
            get
            {
                return this.marketingMailField;
            }
            set
            {
                this.marketingMailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingMessenger
        {
            get
            {
                return this.marketingMessengerField;
            }
            set
            {
                this.marketingMessengerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingPhone
        {
            get
            {
                return this.marketingPhoneField;
            }
            set
            {
                this.marketingPhoneField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingPreferred
        {
            get
            {
                return this.marketingPreferredField;
            }
            set
            {
                this.marketingPreferredField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingSMSMMS
        {
            get
            {
                return this.marketingSMSMMSField;
            }
            set
            {
                this.marketingSMSMMSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string marketingVehicleSales
        {
            get
            {
                return this.marketingVehicleSalesField;
            }
            set
            {
                this.marketingVehicleSalesField = value;
            }
        }

        /// <remarks/>
        public bool useMaketingData
        {
            get
            {
                return this.useMaketingDataField;
            }
            set
            {
                this.useMaketingDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool useMaketingDataSpecified
        {
            get
            {
                return this.useMaketingDataFieldSpecified;
            }
            set
            {
                this.useMaketingDataFieldSpecified = value;
            }
        }
    }
}