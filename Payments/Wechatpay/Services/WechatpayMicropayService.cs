﻿using Microsoft.Extensions.Logging;
using Payments.Core.Response;
using Payments.Util;
using Payments.Wechatpay.Abstractions;
using Payments.Wechatpay.Configs;
using Payments.Wechatpay.Parameters;
using Payments.Wechatpay.Parameters.Requests;
using Payments.Wechatpay.Results;
using Payments.Wechatpay.Services.Base;
using System;
using System.Threading.Tasks;

namespace Payments.Wechatpay.Services
{
    /// <summary>
    /// 提交付款码支付
    /// </summary>
    public class WechatpayMicropayService : WechatpayServiceBase<WechatpayMicroPayRequest>, IWechatpayMicroPayService
    { 
        /// <summary>
      /// 初始化微信App支付服务
      /// </summary>
      /// <param name="provider">微信支付配置提供器</param>
        public WechatpayMicropayService(IWechatpayConfigProvider provider, ILoggerFactory loggerFactory) : base(provider, loggerFactory)
        {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<PayResult> PayAsync(WechatpayMicroPayRequest t)
        {
            return Request(t);
        }

        /// <summary>
        /// 获取URL
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        protected override string GetRequestUrl(WechatpayConfig config)
        {
            return config.GetMicroPayUrl();
        }







        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <param name="builder">参数生成器</param>
        /// <param name="result">支付结果</param>
        protected override string GetResult(WechatpayConfig config, WechatpayParameterBuilder builder, WechatpayResult result)
        {
            return new WechatpayParameterBuilder(config)
                .AppId(config.AppId)
                .PartnerId(config.MerchantId)
                .PrepayId(result.GetPrepayId())
                .NonceStr(Id.GetId())
                .Timestamp()
                .Package()
                .ToJson();
        }

        protected override void InitBuilder(WechatpayParameterBuilder builder, WechatpayMicroPayRequest param)
        {
            throw new NotImplementedException();
        }
    }
}