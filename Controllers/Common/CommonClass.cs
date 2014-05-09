﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Controllers.DataAccess.DAL;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Controllers.Common
{
    public class CommonClass
    {
        /// <summary>
        /// 跟据字节流得到字体对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Font GetFontByByte(byte[] buff)
        {
            try
            {
                //通过字节数组的到内存流
                MemoryStream ms = new MemoryStream(buff);
                //ms.Position = 0;
                return new BinaryFormatter().Deserialize(ms) as Font;//通过反序列化技术还原image图像

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
 
        /// <summary>
        /// 跟据字体对象返回字节流
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public byte[] GetByteByFont(Font font)
        {
            try
            {
                MemoryStream ms = new MemoryStream(); //实例化内存流
                new BinaryFormatter().Serialize(ms, font); //将对象图形序列化为给定流
                return ms.GetBuffer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 跟据字节流得到颜色对象
        /// </summary>
        /// <param name="buff"></param>
        /// <returns></returns>
        public Color GetColorByByte(byte[] buff)
        {
            try
            {
                //通过字节数组的到内存流
                MemoryStream ms = new MemoryStream(buff);
                //ms.Position = 0;
                return (Color)new BinaryFormatter().Deserialize(ms);//通过反序列化技术还原image图像

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 跟据颜色对象返回字节流
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        public byte[] GetByteByColor(Color color)
        {
            try
            {
                MemoryStream ms = new MemoryStream(); //实例化内存流
                new BinaryFormatter().Serialize(ms, color); //将对象图形序列化为给定流
                return ms.GetBuffer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class ComboxItem
    {
        /// <summary>
        /// 显示文本
        /// </summary>
        public String Text = "";

        /// <summary>
        /// 值
        /// </summary>
        public String Value = "";
        public ComboxItem(String _Text, String _Value)
        {
            Text = _Text;
            Value = _Value;
        }

        public override String ToString()
        {
            return Text;
        }
    }
}
