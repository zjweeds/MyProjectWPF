using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Drawing;


namespace Controllers.Common
{
   public  class ImageHelper
    {
       public byte[] GetBytesByImagepath(String path)
       {
           System.Drawing.Image img = System.Drawing.Image.FromFile(path);
           try
           {
               MemoryStream ms = new MemoryStream(); //实例化内存流
               new BinaryFormatter().Serialize(ms, img); //将对象图形序列化为给定流
               byte[] buffers= ms.GetBuffer();
               return buffers;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public Image GetImageByByte(byte[] buffer)
       {
           try
           {
               MemoryStream memStream = new MemoryStream(buffer);
               memStream.Position = 0;
               BinaryFormatter de = new BinaryFormatter();
               memStream.Seek(0, SeekOrigin.Begin);
               object newobj = de.Deserialize(memStream);
               memStream.Close();
               memStream.Dispose();
               return newobj as Image; 
               //通过字节数组的到内存流 
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       /// <summary>
       /// 根据路径返回图像对象
       /// </summary>
       /// <param name="path"></param>
       /// <returns></returns>
       public Image GetImageByPath(String path)
       {
           try
           {
               return  System.Drawing.Image.FromFile(path);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void SaveImage(Image image,String sPath )
       {
           image.Save(sPath, System.Drawing.Imaging.ImageFormat.Jpeg);
       }
    }
}
