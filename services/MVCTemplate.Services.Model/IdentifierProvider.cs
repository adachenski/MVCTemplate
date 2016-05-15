namespace MVCTemplate.Services.Web
{
    using System;
    using System.Text;

    public class IdentifierProvider : IIdentifierProvider
    {
        private const string Salt = "13143";
        public int Decode(string id)
        {
            var base64EncodedBytes = Convert.FromBase64String(id);
            var bytesAsString = Encoding.UTF8.GetString(base64EncodedBytes);
            bytesAsString = bytesAsString.Replace(Salt, "");
            return int.Parse(bytesAsString);
        }

        public string EncodeId(int urlId)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(urlId.ToString()+Salt);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
