using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using heap = C5;

namespace CodingChallenge
{

    class Program
    {


        static void Main(string[] args)
        {
            // getUserTransaction(3, "debit", "022019");
            // var res = compareStrings("one", "two", "three");
            // var socks = new int[]{10, 20, 20, 10, 10, 30, 50, 10, 20};
            // var pairs = sockMerchant(9, socks);
            // var valleys = countingValleys(8, "UDDDUDUU");
            // var jumps = jumpingOnClouds(new int[] { 0, 0, 0, 1, 0, 0 });
            // var maxSpend = getMoneySpent(new int[] { 4 }, new int[] { 5}, 5);
            // var tomakeAnagram = makeAnagram("cde", "abc");
            //var longest = LengthOfLongestSubstring("clement");
            //string validity = isValid("aabbcd");
            //var charCounts = new Dictionary<char, int>();
            //var validit = "seyisssty 8 1 4";
            //var sep = new string[] { " " };
            //var subs = validit.Split(sep, 2, StringSplitOptions.None);
            //Console.WriteLine(subs);

            //var newt = new LinkedList<int>();
            //var heap = new heap.IntervalHeap<int>();


            //for (int i = 0; i < validit.Length; i++)
            //{
            //    if (charCounts[validit.ElementAt(i)] == 1)
            //    {
            //        Console.WriteLine($"first non repeat {i}");
            //    }
            //}
            //Data data = new Data(5);
            //WeakReference reference = new WeakReference(data);

            var stack = new Stack<char>();
            var luist = new List<int>();
            luist.AddRange(new int[] { 5, 4, 6, 7, });
            Console.WriteLine(luist.Count());

            //getUserTransaction(1, "debit", "051993");
            getnumberofGoalsTransaction("Manchester United", 2013);



            //var sets = new HashSet<int>();
            //sets.Add(4);
            //sets.Add(4);
            //var arr = new int[] { 1, 2, 3, 4, };

            //var charCount = new Dictionary<char, int>();
            //charCount.Add('s', 0);
            //charCount.Add('e', 3);
            //charCount.Add('y', 1);
            //charCount.Add('i', 2);
            //var testString = "this is just a simple text string";
            //string[] words = testString.Split(' ');
            //var result = words.Where(w => "ts".All(w.Contains));
            //var test = IsAnagram("anagram", "nagaram");
            //var listes = new List<int>();
            //listes.Add(1);
            //var maxChar = charCount.FirstOrDefault(kvp => kvp.Value.Equals(charCount.Values.Max()));
            //var numLessThanFreq = from num in charCount.Values.ToList() where num <= 1 select num;
            //var numlesslinq = charCount.Values.Where(nums => nums <= 1);
            //foreach (var num in numlesslinq)
            //{
            //    Console.WriteLine(num);
            //}


            //Console.WriteLine(test);
            Console.ReadLine();
        }

        public static long howManySwaps(List<int> arr)
        {
            var numberOfSwaps = 0;

            var array = arr.ToArray();

            for (var i = 1; i < arr[0]; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    var temp = arr[i];  // assign to temp holder
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    numberOfSwaps++;
                }
            }

            return numberOfSwaps;
        }

        public static List<string> doesCircleExist(List<string> commands)
        {
            var exists = new List<string>();
            foreach(var command in commands)
            {
                var characters = command.ToCharArray();
                if(command.Length == 1 && (characters[0] == 'L' || characters[0] == 'R'))
                {
                    exists.Add("YES");
                }
            }
        Console.WriteLine(commands[0]);
            return exists;
        }

        public static void getnumberofGoalsTransaction(string team, int year)
        {
            int total_number_goals = 0;

            var GoalsAsTeam1 = getnumberofGoalsTeam(team, 1, year);
            var GoalsAsTeam2 = getnumberofGoalsTeam(team, 2, year);
            total_number_goals = GoalsAsTeam1 + GoalsAsTeam2;
            Console.WriteLine($"Total goals from {team} in {year} is {total_number_goals}");
        }

        public static int getnumberofGoalsTeam(string team, int teamNumber, int year)
        {
            int total_number_goals = 0;
            string json = "";

            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://jsonmock.hackerrank.com/api/football_matches?year=" + year + $"&team{teamNumber}=" + team);
            }
            dynamic teamData = JsonConvert.DeserializeObject(json);
            var totalNumberOfPages = (int)teamData.total_pages;

            total_number_goals += sumNumberOfGoals(teamData.data, teamNumber);

