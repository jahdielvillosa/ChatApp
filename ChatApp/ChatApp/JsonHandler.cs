using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Net.Http;
using System.Collections.Specialized;
using System.Data;

namespace ChatApp
{
    class JsonHandler
    {
        
        public class MessageDetails
        {
            public string Id { get; set; }
            public string RecType { get; set; }
            public string Recipient { get; set; }
            public string Message { get; set; }
            public string DTSending { get; set; }
            public string RefId { get; set; }
            public string RefTable { get; set; }

        }

        public class RootDetails
        {
            public List<MessageDetails> MessageList { get; set; }
        }

        /*
         * Send GET query from the server based on the input url.
         * response from server is json object and converted to
         * datatable object array. 
         */
        public DataTable Getcontent(string url)
        {
            //deserialize json string (sample)
            //string json = @"[{'one': 'two','key':'value'},{'one': 'two2','key':'value2'}]";
            //string json = @"[{'id':'01','reciever':'09279016517','message':'hello world','status':'success'},{'id':'01','reciever':'09279016517','message':'hello world','status':'success'}]";

            try
            {
                //request json data
                Uri uri = new Uri(url);

                //create request from the server from given url
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Get;

                //open and get the response from the server
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                
                //get the data from the reader
                string output = reader.ReadToEnd();

                //close connection
                response.Close();

                //deserialize json string
                var json = output;

                Console.WriteLine("Fetching list from server" + json);

                //for json list, create table which handles the json object
                DataSet dataset = JsonConvert.DeserializeObject<DataSet>(json);
                DataTable dataTable = dataset.Tables["Result"];

                //display result in console (for debugging)
                //Console.WriteLine(dataTable.Rows.Count);
                //foreach (DataRow row in dataTable.Rows)
                //{
                //    Console.WriteLine(row["id"]);
                //    Console.WriteLine(row["RecType"]);
                //    Console.WriteLine(row["Recipient"]);
                //    Console.WriteLine(row["Message"]);
                //    Console.WriteLine(row["DTSending"]);
                //    Console.WriteLine(row["RefId"]);
                //    Console.WriteLine(row["RefTable"]);

                //}

                return dataTable;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /**
         *  Send POST message to the given url with the data object 
         **/
        public string sendMsgData(string Url, NameValueCollection Data)
        {
            string responseInString = "";

            using (var wb = new WebClient())
            {
                try
                {
                    // create and send POST query to the web server with
                    // the data, result is stored to response
                    var response = wb.UploadValues(Url, "POST", Data);

                    //decode response from the server
                    responseInString = Encoding.UTF8.GetString(response);
                    //Console.WriteLine(responseInString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return responseInString;

        }
    }
}
