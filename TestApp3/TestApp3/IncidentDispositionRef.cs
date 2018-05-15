using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp3
{
    [Serializable]
    class IncidentDispositionRef
    {
        public IncidentDispositionRef() { }
        public IncidentDispositionRef(string name, string description, bool automaticToClose)
        {
            this.name = name;
            this.description = description;
            this.automaticToClose = automaticToClose;
        }

        public string name { get; set; }
        public string description { get; set; }
        public bool automaticToClose { get; set; }

    }
}
