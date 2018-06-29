namespace OpenSports.GroupsApi
{
    using HtmlAgilityPack;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OpenSportsGroup
    {
        private readonly string group;
        public Details Details { get; private set; }
        public DateTime LastUpdated { get; }
        public IList<Event> Events { get; private set; }

        public OpenSportsGroup(string group)
        {
            this.group = group ?? throw new ArgumentNullException(nameof(group));

            var baseUrl = "https://opensports.net";
            var web = new HtmlWeb();
            WindowData windowData;
            HtmlDocument htmlDoc;
            string script;
            string json;
            HtmlDocument groupDoc = web.Load($"{baseUrl}/{group}");


            try
            {
                htmlDoc = web.Load($"{baseUrl}/{group}/events");
                script = htmlDoc.DocumentNode.SelectSingleNode("/html/body/script[1]").InnerText;
                json = script?.Remove(startIndex: script.LastIndexOf(';')).Remove(startIndex: 0, count: 14);
                windowData = JsonConvert.DeserializeObject<WindowData>(value: json);

                this.LastUpdated = DateTime.Now;
                this.Events = windowData?.GroupDetail?.Group?.FirstOrDefault()?.Schedule?.Events;
                this.Details = windowData?.GroupDetail?.Group?.FirstOrDefault()?.Details;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Admin
    {

        //[JsonProperty("userID")]
        //public int UserID { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }
    }

    public class TopUser
    {

        //[JsonProperty("userID")]
        //public int UserID { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("gamesAttendedCount")]
        public int GamesAttendedCount { get; set; }
    }

    public class GamePhoto
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("postID")]
        public int PostID { get; set; }

        [JsonProperty("userID")]
        public int UserID { get; set; }

        [JsonProperty("aliasID")]
        public string AliasID { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }
    }

    public class GameReview
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("userID")]
        public int UserID { get; set; }

        [JsonProperty("aliasID")]
        public string AliasID { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }
    }

    public class Details
    {

        [JsonProperty("aliasID")]
        public string AliasID { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("admins")]
        public IList<Admin> Admins { get; set; }

        [JsonProperty("sports")]
        public IList<int> Sports { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("privacy")]
        public int Privacy { get; set; }

        [JsonProperty("website")]
        public object Website { get; set; }

        [JsonProperty("zipCode")]
        public object ZipCode { get; set; }

        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty("isUnique")]
        public bool IsUnique { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("parentID")]
        public object ParentID { get; set; }

        [JsonProperty("photoURL")]
        public string PhotoURL { get; set; }

        [JsonProperty("topUsers")]
        public IList<TopUser> TopUsers { get; set; }

        [JsonProperty("waiverID")]
        public int WaiverID { get; set; }

        [JsonProperty("creatorID")]
        public int CreatorID { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("gamePhotos")]
        public IList<GamePhoto> GamePhotos { get; set; }

        [JsonProperty("gamesCount")]
        public int GamesCount { get; set; }

        [JsonProperty("usersCount")]
        public int UsersCount { get; set; }

        [JsonProperty("childGroups")]
        public object ChildGroups { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("gameReviews")]
        public IList<GameReview> GameReviews { get; set; }

        [JsonProperty("backgroundURL")]
        public string BackgroundURL { get; set; }

        [JsonProperty("gamesReviewCount")]
        public int GamesReviewCount { get; set; }

        [JsonProperty("gamesReviewAverage")]
        public double GamesReviewAverage { get; set; }
    }

    public class Schedule
    {

        [JsonProperty("list")]
        public IList<Event> Events { get; set; }
    }

    public class Group
    {

        [JsonProperty("details")]
        public Details Details { get; set; }

        [JsonProperty("schedule")]
        public Schedule Schedule { get; set; }
    }

    public class GroupDetail
    {

        [JsonProperty("list")]
        public IList<Group> Group { get; set; }
    }

    public class Latlng
    {

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public class Place
    {

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("latlng")]
        public Latlng Latlng { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class Waitlist
    {

        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class TicketsSummary
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("quantitySold")]
        public int QuantitySold { get; set; }

        [JsonProperty("quantityTotal")]
        public int QuantityTotal { get; set; }

        [JsonProperty("quantityRequested")]
        public int QuantityRequested { get; set; }
    }

    public class AttendeesGoing
    {

        [JsonProperty("userID")]
        public int? UserID { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }
    }

    public class Event
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("statusOverride")]
        public int StatusOverride { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("headerMediaURL")]
        public string HeaderMediaURL { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }

        [JsonProperty("media")]
        public object Media { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("facilityID")]
        public object FacilityID { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("isPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty("ticketsRequireApproval")]
        public bool TicketsRequireApproval { get; set; }

        [JsonProperty("attendeesCanInvite")]
        public object AttendeesCanInvite { get; set; }

        [JsonProperty("creatorGroupID")]
        public int CreatorGroupID { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("creatorID")]
        public int CreatorID { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("typeID")]
        public int TypeID { get; set; }

        [JsonProperty("sportID")]
        public int SportID { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ticketsSummary")]
        public IList<TicketsSummary> TicketsSummary { get; set; }

        [JsonProperty("requireInAppPayment")]
        public bool RequireInAppPayment { get; set; }

        //[JsonProperty("data")]
        //public  Data { get; set; }

        [JsonProperty("tags")]
        public object Tags { get; set; }

        [JsonProperty("minAttendees")]
        public object MinAttendees { get; set; }

        [JsonProperty("maxAttendees")]
        public int MaxAttendees { get; set; }

        [JsonProperty("aliasID")]
        public string AliasID { get; set; }

        [JsonProperty("killTime")]
        public object KillTime { get; set; }

        [JsonProperty("killWarningTime")]
        public object KillWarningTime { get; set; }

        [JsonProperty("attendeesGoing")]
        public IList<AttendeesGoing> AttendeesGoing { get; set; }

        [JsonProperty("going")]
        public object Going { get; set; }

        [JsonProperty("requested")]
        public object Requested { get; set; }

        [JsonProperty("invited")]
        public object Invited { get; set; }

        [JsonProperty("waitlist")]
        public Waitlist Waitlist { get; set; }
    }

    public class WindowData
    {

        [JsonProperty("groupDetail")]
        public GroupDetail GroupDetail { get; set; }
    }

}
