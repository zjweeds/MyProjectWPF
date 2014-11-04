//----------------------------------------------------------------//
//功能：MD5加密帮助类                                              //
//作者：赵建                                                      //
//版本：v1.3                                                      //
//创建时间：2013/11/7   15:34:00                                  //
//最后一次修改时间：2014/3/23   17:22:00                          //
//---------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Common
{
   public  class MD5String
    {
       public string GetMD5string(string Plaintext)
       {
           byte[] result = Encoding.Default.GetBytes(Plaintext);    
           MD5 md5 = new MD5CryptoServiceProvider();
           byte[] output = md5.ComputeHash(result);
           return  BitConverter.ToString(output).Replace("-", "");  //输出加密文
       }
    }
}
