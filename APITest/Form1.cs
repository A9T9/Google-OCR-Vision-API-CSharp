using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using OCRAPITest.Google;

namespace OCRAPITest
{
    public partial class Form1 : Form
    {
        public string ImagePath { get; set; }
        public string PdfPath { get; set; }

        public Form1()
        {
            InitializeComponent();
            cmbType.SelectedIndex = cmbLanguage.SelectedIndex = 5;
            rb_OCR.Checked = true;
            rb_OCR_CheckedChanged(null,null);
        }

        private string getSelectedLanguage()
        {

            //https://ocr.space/OCRAPI#PostParameters

            //Czech = cze; Danish = dan; Dutch = dut; English = eng; Finnish = fin; French = fre; 
            //German = ger; Hungarian = hun; Italian = ita; Norwegian = nor; Polish = pol; Portuguese = por;
            //Spanish = spa; Swedish = swe; ChineseSimplified = chs; Greek = gre; Japanese = jpn; Russian = rus;
            //Turkish = tur; ChineseTraditional = cht; Korean = kor

            string strLang = "";
            switch (cmbLanguage.SelectedIndex)
            {
                case 0:
                    strLang = "chs";
                    break;

                case 1:
                    strLang = "cht";
                    break;
                case 2:
                    strLang = "cze";
                    break;
                case 3:
                    strLang = "dan";
                    break;
                case 4:
                    strLang = "dut";
                    break;
                case 5:
                    strLang = "eng";
                    break;
                case 6:
                    strLang = "fin";
                    break;
                case 7:
                    strLang = "fre";
                    break;
                case 8:
                    strLang = "ger";
                    break;
                case 9:
                    strLang = "gre";
                    break;
                case 10:
                    strLang = "hun";
                    break;
                case 11:
                    strLang = "jap";
                    break;
                case 12:
                    strLang = "kor";
                    break;
                case 13:
                    strLang = "nor";
                    break;
                case 14:
                    strLang = "pol";
                    break;
                case 15:
                    strLang = "por";
                    break;
                case 16:
                    strLang = "spa";
                    break;
                case 17:
                    strLang = "swe";
                    break;
                case 18:
                    strLang = "tur";
                    break;

            }
            return strLang;

        }

        private string getGoogleSelectedLanguage()
        {
            string strLang = "";
            switch (cmbLanguage.SelectedIndex)
            {
                case 0:
                    strLang = "zh-CN";
                    break;

                case 1:
                    strLang = "zh-TW";
                    break;
                case 2:
                    strLang = "cs";
                    break;
                case 3:
                    strLang = "da";
                    break;
                case 4:
                    strLang = "nl";
                    break;
                case 5:
                    strLang = "en";
                    break;
                case 6:
                    strLang = "fi";
                    break;
                case 7:
                    strLang = "fr";
                    break;
                case 8:
                    strLang = "de";
                    break;
                case 9:
                    strLang = "el";
                    break;
                case 10:
                    strLang = "hu";
                    break;
                case 11:
                    strLang = "jap";
                    break;
                case 12:
                    strLang = "it";
                    break;
                case 13:
                    strLang = "ja";
                    break;
                case 14:
                    strLang = "ko";
                    break;
                case 15:
                    strLang = "no";
                    break;
                case 16:
                    strLang = "pl";
                    break;
                case 17:
                    strLang = "pt";
                    break;
                case 18:
                    strLang = "ru";
                    break;
                case 19:
                    strLang = "es";
                    break;
                case 20:
                    strLang = "sv";
                    break;
                case 21:
                    strLang = "tr";
                    break;
                default:
                    strLang = "en";
                    break;
            }

            return strLang;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            PdfPath = ImagePath = ""; pictureBox.BackgroundImage = null;
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "jpeg files|*.jpg;*.JPG;*.png;*.PNG";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(fileDlg.FileName);
                if (fileInfo.Length > 1024*1024)
                {
                    MessageBox.Show("jpeg file's size can not be larger than 1Mb");
                    return;
                }
                pictureBox.BackgroundImage = Image.FromFile(fileDlg.FileName);
                ImagePath = fileDlg.FileName;
            }
        }

