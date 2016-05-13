using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace GameCore.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookmarkService" in both code and config file together.
    [ServiceContract]
    public interface IBookmarkService
    {
        [OperationContract]
        void DoWork();

        [WebGet(UriTemplate = "?tag={tag}")]
        [OperationContract]
        Bookmarks GetPublicBookmarks(string tag);
        [WebGet(UriTemplate = "{username}?tag={tag}")]
        [OperationContract]
        Bookmarks GetUserPublicBookmarks(string username, string tag);
        [WebGet(UriTemplate = "users/{username}/bookmarks?tag={tag}")]
        [OperationContract]
        Bookmarks GetUserBookmarks(string username, string tag);
        [WebGet(UriTemplate = "users/{username}/profile")]
        [OperationContract]
        UserProfile GetUserProfile(string username);
        [WebGet(UriTemplate = "users/{username}")]
        [OperationContract]
        User GetUser(string username);
        [WebGet(ResponseFormat = WebMessageFormat.Json,UriTemplate = "users/{username}?format=json")]
        [OperationContract]
        User GetUserAsJson(string username);
        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}")]
        [OperationContract]
        void PutUser(string username, User user);
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, UriTemplate = "users/{username}?format=json")]
        [OperationContract]
        void PutUserAsJson(string username, User user);
        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}")]
        [OperationContract]
        void DeleteUser(string username);
        [WebGet(UriTemplate = "users/{username}/bookmarks/{id}")]
        [OperationContract]
        Bookmark GetBookmark(string username, string id);
        [WebInvoke(Method = "POST", UriTemplate = "users/{username}/bookmarks")]
        [OperationContract]
        void PostBookmark(string username, Bookmark newValue);
        [WebInvoke(Method = "PUT", UriTemplate = "users/{username}/bookmarks/{id}")]
        [OperationContract]
        void PutBookmark(string username, string id, Bookmark bm);
        [WebInvoke(Method = "DELETE", UriTemplate = "users/{username}/bookmarks/{id}")]
        [OperationContract]
        void DeleteBookmark(string username, string id);
    }

    public class User
    {
        public Uri Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Bookmarks { get; set; }
    }

    public class UserProfile
    {
        public UserProfile(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Bookmarks = user.Bookmarks;
        }

        public Uri Id { get; set; }
        public string Name { get; set; }
        public Uri Bookmarks { get; set; }
    }

    public class Bookmark
    {
        public Uri Id { get; set; }
        public string Title { get; set; }
        public Uri Url { get; set; }
        public string User { get; set; }
        public Uri UserLink { get; set; }
        public string Tags { get; set; }
        public bool Public { get; set; }
        public DateTime LastModified { get; set; }
    }

    [CollectionDataContract]
    public class Bookmarks : List<Bookmark>
    {
        public Bookmarks() { }
        public Bookmarks(List<Bookmark> bookmarks) : base(bookmarks) { }
    }
}
