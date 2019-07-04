using System;
using System.Collections.Generic;
using System.Text;

namespace PokerPlanning.Models
{
    public class RoomModel
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public bool Locked { get; set; } = false;
    }
}
