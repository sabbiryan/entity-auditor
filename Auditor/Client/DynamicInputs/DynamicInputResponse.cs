using System;
using System.Collections.Generic;
using System.Text;

namespace Client.DynamicInputs
{
    public class DynamicInputResponse
    {
        public Type SourceEntity { get; set; }
        public Type TargetEntity { get; set; }

        public string PrimaryKey { get; set; }
    }
}
