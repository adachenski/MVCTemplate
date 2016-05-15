namespace MVCTemplate.Services.Web.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class IdentifierProviderTests
    {
        [Test]
        public void EncodingAndDecodingDontChangeTheId()
        {
            const int id = 2332;
            IIdentifierProvider provider = new IdentifierProvider();
            var encoded = provider.EncodeId(id);
            var actual = provider.Decode(encoded);
            Assert.AreEqual(id, actual);
        }
    }
}
