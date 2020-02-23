using System.Collections.Generic;

namespace Client.MatchTables
{
    public class MatchTableResponse
    {
        public List<MatchItem> Added { get; set; } = new List<MatchItem>();
        public List<MatchItem> Removed { get; set; } = new List<MatchItem>();
        public List<MatchItem> Changes { get; set; } = new List<MatchItem>();
    }
}