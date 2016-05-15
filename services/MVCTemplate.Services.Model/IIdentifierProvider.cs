using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTemplate.Services.Web
{
    public interface IIdentifierProvider
    {
        int Decode(string id);

        string EncodeId(int id);
    }
}
