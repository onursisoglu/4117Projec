using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.UI.Utility
{
    public class ImageUploader
    { 
        //senaryo : jpg-jpeg-png-gif 4 format istiyoruz.
      //olay : Eğer gelen dosya null ise "0" , eğer dosya istenilen formatta değilse "2"
      //Eğer dosya her isteği karşılayıp kayıt edildiyse geriye dosyanın kaydedildiği yol döndürülecek.

        public static string UploadImage(string serverPath,HttpPostedFileBase gelenDosya)
        {
            if (gelenDosya != null)
            {
                var fileArray = gelenDosya.FileName.Split('.');
                string resimUzantisi = fileArray[fileArray.Length - 1]; // son index dosya uzantısıdır

                if (resimUzantisi == "jpg" || resimUzantisi == "jpeg" || resimUzantisi == "gif" || resimUzantisi == "png")
                {
                    var uniqueName = Guid.NewGuid();
                    var dosyaAdi = uniqueName + "." + resimUzantisi;
                    var filePath = HttpContext.Current.Server.MapPath(serverPath + dosyaAdi);
                    gelenDosya.SaveAs(filePath);


                    return serverPath + dosyaAdi;
                }
                else
                {
                    return "2";
                }
            }
            else
            {
                return "0";
            }

        }
    }
}