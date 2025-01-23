using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public interface IJsonSystem
{
    public JObject SetNewGuids(JObject input, string[] valuesToChange);
}
