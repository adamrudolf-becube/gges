using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;

namespace fileProcess
{
    class Program
    {
        static void Main()
        {
            //string filename = "avg-tweet-count_VS_follow-deg";
            //string filename = "avg-tweet-count_VS_mention-deg";
            //string filename = "tweet-count_VS_follow-deg";
            string filename = "tweet-count_VS_mention-deg";
            rptToTuple hejj1 = new rptToTuple();
            hejj1.run(filename);
        }
    }
}