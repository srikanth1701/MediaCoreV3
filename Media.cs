using System;

namespace MediaCore
{
    public class Media
    {
        public string Genre{get;set;}
        public string[] Keywords {get;set;}

        public Videos[] Videos{get;set;}

        public string Summary { get; set; }
    }
}
public class Videos
{
    public string  videoId {get;set;}
    public string videoUrl{get;set;}
    public string[] likedUsers{get;set;}
}