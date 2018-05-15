using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp3
{
    [Serializable]
    class IncidentDisposition
    {
        public IncidentDisposition() { }
        public IncidentDisposition(string tenantName, IncidentDispositionRef[] incidentDispositionRef)
        {
            this.tenantName = tenantName;
            this.incidentDispositionRef = incidentDispositionRef;
        }

        public string tenantName { get; set; }
        public IncidentDispositionRef[] incidentDispositionRef { get; set; }
    }
}