            if (totalNumberOfPages > 1)
            {
                for (var page = 2; page <= totalNumberOfPages; page++)
                {
                    using (WebClient wc = new WebClient())
                    {
                        json = wc.DownloadString("https://jsonmock.hackerrank.com/api/football_matches?year=" + year + $"&team{teamNumber}=" + team + "&page=" + page);
                    }
                    dynamic teamDataPages = JsonConvert.DeserializeObject(json);
                    total_number_goals += sumNumberOfGoals(teamDataPages.data, teamNumber);

                }
            }
           
            return total_number_goals;
        }


        private static int sumNumberOfGoals(dynamic teamData, int teamNumber)
        {
            var numberOfGoals = 0;
            foreach (var entry in teamData)
            {
                numberOfGoals += teamNumber == 1 ? (int)entry.team1goals : (int)entry.team2goals;
            }
            return numberOfGoals;
        }



        public static void getUserTransaction(int uid, string txnType, string monthYear)
        {
            string json = "";
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://jsonmock.hackerrank.com/api/transactions/search?txnType=" + txnType);
            }
            dynamic data = JsonConvert.DeserializeObject(json);
           
            var total_pages = data.total_pages as int?;
            for(var i = 2; i <= total_pages; i++) // as we have page one details from first call
            {


            }
            Console.WriteLine($"Page from data {data.page}");
            Console.WriteLine($"Per Page from data {data.per_page}");
            Console.WriteLine($"Total number of data {data.total}");
            Console.WriteLine($"Total number of pages {data.total_pages}");
            var dataread = data.data;
            foreach (var trans in dataread)
            {
                Console.WriteLine($"id {trans.id}");
                Console.WriteLine($"userId {trans.userId}");
                Console.WriteLine($"userName {trans.userName}");
                Console.WriteLine($"timestamp {trans.timestamp}");
                Console.WriteLine($"txnType {trans.txnType}");
                Console.WriteLine($"amount {trans.amount}");
                Console.WriteLine($"location {trans.location}");
                Console.WriteLine($"location address {trans.location.address}");
                Console.WriteLine($"ip {trans.ip}");
                break;
            }

            dynamic jObj = JObject.Parse(json);

        }



        public static string compareStrings(string firstString, string secondString, string thirdString)
        {
            StringBuilder sortedstring = new StringBuilder();
            var smalleststring = "";
            var biggestvalues = new string[2];

            if (string.Compare(firstString, secondString) == -1)
            {
                if (string.Compare(firstString, thirdString) < 0)
                {
                    smalleststring = firstString;
                    biggestvalues[0] = secondString;
                    biggestvalues[1] = thirdString;
                }
                else
                {
                    smalleststring = thirdString;
                    biggestvalues[0] = firstString;
                    biggestvalues[1] = secondString;
                }

            }
            else
            {
                if (string.Compare(secondString, thirdString) == -1)
                {
                    smalleststring = secondString;
                    biggestvalues[0] = firstString;
                    biggestvalues[1] = thirdString;
                }
                else
                {
                    smalleststring = thirdString;
                    biggestvalues[0] = firstString;
                    biggestvalues[1] = secondString;
                }
            }

            sortedstring.Append(smalleststring);
            if (string.Compare(biggestvalues[0], biggestvalues[1]) == -1)
            {
                sortedstring.Append(biggestvalues[0]);
                sortedstring.Append(biggestvalues[1]);
            }
            else
            {
                sortedstring.Append(biggestvalues[1]);
                sortedstring.Append(biggestvalues[0]);
            }

            return sortedstring.ToString();

        }
        public static int sockMerchant(int n, int[] ar)
        {
            Array.Sort(ar);
            int sockPairs = 0;

            var i = 0;
            while (i < n)
            {
                if (i == n - 1)
                {
                    break;
                }
                if (ar[i] == ar[i + 1])
                {
                    sockPairs++;
                    i += 2;
                }
                else
                {
                    i++;
                }
            }

            return sockPairs;
        }

        /// <summary>Countings the valleys. not fully implemented</summary>
        /// <param name="steps">The steps.</param>
        /// <param name="path">The path.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static int countingValleys(int steps, string path)
        {
            var charArray = path.ToCharArray();
            var noOfValleys = 0;

            for (int i = 0; i < steps;)
            {
                int j = 0;
                int k = 1;
                if (i == steps - 1)
                {
                    break;
                }
                if (charArray[i] == 'D' && charArray[i + 1] == 'D')
                {
                    while (charArray[i + k] == 'D')
                    {
                        k++;
                    }
                    noOfValleys++;
                    i += (k);
                }
                else
                {
                    i++;
                }

            }

            return noOfValleys;
        }

        static int jumpingOnClouds(int[] c)
        {

            var numberOfClouds = c.Length;
            var i = 0;
            var minHop = 1;
            var maxHop = 2;
            int noOfJumps = 0;

            while (i <= (numberOfClouds - maxHop))
            {
                if (c[i] == 0)
                {
                    if ((i + maxHop) >= numberOfClouds)
                    {
                        noOfJumps++;
                        break;
                    }


                    if (c[i + maxHop] == 0)
                    {
                        // update current pos
                        i += maxHop;

                        // update jumps
                        noOfJumps++;
                    }
                    else
                    {
                        i += minHop;
                        noOfJumps++;
                    }
                }
                else
                {
                    i++;
                }
            }

            return noOfJumps;
        }

        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            var maxSpend = -1;
            Array.Sort(keyboards);
            Array.Sort(drives);

            for (int i = drives.Length - 1; i >= 0; i--)
            {
                for (int j = keyboards.Length - 1; j >= 0; j--)
                {
                    var tempMax = drives[i] + keyboards[j];
                    maxSpend = tempMax > maxSpend && tempMax <= b ? tempMax : maxSpend;
                }
            }
            return maxSpend;

        }

        static int makeAnagram(string a, string b)
        {
            var charA = a.ToCharArray();
            var charB = b.ToCharArray();

            var newAnagram = new List<char>();
            for (int i = 0; i < charA.Length; i++)
            {
                for (int j = 0; j < charB.Length; j++)
                {
                    if (charA[i] == charB[j])
                    {
                        newAnagram.Add(charA[i]);
                        charB[j] = '-'; // replace with arbritary value or delete
                        break;
                    }
                }
            }

            var numDeletions = (charA.Length + charB.Length) - (newAnagram.Count * 2);

            return numDeletions;

        }

        static string isValid(string s)
        {
            var isValid = "YES";
            var chars = s.ToCharArray();
            var distinctChars = chars.Distinct();
            var charCount = new Dictionary<char, int>();
            foreach (var character in distinctChars)
            {
                charCount.Add(character, 0);
            }

            // populate number of occurences for each character
            foreach (var key in charCount.Keys.ToList())
            {
                for (var i = 0; i < chars.Length; i++)
                {
                    if (key == chars[i])
                    {
                        charCount[key]++;
                    }
                }
            }

            // check if all occur same number of times
            var values = charCount.Values.Distinct().Count();

            if (values == 1)
            {
                isValid = "YES";
                return isValid;
            }

            // Check if only one item can be removed
            var minVal = charCount.Values.Min();
            var maxVal = charCount.Values.Max();
            var distinctNumberCount = charCount.Values.ToList().Distinct().Count();
            var distinctNumbers = charCount.Values.ToList().Distinct();
            var occurences = charCount.Values.ToArray();
            if (distinctNumberCount > 2)
            {
                isValid = "N0";
                return isValid;
            }

            var freq = 0;
            var prevCount = 0;

            // find most frequent number
            foreach (var num in distinctNumbers)
            {
                var count = 0;
                for (int i = 0; i < occurences.Length; i++)
                {
                    if (num == occurences[i])
                    {
                        count++;
                    }
                }

                if (count > prevCount)
                {
                    freq = num;
                }
                prevCount = count;
            }
            var numLessThanFreq = from num in charCount.Values.ToList() where num < freq select num;
            foreach (var num in charCount.Values.ToList())
            {
                if (num < freq)
                {
                    if (numLessThanFreq.Count() == 1)
                    {
                        isValid = "YES";
                        return isValid;
                    }
                    isValid = "N0";
                    return isValid;
                }
            }

            if ((maxVal - freq) != 1)
            {
                isValid = "N0";
                return isValid;
            }
            return isValid;
        }

        static int[] TwoSum(int[] nums, int target)
        {
            
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    // as only one solution
                    return new int[] { dict[complement], i };
                }
                dict.Add(nums[i], i);
            }
            throw new Exception("No valid combo");

        }

        static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            var set = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                // try to extend the range [i, j]
                if (!set.Contains(s.ElementAt(j)))
                {
                    set.Add(s.ElementAt(j++));
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    set.Remove(s.ElementAt(i++));
                }
            }
            return ans;
        }
        static int MyAtoi(string s)
        {
            int result = 0;
            var trimmed_s = s.TrimStart();
            var signedvalue = '+';
            var read = new StringBuilder();

            switch (trimmed_s.ElementAt(0))
            {
                case '+':
                    signedvalue = '+';
                    break;
                case '-':
                    signedvalue = '-';
                    break;
                default:
                    signedvalue = '+';
                    break;
            }

            for (int i = 0; i < trimmed_s.Length; i++)
            {

            }

            return result;

        }

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            // order the strings and check
            char[] str1 = s.ToCharArray();
            char[] str2 = t.ToCharArray();
            Array.Sort(str1);
            Array.Sort(str2);            
            return str1.SequenceEqual(str2); ;

        }

    }

}
