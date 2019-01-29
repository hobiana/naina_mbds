using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace MauritiusGuideBackEnd.utilitaire
{
    public class PhotoUtil
    {
        public string EncoderPhoto(string path)
        {
            path = "E:\\herinihaja\\lion.jpg";
            Byte[] bytes = System.IO.File.ReadAllBytes(path);
            Image image = byteArrayToImage(bytes);
            
            image = ScaleImage(image, 40, 40);
            Byte[] newByte = CopyImageToByteArray(image);
            String file = Convert.ToBase64String(newByte);
            return file;
        }

        public string EncodeImage(HttpPostedFileBase uploadFile)
        {
            Byte[] imageByte = ConvertHttpPostedFileToByteArray(uploadFile);
            Image image = byteArrayToImage(imageByte);
            image = ScaleImage(image, 40, 40);
            Byte[] newByte = CopyImageToByteArray(image);
            String file = Convert.ToBase64String(newByte);
            return file;
        }

        public Byte[] ConvertHttpPostedFileToByteArray(HttpPostedFileBase file)
        {
            Byte[] bytes = null;
            var binaryReader = new BinaryReader(file.InputStream);
            bytes = binaryReader.ReadBytes(file.ContentLength);
            
            return bytes;
        }
 
        public void ReadCode(string code)
        {
            Byte[] bytes = Convert.FromBase64String(code);
            System.IO.File.WriteAllBytes("E:\\herinihaja\\tigre.jpg", bytes);
        }



        public static void Test()
        {
            using (var image = Image.FromFile(@"c:\logo.png"))
            using (var newImage = ScaleImage(image, 300, 400))
            {
                newImage.Save(@"c:\test.png", ImageFormat.Png);
            }
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        public byte[] CopyImageToByteArray(Image theImage)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                theImage.Save(memoryStream, ImageFormat.Jpeg);
                return memoryStream.ToArray();
            }
        }

        public Image byteArrayToImage(byte[] bytesArr)
        {
            System.IO.MemoryStream memstr = new System.IO.MemoryStream(bytesArr);
            Image img = Image.FromStream(memstr);
            return img;
        }

    }
}