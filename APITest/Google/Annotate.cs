using Google.Apis.Auth.OAuth2;
using Google.Apis.Vision.v1;

using Google.Apis.Util.Store;

using System;
using System.Collections.Generic;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Services;
using Google.Apis.Vision.v1.Data;
using Newtonsoft.Json;

namespace OCRAPITest.Google
{
    public class Annotate
    {
        public string ApplicationName {get { return "Ocr"; } }
        
        public string JsonResult { get; set; }
        public string TextResult { get; set; }
        public string Error { get; set; }

        private GoogleCredential CreateCredential()
        {
            // this is the place to enter your own google API key (= json file). The app crashes without valid key. 
            using (var stream = new FileStream(Application.StartupPath + "\\your-key-here.json", FileMode.Open, FileAccess.Read))
            {
                string[] scopes = {VisionService.Scope.CloudPlatform};
                var credential = GoogleCredential.FromStream(stream);
                credential = credential.CreateScoped(scopes);
                return credential;
            }           
         }


        private VisionService CreateService(GoogleCredential credential)
        {
            var service = new VisionService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
                GZipEnabled = true,
            });

            return service;
        }

        /// <summary>
        /// read image as byte and send to google api
        /// </summary>
        /// <param name="imgPath"></param>
        /// <param name="language"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<string>  GetText(string imgPath,string language,string type)
        {
            TextResult = JsonResult = "";
            var credential = CreateCredential();
            var service = CreateService(credential);
            service.HttpClient.Timeout = new TimeSpan(1,1,1);
            byte[] file = File.ReadAllBytes(imgPath);

            BatchAnnotateImagesRequest batchRequest = new BatchAnnotateImagesRequest();
            batchRequest.Requests= new List<AnnotateImageRequest>();
            batchRequest.Requests.Add(new AnnotateImageRequest()
            {
                Features = new List<Feature>() { new Feature() {Type = type, MaxResults = 1 },  },
                ImageContext = new ImageContext() { LanguageHints = new List<string>() { language } },
                Image = new Image() { Content = Convert.ToBase64String(file) }
            });            

            var annotate =  service.Images.Annotate(batchRequest);
            BatchAnnotateImagesResponse batchAnnotateImagesResponse = annotate.Execute();            
            if (batchAnnotateImagesResponse.Responses.Any())
            {
                AnnotateImageResponse annotateImageResponse = batchAnnotateImagesResponse.Responses[0];
                if (annotateImageResponse.Error != null)
                {
                    if (annotateImageResponse.Error.Message != null)
                        Error = annotateImageResponse.Error.Message;
                }
                else 
                {
                    switch (type)
                    {
                        case "TEXT_DETECTION":
                            if (annotateImageResponse.TextAnnotations != null && annotateImageResponse.TextAnnotations.Any())
                                TextResult = annotateImageResponse.TextAnnotations[0].Description.Replace("\n", "\r\n");
                            break;
                        case "DOCUMENT_TEXT_DETECTION":
                            if (annotateImageResponse.TextAnnotations != null && annotateImageResponse.TextAnnotations.Any())
                                TextResult = annotateImageResponse.TextAnnotations[0].Description.Replace("\n", "\r\n");
                            break;                            
                        case "FACE_DETECTION":
                            if (annotateImageResponse.FaceAnnotations != null && annotateImageResponse.FaceAnnotations.Any())
                                TextResult = JsonConvert.SerializeObject(annotateImageResponse.FaceAnnotations[0]);                            
                            break;
                        case "LOGO_DETECTION":
                            if (annotateImageResponse.LogoAnnotations != null && annotateImageResponse.LogoAnnotations.Any())
                                TextResult = JsonConvert.SerializeObject(annotateImageResponse.LogoAnnotations[0]);
                            break;
                        case "LABEL_DETECTION":
                            if (annotateImageResponse.LabelAnnotations != null && annotateImageResponse.LabelAnnotations.Any())
                                TextResult = JsonConvert.SerializeObject(annotateImageResponse.LabelAnnotations[0]);
                            break;
                        case "LANDMARK_DETECTION":
                            if (annotateImageResponse.LandmarkAnnotations != null && annotateImageResponse.LandmarkAnnotations.Any())
                                TextResult = JsonConvert.SerializeObject(annotateImageResponse.LandmarkAnnotations[0]);
                            break;
                        case "SAFE_SEARCH_DETECTION":
                            if (annotateImageResponse.SafeSearchAnnotation != null)
                                TextResult = JsonConvert.SerializeObject(annotateImageResponse.SafeSearchAnnotation);
                            break;
                        case "IMAGE_PROPERTIES":
                            if (annotateImageResponse.ImagePropertiesAnnotation != null)
                                TextResult = JsonConvert.SerializeObject(annotateImageResponse.ImagePropertiesAnnotation);
                            break;

                    }


                    
                    //return ;
                }
                            
            }

            return "";
            //return TextResult;
        }


    }
}
