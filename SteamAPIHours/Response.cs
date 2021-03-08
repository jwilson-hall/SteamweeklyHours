using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamAPIHours
{
    class Response
    {
        public int total_count { get; set; }
        public List<Game> games  { get; set; }
    }
}
