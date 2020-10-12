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
   // [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://hitauto.rs/cust")]
    public partial class Position
    {

        private string codeField;

        private string descirptionField;

        private double labourTimeField;

        private bool labourTimeFieldSpecified;

        private string labourTimeTypeField;

        private string partDescriptionField;

        private string partFamilyField;

        private double priceField;

        private bool priceFieldSpecified;

        private double priceFinalField;

        private bool priceFinalFieldSpecified;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string descirption
        {
            get
            {
                return this.descirptionField;
            }
            set
            {
                this.descirptionField = value;
            }
        }

        /// <remarks/>
        public double labourTime
        {
            get
            {
                return this.labourTimeField;
            }
            set
            {
                this.labourTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool labourTimeSpecified
        {
            get
            {
                return this.labourTimeFieldSpecified;
            }
            set
            {
                this.labourTimeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string labourTimeType
        {
            get
            {
                return this.labourTimeTypeField;
            }
            set
            {
                this.labourTimeTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string partDescription
        {
            get
            {
                return this.partDescriptionField;
            }
            set
            {
                this.partDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string partFamily
        {
            get
            {
                return this.partFamilyField;
            }
            set
            {
                this.partFamilyField = value;
            }
        }

        /// <remarks/>
        public double price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool priceSpecified
        {
            get
            {
                return this.priceFieldSpecified;
            }
            set
            {
                this.priceFieldSpecified = value;
            }
        }

        /// <remarks/>
        public double priceFinal
        {
            get
            {
                return this.priceFinalField;
            }
            set
            {
                this.priceFinalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool priceFinalSpecified
        {
            get
            {
                return this.priceFinalFieldSpecified;
            }
            set
            {
                this.priceFinalFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
}