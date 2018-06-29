using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //initialize counters and flags
        bool viewed = false;
        int currentCount = 0;
        int prevCount = 0;


        private void Dismisslabel_Click(object sender, EventArgs e)
        {
            //When Dimiss Labael is clicked
            this.WindowState = FormWindowState.Minimized;
            viewed = true;

            //check if the current notification state is minimized
            if (this.WindowState == FormWindowState.Minimized)
            {
                //minimize notification
                this.Visible = false;

                //set display notification icon
                notifyIcon1.Visible = true;

                //set viewed flag to true
                viewed = true;

                //update counter 
                prevCount = currentCount;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Open notification when the notification icon
            //is clicked by the user
            FormLocation();
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set initial values for the notification count
            currentCount = 0;
            prevCount = 0;

            //initialize form location and border style
            FormLocation();

            //Minimize Notification when loaded
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
        }


        //Timer 
        private void timer1_Tick(object sender, EventArgs e)
        {
            //pool request from the database
            ChatHandler chatmsg = new ChatHandler();


            //get list of new messages
            DataTable MessageList = chatmsg.getMessagesCount();
            try
            {

           
                if (MessageList.AsEnumerable().ToList() == null)
                {
                    //convert datasource to list
                    List<DataRow> Messagelist = MessageList.AsEnumerable().ToList();
                //error !!!!!!!!!!!!!!!!!!!!


                //access the Messagelist object
                foreach (DataRow row in MessageList.Rows)
                {
                    // flags
                    Console.WriteLine("viewed: " + viewed);
                    Console.WriteLine("prev: " + prevCount);
                    Console.WriteLine("current: " + currentCount);

                    //get current message count from json object array
                    currentCount = int.Parse( row["Count"].ToString());
               
                    //update text in the notification
                    NotifTitle.Text   = "Notification Update";
                    NotifContent.Text = "You have " + row["Count"].ToString() + " unread messages. ";
                
                    //check if the there are notifcations not read AND 
                    //check if the user have clicked the notification popup
                    if (currentCount > 0 && viewed == false)
                    {
                        //display the notification to the screen
                        this.Visible = true;
                        this.WindowState = FormWindowState.Normal;
                    }

                    //check if the previous opened count is equal to current count
                    //if there are new notifications (current count), check if
                    //it is equal to the prevCount (old notifications), 
                    if (currentCount == prevCount)
                    {
                        //set viewed to true (viewed) if there
                        //are notifications unread but viewed by the user
                        viewed = true;
                    }
                    else
                    {
                        //set viewed to flase (not viewed) if there
                        //are new notifications
                        viewed = false;
                    }

                }

                }
                else
                {
                    //no notification or error in connecting to db

                    //update text in the notification
                    NotifTitle.Text = "Notification Update";
                    NotifContent.Text = "Unable to connect to the server.";

                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;

                }//end of else

            }catch (Exception ex){
                //no notification or error in connecting to db

                //update text in the notification
                NotifTitle.Text = "Notification Update";
                NotifContent.Text = "Unable to connect to the server.";

                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            //open notification on browser
            //when the body of notification is clicked
            openNotification();
        }

        private void NotifContent_Click(object sender, EventArgs e)
        {
            //open notification on browser
            //when the content is clicked
            openNotification();
        }

        private void NotifTitle_Click(object sender, EventArgs e)
        {
            //open notification on browser
            //when the notification title is clicked
            openNotification();
        }


        // Self Defined Functions 
        private void FormLocation()
        {
            //remove form border
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
            //get screen size
            Rectangle workingArea = Screen.GetWorkingArea(this);

            //set notification coordinatest to bottom right
            this.Location = new Point(workingArea.Right - 360,
                                      workingArea.Bottom - 110);
        }

        //Open notification 
        private void openNotification()
        {
            //stop timer to stop checking for new updates
            //prevents new pop ups with the same content
            timer1.Stop();

            //set viewed counter which flags that the 
            //new content is viewed by the user
            prevCount = currentCount;
            
            //minimize notification
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;

            //to get the url 
            ChatHandler chat = new ChatHandler();

            //open the browser with address to the site chats url  
            ProcessStartInfo sInfo = new ProcessStartInfo(chat.baseUrl + "Chats");
            Process.Start(sInfo);

            //set flag to viewed by the user
            viewed = true;

            //resume timer to check for new messages
            timer1.Start();
        }

        private void Dismisslabel_MouseHover(object sender, EventArgs e)
        {
            Dismisslabel.ForeColor = Color.FromArgb(22, 152, 239);
        }

        private void Dismisslabel_MouseLeave(object sender, EventArgs e)
        {

            Dismisslabel.ForeColor = Color.DarkGray;
        }
    }
}
