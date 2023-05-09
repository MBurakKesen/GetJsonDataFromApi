using System.Net;
using Newtonsoft.Json;
namespace getJsonDataFromApi
{
    public class getData
    {
        public static void start_get()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://jsonplaceholder.typicode.com/posts"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            Console.WriteLine(WebResp.StatusCode);
            Console.WriteLine(WebResp.Server);

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            List<Post> items = JsonConvert.DeserializeObject<List<Post>>(jsonString);

            //foreach (var item in items)
            //{
            //    Console.WriteLine("userID: " + item.userId.ToString().ToUpper());
            //    Console.WriteLine("id: " + item.id.ToString().ToUpper());
            //    Console.WriteLine("title: " + item.title.ToString().ToUpper());
            //    Console.WriteLine("body: "+item.body.ToString().ToUpper());
            //    Console.WriteLine("\n"); 
            //}
        }
    }
}