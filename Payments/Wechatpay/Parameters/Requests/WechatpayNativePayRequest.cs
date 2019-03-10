﻿using Payments.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payments.Wechatpay.Parameters.Requests
{
    /// <summary>
    /// 微信支付参数
    /// </summary>
    public class WechatpayNativePayRequest : WechatpayPayRequestBase
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        [Required]
        [MaxLength(32)]
        public override string ProductId { get; set; }
    }

}
