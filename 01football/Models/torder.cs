//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01football.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class torder
    {
        public int fid { get; set; }
        [DisplayName("訂單編號")]
        public string forderguid { get; set; }
        [DisplayName("會員帳號")]
        public string fuserid { get; set; }
        [DisplayName("收件人")]
        public string freceiver { get; set; }
        [DisplayName("收件人信箱")]
        [Required]
        [EmailAddress]
        public string femail { get; set; }
        [DisplayName("收件人地址")]
        [Required]
        public string faddress { get; set; }
        [DisplayName("訂單日期")]
        public System.DateTime fdate { get; set; }
    }
}
