using System.Net;
using Newtonsoft.Json.Linq;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(year, teamName);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(year, teamName);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(int? year = null, string team1 = null, string team2 = null, int? page = null )
    {
        const string url = "https://jsonmock.hackerrank.com/api/football_matches?";
        var param = new List<string>();
        int totalGols = 0;
        int Page = 1;
        int totalPage = 1;

        if (year != null) { param.Add("year=" + year.ToString()); }
        if (team1 != null) { param.Add("team1=" + team1); }
        if (team2 != null) { param.Add("team2=" + team2); }
        if (page != null) { param.Add("page=" + page.ToString()); Page = page.Value; totalPage = page.Value; }

        var newUrl = url + String.Join("&", param);
        while (Page <= totalPage)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("x-li-format", "json");
                string json = wc.DownloadString(newUrl);

                JObject? _result = JObject.Parse(json);
                totalPage = (int)_result.SelectToken("total_pages");

                JArray data = (JArray)_result.SelectToken("data");

                foreach (var item in data)
                {
                    totalGols += (int)item.SelectToken("team1goals");
                }
                param.Remove("page=" + Page.ToString());
                Page += 1;
                param.Add("page=" + Page.ToString());
            }
            newUrl = url + String.Join("&", param);

        }
        return totalGols;
    }

}