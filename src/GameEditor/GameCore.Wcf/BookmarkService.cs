using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using GameCore.Wcf.Helpers;

namespace GameCore.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookmarkService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class BookmarkService : IBookmarkService
    {
        private readonly Dictionary<string, User> _users = new Dictionary<string, User>();
        private readonly Dictionary<string, Bookmark> _bookmarks = new Dictionary<string, Bookmark>();

        public Bookmarks GetPublicBookmarks(string tag)
        {
            return _bookmarks.Values.Where(b => b.Public && b.Tags.Contains(tag)) as Bookmarks;
        }

        public Bookmarks GetUserPublicBookmarks(string username, string tag)
        {
            return _bookmarks.Values.Where(b => b.Public && b.User == username && b.Tags.Contains(tag)) as Bookmarks;
        }

        public Bookmarks GetUserBookmarks(string username, string tag)
        {
            return _bookmarks.Values.Where(b => b.User == username && b.Tags.Contains(tag)) as Bookmarks;
        }

        public UserProfile GetUserProfile(string username)
        {
            username = username.ToLower();
            var user = Find(username);
            if (user != null) return new UserProfile(user);
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
            return null;
        }

        public User GetUser(string username)
        {
            username = username.ToLower();
            if (!IsUserAuthorized(username))
            {
                if (WebOperationContext.Current != null)
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return null;
            }
            var user = Find(username);
            if (user != null) return user;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
            return null;
        }

        public User GetUserAsJson(string username)
        {
            throw new NotImplementedException();
        }

        public void PutUser(string username, User user)
        {
            username = username.ToLower();
            User aUser = Find(username);
            if (aUser == null)
            {
                if (WebOperationContext.Current != null)
                    WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(GetUserLink(username));
            }
            else if (!IsUserAuthorized(username))
            {
                if (WebOperationContext.Current != null)
                    WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return;
            }
            user.Id = GetUserLink(username);
            user.Bookmarks = GetUserBookmarksLink(username);
            _users[username] = user;
        }

        public void PutUserAsJson(string username, User user)
        {
            throw new NotImplementedException();
        }

        private Uri GetUserBookmarksLink(string username)
        {
            return new Uri($"http://localhost/users/{username}/bookmarks");
        }

        private bool IsUserAuthorized(string username)
        {
            var ctx = WebOperationContext.Current;
            if (ctx == null) return false;
            var requestUri = ctx.IncomingRequest.UriTemplateMatch.RequestUri.ToString();
            var authorizationHeader = ctx.IncomingRequest.Headers[HttpRequestHeader.Authorization];
            return IsValidUserKey(authorizationHeader, requestUri);
        }

        private bool IsValidUserKey(string key, string urit)
        {
            return true;
            throw new NotImplementedException();
        }

        private Uri GetUserLink(string username)
        {
            return new Uri($"http://localhost/users/{username}");
        }

        private User Find(string username)
        {
            return _users.ContainsKey(username) ? _users[username] : null;
        }

        public void DeleteUser(string username)
        {
            if (_users.ContainsKey(username)) _users.Remove(username);
        }

        public Bookmark GetBookmark(string username, string id)
        {
            if (!_bookmarks.ContainsKey(id)) return null;
            var bookmark = _bookmarks[id];
            return bookmark.User != username ? null : bookmark;
        }

        public void PostBookmark(string username, Bookmark newValue)
        {
            if (_bookmarks.ContainsKey(newValue.Url.ToString())) return;
            newValue.User = username;
            _bookmarks.Add(newValue.Id.ToString(),newValue);
        }

        public void PutBookmark(string username, string id, Bookmark bm)
        {
            if (!_bookmarks.ContainsKey(id)||_bookmarks[id].User!=username) return;
            _bookmarks[id] = bm;
        }

        public void DeleteBookmark(string username, string id)
        {
            if (_bookmarks.ContainsKey(id) && _bookmarks[id].User == username)
                _bookmarks.Remove(id);
        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }

        //    public void ProcessRequest(HttpContext context)
        //    {
        //        Uri uri = context.Request.Url;
        //        // compare URI to resource templates and find match
        //        if (Matches(uri, "{username}?tag={tag}"))
        //        {
        //            // extract variables from URI
        //            Dictionary<string, string> vars =
        //                ExtractVariables(uri, "{username}?tag={tag} ");
        //            string username = vars["username"];
        //            string tag = vars["tag"];
        //            // figure out which HTTP method is being used
        //            switch (context.Request.HttpMethod)
        //            {
        //                // dispatch to internal methods based on URI and HTTP method
        //                // and write the correct response status & entity body
        //                case "GET":
        //                    List<Bookmark> bookmarks = GetBookmarks(username, tag);
        //                    WriteBookmarksToResponse(context.Response, bookmarks);
        //                    SetResponseStatus(context.Response, "200", "OK");
        //                    break;
        //                case "POST":
        //                    Bookmark newBookmark = ReadBookmarkFromRequest(context.Request);
        //                    string id = CreateNewBookmark(username, newBookmark);
        //                    WriteLocationHeader(id);
        //                    SetResponseStatus(context.Response, "201", "Created");
        //                    break;
        //                default:
        //                    SetResponseStatus(context.Response, "405", "Method Not Allowed");
        //                    break;
        //            }
        //        }
        //        if (Matches(uri, "users/{username}/bookmarks/{id}"))
        //        {
        //            // dispatch to internal methods based on URI and HTTP method
        //            // and write the correct response status & entity body
        //            //...
        //        }
        //        //... // match addition URI templates here
        //    }

        //    private void WriteLocationHeader(string id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private string CreateNewBookmark(string username, Bookmark newBookmark)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private Bookmark ReadBookmarkFromRequest(HttpRequest request)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private void SetResponseStatus(HttpResponse response, string p1, string ok)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private void WriteBookmarksToResponse(HttpResponse response, List<Bookmark> bookmarks)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private List<Bookmark> GetBookmarks(string username, string tag)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private Dictionary<string, string> ExtractVariables(Uri uri, string usernameTagTag)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public bool IsReusable { get { return true; } }

        //    private bool Matches(Uri uri, string value)
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}
