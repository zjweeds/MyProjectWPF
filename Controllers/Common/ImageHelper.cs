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
       public byte[] GetBytesByImage(Image img)
       {
           try
           {
               MemoryStream ms = new MemoryStream(); //实例化内存流
               new BinaryFormatter().Serialize(ms, img); //将对象图形序列化为给定流
               return ms.GetBuffer();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public byte[] GetBytesByImagepath(String path)
       {
           System.Drawing.Image img = System.Drawing.Image.FromFile(path);
           try
           {
               MemoryStream ms = new MemoryStream(); //实例化内存流
               new BinaryFormatter().Serialize(ms, img); //将对象图形序列化为给定流
               return ms.GetBuffer();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public Stream GetStreamByImagepath(String path)
       {
           System.Drawing.Image img = System.Drawing.Image.FromFile(path);
           try
           {
               Stream ms = new MemoryStream(); //实例化内存流
               new BinaryFormatter().Serialize(ms, img); //将对象图形序列化为给定流
               return ms;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public byte[] GetBytesByBitmapImage(String path)
       {
           try
           {
               FileStream fs = File.OpenRead(path);
               byte[] tempBuff = new byte[fs.Length];
               fs.Read(tempBuff, 0, tempBuff.Length);
               return tempBuff;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
      
       public BitmapImage GetBitmapImageByByte(byte[] buffer)
       {
           try
           {
               MemoryStream ms = new MemoryStream(buffer);
               ms.Seek(0, SeekOrigin.Begin);
               BitmapImage BI = new BitmapImage();
               BI.BeginInit();
               BI.StreamSource = ms;
               BI.EndInit();
               return BI;
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
               //通过字节数组的到内存流
               MemoryStream ms = new MemoryStream(buffer);
               //ms.Position = 0;
               return new BinaryFormatter().Deserialize(ms) as Image;//通过反序列化技术还原image图像
                
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
    }
}
