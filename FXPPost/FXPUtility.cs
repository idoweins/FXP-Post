using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace FXPPost
{

    public class FxpUtility : IDisposable
    {

        #region static

        public static Dictionary<string, int> Forums { get; set; }

        static FxpUtility()
        {
            Forums = GetForums();
        }

        private static Dictionary<string, int> GetForums()
        {
            Dictionary<string, int> forums = new Dictionary<string, int>();
            string html = string.Empty;

            using (WebClient webclient = new WebClient())
                html = webclient.DownloadString("http://www.fxp.co.il/archive/index.php");

            string pattern = @"<a href=""http:\/\/www\.fxp\.co\.il\/.+f-(\d+).+"">(.+)<\/a>";
            foreach (Match match in Regex.Matches(html, pattern))
                forums.Add(HttpUtility.HtmlDecode(match.Groups[2].Value.CorrectHebrew()), int.Parse(match.Groups[1].Value));
            return forums;
        }

        #endregion

        public string Name { get; private set; }
        private int UserId { get; set; }
        private bool Disposed { get { return this.UserId == 0; } }
        private string SecurityToken { get; set; }
        private WebClient webclient = new WebClient();


        #region Initialization
        public FxpUtility(string username, string password, EventHandler loginEvent = null)
        {
            try
            {
                Login(username, password);
                this.Name = username;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Login(string username, string password)
        {
            if (this.Disposed)
                throw new ObjectDisposedException("FxpUser");
            NameValueCollection nc = new NameValueCollection();
            nc.Add("vb_login_username", username);
            nc.Add("do", "login");
            using (MD5 md5 = MD5.Create())
            {
                string utf = string.Join(string.Empty, password.Select(sign => (int)sign > 255 ? "&#" + (int)sign + ";" : sign.ToString())).Trim();
                string hashedPassword = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(utf))).Replace("-", "").ToLower();
                nc.Add("vb_login_md5password", hashedPassword);
            }

            string response = Encoding.UTF8.GetString(this.webclient.UploadValues("http://www.fxp.co.il/login.php?do=login", "POST", nc));

            if (response.IndexOf("התחברת בהצלחה") == -1)
                throw new Exception("Invalid username or password");

            SetSecurityToken(response);
            string cookies = this.webclient.ResponseHeaders[HttpResponseHeader.SetCookie];
            this.UserId = int.Parse(Regex.Match(cookies, @"bb_nginxcache=(\d+?);").Groups[1].Value);
            foreach (Match match in Regex.Matches(cookies, "bb.+?;"))
                webclient.Headers["Cookie"] += match.Value;
        }
        #endregion

        #region Destruction

        private void Logout()
        {

            if (this.Disposed)
                throw new ObjectDisposedException("FxpUser");
            string html = webclient.DownloadString("http://www.fxp.co.il").CorrectHebrew();
            string logouturl = "http://www.fxp.co.il/" + HttpUtility.HtmlDecode(Regex.Match(html, @"<a href=""(login\.php\?do=logout.+?)"">").Groups[1].Value);
            webclient.DownloadString(logouturl);

            if (webclient.ResponseHeaders[HttpResponseHeader.SetCookie].IndexOf("deleted") == -1)
                throw new Exception("Logout failed");

        }

        ~FxpUtility()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                try
                {
                    this.Logout();
                }
                finally
                {
                    if (disposing)
                    {
                        this.webclient.Dispose();
                        this.UserId = 0;
                        this.Name = null;
                        this.SecurityToken = null;
                    }
                }
            }
        }
        #endregion

        #region Token Handling
        private void CheckSecurityToken()
        {
            if (string.IsNullOrEmpty(this.SecurityToken) || (this.GetTokenTime() - DateTime.Now) > new TimeSpan(1, 0, 0))
                SetSecurityToken();
        }
        private DateTime GetTokenTime()
        {
            return new DateTime(1970, 1, 1).AddSeconds(int.Parse(Regex.Match(this.SecurityToken, @"(\d+)-").Groups[1].Value));
        }
        private void SetSecurityToken()
        {
            SetSecurityToken(webclient.DownloadString("http://www.fxp.co.il"));
        }
        private void SetSecurityToken(string html)
        {
            try
            {
                this.SecurityToken = Regex.Match(html, @"var SECURITYTOKEN = ""(\d+-.+?)"";", RegexOptions.IgnoreCase).Groups[1].Value;
            }
            catch
            {
                throw new Exception("Security token was not found");
            }
        }
        #endregion

        #region Gets
        public Dictionary<string, string> GetPrefixes(int forumId)
        {
            if (this.Disposed)
                throw new ObjectDisposedException("FxpUser");
            Dictionary<string, string> prefixes = new Dictionary<string, string>();

            string url = "http://www.fxp.co.il/newthread.php?do=newthread&f=" + forumId;


            string html = webclient.DownloadString(url);
            string pattern = @"<option value=""(.+?)"" class="""" >(.+?)<\/option>";

            foreach (Match match in Regex.Matches(html, pattern))
                prefixes.Add(match.Groups[2].Value.CorrectHebrew(), match.Groups[1].Value);

            return prefixes;

        }
        public Dictionary<string, int> GetThreads(int forumId, int page)
        {
            if (this.Disposed)
                throw new ObjectDisposedException("FxpUser");

            Dictionary<string, int> threads = new Dictionary<string, int>();
            string html = webclient.DownloadString("http://www.fxp.co.il/forumdisplay.php?f=" + forumId + "&page=" + page);

            string pattern = @"<a class=""title.*?"" href=""showthread\.php\?t\=(\d+)"" id=""thread_title_\1"">(.+?)<\/a>";

            int count = 0;

            foreach (Match match in Regex.Matches(html, pattern))
                try
                {
                    count = 0;
                    threads.Add(HttpUtility.HtmlDecode(match.Groups[2].Value).CorrectHebrew(), int.Parse(match.Groups[1].Value));
                }
                catch // if  2 topics have the same name
                {
                    threads.Add(HttpUtility.HtmlDecode(match.Groups[2].Value.CorrectHebrew() + "_" + count++).CorrectHebrew(), int.Parse(match.Groups[1].Value));
                }

            return threads;
        }
        #endregion

        #region Posts
        public int PostThread(int forumId, string prefixKey, string subject, string content)
        {
            if (this.Disposed)
                throw new ObjectDisposedException("FxpUser");
            CheckSecurityToken();

            NameValueCollection nc = new NameValueCollection();
            nc.Add("do", "postthread");
            nc.Add("loggedinuser", this.UserId.ToString());
            nc.Add("f", forumId.ToString());
            nc.Add("prefixid", prefixKey);
            nc.Add("subject", subject);
            nc.Add("message", content);
            nc.Add("securitytoken", this.SecurityToken);

            string response = Encoding.UTF8.GetString(webclient.UploadValues("http://www.fxp.co.il/newthread.php?do=postthread&f=" + forumId, "POST", nc));
            int threadId;
            if (!int.TryParse(Regex.Match(response, @"content=""http:\/\/www\.fxp\.co\.il\/showthread\.php\?t=(\d+)""").Groups[1].Value, out threadId))
                throw GetResponseException(response);
            return threadId;
        }
        public void PostComment(int threadId, string content)
        {
            if (this.Disposed)
                throw new ObjectDisposedException("FxpUser");
            CheckSecurityToken();

            NameValueCollection nc = new NameValueCollection();
            nc.Add("do", "postreply");
            nc.Add("loggedinuser", this.UserId.ToString());
            nc.Add("t", threadId.ToString());
            nc.Add("message", content);
            nc.Add("securitytoken", this.SecurityToken);

            string response = Encoding.UTF8.GetString(webclient.UploadValues("http://www.fxp.co.il/newreply.php?do=postreply&t=" + threadId, "POST", nc));
            if (response.IndexOf(content) == -1 || response.IndexOf(threadId.ToString()) == -1)
                throw GetResponseException(response);
        }

        private Exception GetResponseException(string response)
        {
            if (response == "error")
                return new Exception("Fxp server has been overloaded");

            string form = Regex.Match(response, @"<form class\=""block vbform"".*>.*(\n.*)*?<\/form>").Value; //getting the message form
            form = form.Replace("\n", "").Replace("\t", "").Replace("\r", "");
            string reformatted = Regex.Replace(Regex.Replace(form, @"<( *\/ *)?br( *\/ *)?>", "\n"), "<.+?>", ""); //handling html tags
            reformatted = reformatted.Replace("הודעת מערכת", "");

            if (string.IsNullOrEmpty(reformatted))
                reformatted = "An unknown error occurred";

            return new Exception(reformatted);
        }
        #endregion


    }

    public static class Extensions
    {
        public static string CorrectHebrew(this string self)
        {
            return Encoding.UTF8.GetString(Encoding.GetEncoding("Windows-1255").GetBytes(self));
        }
    }
}
