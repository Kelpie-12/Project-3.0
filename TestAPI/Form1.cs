using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TestAPI
{
    public partial class Form1 : Form
    {
        static HttpClient httpClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            b();
        }
        private async Task b()
        {
            string url = @"http://localhost:5190/api/Apartment/GetApartmentPhoto?id=123";
            Uri uri = null;
            Uri.TryCreate(url, UriKind.Absolute, out uri);
            if (string.IsNullOrEmpty(url))
            {
                return;
            }
            using var response = await httpClient.GetAsync(uri);
            var r = response.Content.ReadFromJsonAsync<MultipartFormDataContent>();

            /*using (OpenFileDialog dlg = new OpenFileDialog { CheckFileExists = true })
            //{
            //    if (dlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlg.FileName))
            //    {
            //        string fileName = dlg.FileName;
            //        try
            //        {
            //            //using var mul = new MultipartFormDataContent();
            //            //mul.Add(new StreamContent(File.OpenRead(fileName)));
            //            //HttpClient client = new HttpClient();
            //            //using var response = client.PostAsync(url, mul);


            //            //byte[] fileByte = File.ReadAllBytes(fileName);
            //            //using var request = new HttpRequestMessage(HttpMethod.Post, uri);
            //            //request.Content = new ByteArrayContent(fileByte);
            //            //using var response = httpClient.SendAsync(request);
            //            //var resposeText = response.Content.ReadAsStringAsync().Result;
            //            //MessageBox.Show(resposeText);

            //            using (HttpClientHandler hdl = new HttpClientHandler())
            //            {
            //                using (HttpClient clnt = new HttpClient(hdl))
            //                {
            //                    using (MultipartFormDataContent content = new MultipartFormDataContent())
            //                    {
            //                        using (ByteArrayContent fileContent = new ByteArrayContent(File.ReadAllBytes(fileName)))
            //                        {
            //                            //byte[] fileByte = File.ReadAllBytes(fileName);

            //                            fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            //                            {
            //                                FileName = Path.GetFileName(fileName),
            //                                Name = "file"
            //                            };

            //                            content.Add(fileContent, "321.png");

            //                            var responce = clnt.PostAsync(uri, content).Result;

            //                            var text = responce.Content.ReadAsStringAsync().Result;
            //                            MessageBox.Show(text);
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //            MessageBox.Show(ex.Message);
            //        }
            //    }
                }
            */
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=158.160.0.70:1433;User ID=kelpie;Password=R#529440x!);Integrated Security=True;Connect Timeout=30;Encrypt=True;Trusted_Connection=true;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=ComopanyProgect"))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "CREATE DATABASE Tetst;";
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //string url = "https://localhost:7286/api/Values/Ping/1";
            //Uri uri = null;
            //Uri.TryCreate(url, UriKind.Absolute, out uri);
            //if (string.IsNullOrEmpty(url))
            //{
            //    return;
            //}
            //HttpClient httpClient = new HttpClient();
            //using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            //using HttpResponseMessage response =  httpClient.Send(request);
            //foreach (var header in response.Headers)
            //{
            //    Console.Write($"{header.Key}:");
            //    foreach (var headerValue in header.Value)
            //    {
            //        textBox1.Text+=(headerValue);
            //    }
            //}
        }
    }
}
