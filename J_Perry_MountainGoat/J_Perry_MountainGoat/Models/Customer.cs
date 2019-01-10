//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MGO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }
        
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        [DisplayName("ID")]
        public short Cust_ID { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string Cust_FName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string Cust_LName { get; set; }
        [Required]
        [DisplayName("Street 1")]
        public string Cust_Street1 { get; set; }
        [DisplayName("Street 2")]
        public string Cust_Street2 { get; set; }
        [Required]
        [DisplayName("City")]
        public string Cust_City { get; set; }
        [Required]
        [StringLength(2)]
        [DisplayName("State")]
        public string Cust_State { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        [DisplayName("ZIP")]
        public string Cust_ZIP { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("EMail")]
        public string Cust_EMail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}