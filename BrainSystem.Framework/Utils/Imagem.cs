using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.IO;

namespace BrainSystem.Framework.Utils
{
    public static class Imagem
    {
        public static string FormatarImagem(Image Imagem)
        {
            MemoryStream ms = new MemoryStream();
            Imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return String.Join(" ", ms.ToArray());
        }


        public static byte[] RetornarImagem(string ImagemText)
        {
            List<byte> Array = new List<byte>();
            int contador = 0;

            foreach (char item in ImagemText.ToString())
            {
                if (item != ' ')
                {
                    if (Array.Count == contador)
                    {
                        Array.Insert(contador, byte.Parse(item.ToString()));
                    }
                    else
                    {
                        Array[contador] = byte.Parse(Array[contador].ToString() + item.ToString());
                    }
                }
                else
                {
                    contador++;
                }
            }

            byte[] obj = (byte[])Array.ToArray();
            return obj;
        }



        public static string ConverterHttpImagem(HttpPostedFileBase pArquivo)
        {
            string vRet = string.Empty;

            try
            {
                var binaryData = new byte[pArquivo.InputStream.Length];
                pArquivo.InputStream.Read(binaryData, 0, (int)pArquivo.InputStream.Length);
                var base64String = Convert.ToBase64String(binaryData, 0, binaryData.Length);

                Stream stmBLOBData = new MemoryStream(binaryData);


                Image imagemfoto = Image.FromStream(stmBLOBData, true);

                vRet = Imagem.FormatarImagem(imagemfoto);

            }
            catch (Exception ex)
            {

                string msg = ex.Message;
            }


            return vRet;


        }

    }
}
