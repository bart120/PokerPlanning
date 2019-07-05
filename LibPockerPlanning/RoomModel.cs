using System;

namespace LibPockerPlanning
{
    public class RoomModel
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public bool Locked { get; set; } = false;
    }
}
