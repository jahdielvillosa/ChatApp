using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
    /**
     *  Chathandler
     *  Process the chat service which onnects to the chat server 
     * 
     */
    class ChatHandler
    {
        
        JsonHandler webService = new JsonHandler();           //initialize a json handler to process GET/POST web services
        public string baseUrl = "http://localhost:54314/";    // url address of the server

        /*
         * Send GET method to the server to acquire
         * the number of unread messages of the admin
         */
        public DataTable getMessagesCount(){
            if (baseUrl + "chatService.asmx/getUnreadMsg" != null)
            {

                // For debugging
                Console.WriteLine("GET MESSAGES");
               // Console.WriteLine(webService.Getcontent("http://localhost:54314/chatService.asmx/getUnreadMsg").ToString());

                //get the number of unread messages from the server
                return webService.Getcontent(baseUrl + "chatService.asmx/getUnreadMsg");
            }else
            {
                //create table
                DataTable Dt = new DataTable("Result");
                Dt.Columns.Add("Count", typeof(int));

                Dt.Rows.Add(0);
                /*
                DataSet ds = new DataSet();
                ds.Tables.Add(Dt);
                ds.DataSetName = "Result";
                */
                return Dt;
            }
        }

    }
}