        private byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                return imageBytes;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (rb_Google.Checked)
            {
                RecognizeGoogleApi();
            }
            else
            {
                if (string.IsNullOrEmpty(ImagePath) && string.IsNullOrEmpty(PdfPath))                    
                    return;
                                
                txtResult.Text = "";

                button1.Enabled = false;
                button2.Enabled = false;
                btnPdf.Enabled = false;
                try
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.Timeout= new TimeSpan(1,1,1);
                    //Removed the api key from headers
                    //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("apikey", "5a64d478-9c89-43d8-88e3-c65de9999580");

                    MultipartFormDataContent form = new MultipartFormDataContent();
                    //5a64d478-9c89-43d8-88e3-c65de9999580
                    form.Add(new StringContent("helloworld"), "apikey"); //The "helloworld" key works, but it has a very low rate limit. You can get your won free api key at https://ocr.space/OCRAPI
                    form.Add(new StringContent(getSelectedLanguage()), "language");

                    if (string.IsNullOrEmpty(ImagePath) == false)
                    {
                        byte[] imageData = File.ReadAllBytes(ImagePath);
                        form.Add(new ByteArrayContent(imageData, 0, imageData.Length), "image", "image.jpg");
                    }
                    else if (string.IsNullOrEmpty(PdfPath) == false)
                    {
                        byte[] imageData = File.ReadAllBytes(PdfPath);
                        form.Add(new ByteArrayContent(imageData, 0, imageData.Length), "PDF", "pdf.pdf");
                    }

                    HttpResponseMessage response = await httpClient.PostAsync("https://api.ocr.space/Parse/Image", form);

                    string strContent = ResultJsonString = await response.Content.ReadAsStringAsync();



                    Rootobject ocrResult = JsonConvert.DeserializeObject<Rootobject>(strContent);


                    if (ocrResult.OCRExitCode == 1)
                    {
                        for (int i = 0; i < ocrResult.ParsedResults.Count(); i++)
                        {
                            ResultTextString = txtResult.Text = txtResult.Text + ocrResult.ParsedResults[i].ParsedText;
                        }


                        if (rbJson.Checked)
                            txtResult.Text = ResultJsonString.Replace("\\r", "").Replace("\\n", "");

                    }
                    else
                    {
                        MessageBox.Show("ERROR: " + strContent);
                    }




                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ooops");
                }

                button1.Enabled = true;
                button2.Enabled = true;
                btnPdf.Enabled = true;
            }
            
        }

        private string ResultJsonString = "";
        private string ResultTextString = "";

        private void rbJson_CheckedChanged(object sender, EventArgs e)
        {
            txtResult.Text = ResultJsonString.Replace("\\r", "").Replace("\\n", "");
        }

        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            txtResult.Text = ResultTextString;
        }

       

        private void btnPdf_Click(object sender, EventArgs e)
        {
            PdfPath = ImagePath = "";
            pictureBox.BackgroundImage = null;
            OpenFileDialog fileDlg = new OpenFileDialog();            
            fileDlg.Filter = "pdf files|*.pdf;";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(fileDlg.FileName);
                if (fileInfo.Length > 1024 * 1024 * 4)
                {
                    MessageBox.Show("PDF file's size can not be larger than 4Mb");
                    return;
                }
                PdfPath = fileDlg.FileName;
                txtPDF.Text = fileInfo.Name;
            }
        }

        public async void RecognizeGoogleApi()
        {
            if (string.IsNullOrEmpty(ImagePath))
                return;
            button1.Enabled = button2.Enabled = false;
            txtResult.Text = "";
            Annotate annotate = new Annotate();
            Application.DoEvents();
            await annotate.GetText(ImagePath, getGoogleSelectedLanguage(),cmbType.SelectedItem+"");
            if(string.IsNullOrEmpty(annotate.Error)==false)
                MessageBox.Show("ERROR: " + annotate.Error);
            else
                txtResult.Text = annotate.TextResult;


            button1.Enabled = button2.Enabled = true;
        }

        private void rb_OCR_CheckedChanged(object sender, EventArgs e)
        {
            btnPdf.Visible = txtPDF.Visible = rbJson.Visible = rbText.Visible = true;
            cmbType.Visible = label2.Visible = false;

        }

        private void rb_Google_CheckedChanged(object sender, EventArgs e)
        {
            btnPdf.Visible = txtPDF.Visible = rbJson.Visible = rbText.Visible = false;
            cmbType.Visible = label2.Visible = true;
        }
    }
}



