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
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://hitauto.rs/user")]
    public partial class UserInfo
    {

        private string birNumberField;

        private int companyIdField;

        private bool companyIdFieldSpecified;

        private string dataGroupField;

        private string errorMessageField;

        private string siteCodeField;

        private string userNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string birNumber
        {
            get
            {
                return this.birNumberField;
            }
            set
            {
                this.birNumberField = value;
            }
        }

        /// <remarks/>
        public int companyId
        {
            get
            {
                return this.companyIdField;
            }
            set
            {
                this.companyIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool companyIdSpecified
        {
            get
            {
                return this.companyIdFieldSpecified;
            }
            set
            {
                this.companyIdFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string dataGroup
        {
            get
            {
                return this.dataGroupField;
            }
            set
            {
                this.dataGroupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string errorMessage
        {
            get
            {
                return this.errorMessageField;
            }
            set
            {
                this.errorMessageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string siteCode
        {
            get
            {
                return this.siteCodeField;
            }
            set
            {
                this.siteCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string userName
        {
            get
            {
                return this.userNameField;
            }
            set
            {
                this.userNameField = value;
            }
        }
    }

}