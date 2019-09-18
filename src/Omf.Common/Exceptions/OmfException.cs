using System;
using System.Collections.Generic;
using System.Text;

namespace Omf.Common.Exceptions
{
    public class OmfException:Exception
    {
        public string Code { get; }
        public OmfException()
        {

        }
        public OmfException(string code)
        {
            Code = code;
        }
        public OmfException(string message,params object[] args): this(string.Empty,message,args)
        {

        }
        public OmfException(string code, string message,params object[] args):this(null,code,message,args)
        {

        }
        public OmfException(Exception innerException, string message, params object[] args):this(innerException,string.Empty,message,args)
        {

        }
        public OmfException(Exception innerException, string code, string message, params object[] args): base(string.Format(message,args),innerException)
        {
            Code = code;
        }
    }
}
