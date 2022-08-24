using System.Collections.Generic;

namespace Client.Models
{
    public class Festival
    {
        public string Name { get; set; }
        public List<Stage> Stages { get; set; }

        public Festival(string name)
        {
            Name = name;
            Stages = new List<Stage>();
        }
    }
}