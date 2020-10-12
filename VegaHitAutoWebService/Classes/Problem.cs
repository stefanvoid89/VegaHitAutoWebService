using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VegaHitAutoWebService.Classes
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://hitauto.rs/prob")]
    public partial class Problem
    {

        private string problemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string problem
        {
            get
            {
                return this.problemField;
            }
            set
            {
                this.problemField = value;
            }
        }
    }
}