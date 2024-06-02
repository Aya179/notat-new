using System;
using System.Collections.Generic;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using NotataSub.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Text;


namespace NotataSub.Controllers
{
    public class NotificationsController : Controller
    {

        private readonly FirebaseMessaging messaging;
        StudyHubContext context;
        private IConfiguration _config;

        public NotificationsController(StudyHubContext context, IConfiguration configuration)
        {
            try
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "newtakke.json";
                System.Diagnostics.Debug.WriteLine("file path " + filepath);
                AppOptions appOp = new AppOptions() { Credential = GoogleCredential.FromFile(filepath) };
                FirebaseApp app;
                if (FirebaseApp.DefaultInstance == null)
                    app = FirebaseApp.Create(appOp);
                else
                    app = FirebaseApp.GetInstance(FirebaseApp.DefaultInstance.Name);
                messaging = FirebaseMessaging.GetMessaging(app);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Firebase creation error" + ex.Message);
            }
            this.context = context;
            _config = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> sendNotification(string token, string[] data)
        {
            try

            {
                StreamWriter witer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "errore.log", true);
                witer.WriteLine(DateTime.Now.ToString() + " : token : " + token);
                witer.WriteLine(DateTime.Now.ToString() + " : data : " + data);
                witer.Close();
                string[] details = data;
                var message = new Message()
                {
                    Data = new Dictionary<string, string>()
                    {
                        ["client"] = details[0] + "," + details[1],
                        ["source"] = details[2],
                        ["sourceDetails"] = details[5],
                        ["destination"] = details[3],
                        ["orderTime"] = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString(),
                        ["orderType"] = "now",
                        ["destinationDetails"] = details[6],
                        ["orderId"] = details[4],
                        ["click_action"] = "FLUTTER_NOTIFICATION_CLICK"
                    },
                    Notification = new FirebaseAdmin.Messaging.Notification
                    {
                        Title = "طلب جديد",
                        Body = data[0] + "#" + data[1] + "#" + data[2] + "#" + data[3] +
                        "#" + data[5] + "#" + data[6]
                    },


                  

                    Token = token,
                };



                // Send a message to the device corresponding to the provided
                // registration token.
                string response = await messaging.SendAsync(message);
                System.Diagnostics.Debug.WriteLine("Firebase response" + response);

                return Ok(new { ok = "send" });
            }
            catch (Exception ex)
            {
                StreamWriter witer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "errore.log", true);
                witer.WriteLine(DateTime.Now.ToString() + " : Error" + ex.Message);
                witer.Close();
                return Ok(new { notvalid = "true" });
            }
        }

    }
}
