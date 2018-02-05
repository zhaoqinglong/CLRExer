using System;
using System.Collections.Generic;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace TokenBusiness.Jwt
{
    /// <summary>
    /// GetJwtToken 的摘要说明
    /// </summary>
    public class Token
    {
        const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        /// <summary>
        /// jwt主要分为三部分：header、playload、secret
        /// </summary>
        public string GetTokenJwt()
        {

            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();

            //计算从utc时间到现在的经过的秒数
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
            var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);

            //定义playload
            var payload = new Dictionary<string, object>
            {
                {"name", "MrBug"},
                {"exp", secondsSinceEpoch + 10000},
                {"jti", "test"}
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);



            var token = encoder.Encode(payload, secret);

            return token;
        }

        /// <summary>
        /// 解密jwt
        /// </summary>
        public void DecryptJwt()
        {

            var token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYW1lIjoiTXJCdWciLCJleHAiOjE1MTc4MjA1NDkuMCwianRpIjoidGVzdCJ9.yAE4_stLcfxWiYCifsS8noQz2jOqbsRzZQBgAn6ppUA";
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(token, secret, verify: true);
                Console.WriteLine(json);
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
            }
        }
    }
}