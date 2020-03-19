using System.Collections.Generic;

namespace Brukerfeil.Enode.Common
{
    public class ApiDict
    {
        public Dictionary<string, Apis> Dictionary { get; set; }
        public Apis _GeckoAPIs = new Apis() { ElementsApi = "MASTER_SQL", DifiApi = "http://svc01common.elements-ecm.no:9093" };
        public Apis _SikriAPIs = new Apis() { ElementsApi = "MASTER_ORA", DifiApi = "http://svc01common.elements-ecm.no:9095" };


        public ApiDict()
        {
            Dictionary = new Dictionary<string, Apis>();
            Dictionary.Add("922308055", _SikriAPIs);
            Dictionary.Add("989778471", _GeckoAPIs);
        }
    }
}
