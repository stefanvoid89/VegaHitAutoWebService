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
        
    public partial class Customer
    {
        
        private string birthDateField;

       private MarketingInformation[] brandMarketingDataField;

        private string cityField;

        private string eMail1Field;

        private string eMail2Field;

        private string firstNameField;

        private System.Nullable<int> idField;

        private bool idFieldSpecified;

        private string lastNameField;

        private string marketingCommentField;

        private string marketingEMailField;

        private string marketingFaxField;

        private string marketingMailField;

        private string marketingPhoneField;

        private string marketingPreferredField;

        private string marketingSMSMMSField;

        private string marketingWelcomeTerminalField;

        private string mobilePhone1Field;

        private string mobilePhone2Field;

        private string nameField;

        private string phone1Field;

        private string phone2Field;

        private string sexField;

        private string streetField;

        private string taxNumberField;

        private bool taxPayerField;

        private bool taxPayerFieldSpecified;

        private bool useMaketingDataField;

        private bool useMaketingDataFieldSpecified;

        private string zipField;

        private bool isCompanyField;

        private bool isCompanyFieldSpecified;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string birthDate
        {
            get
            {
                return this.birthDateField;
            }
            set
            {
                this.birthDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string eMail1
        {
            get
            {
                return this.eMail1Field;
            }
            set
            {
                this.eMail1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string eMail2
        {
            get
            {
                return this.eMail2Field;
            }
            set
            {
                this.eMail2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string firstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string lastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
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
        public string marketingWelcomeTerminal
        {
            get
            {
                return this.marketingWelcomeTerminalField;
            }
            set
            {
                this.marketingWelcomeTerminalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string mobilePhone1
        {
            get
            {
                return this.mobilePhone1Field;
            }
            set
            {
                this.mobilePhone1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string mobilePhone2
        {
            get
            {
                return this.mobilePhone2Field;
            }
            set
            {
                this.mobilePhone2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string phone1
        {
            get
            {
                return this.phone1Field;
            }
            set
            {
                this.phone1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string phone2
        {
            get
            {
                return this.phone2Field;
            }
            set
            {
                this.phone2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string sex
        {
            get
            {
                return this.sexField;
            }
            set
            {
                this.sexField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string taxNumber
        {
            get
            {
                return this.taxNumberField;
            }
            set
            {
                this.taxNumberField = value;
            }
        }

        /// <remarks/>
        public bool taxPayer
        {
            get
            {
                return this.taxPayerField;
            }
            set
            {
                this.taxPayerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool taxPayerSpecified
        {
            get
            {
                return this.taxPayerFieldSpecified;
            }
            set
            {
                this.taxPayerFieldSpecified = value;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string zip
        {
            get
            {
                return this.zipField;
            }
            set
            {
                this.zipField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> isCompany
        {

            get
            {
                return this.isCompanyField;
            }
            set
            {
                this.isCompanyField = (bool)value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool isCompanySpecified
        {
            get
            {
                return this.isCompanyFieldSpecified;
            }
            set
            {
                this.isCompanyFieldSpecified = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("brandMarketingData", IsNullable = true)]
        public MarketingInformation[] brandMarketingData
        {
            get
            {
                return this.brandMarketingDataField;
            }
            set
            {
                this.brandMarketingDataField = value;
            }
        }
    }


}