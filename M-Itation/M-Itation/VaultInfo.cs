using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Itation
{
    public class VaultInfo
    {
        public VaultInfo(string name, Guid vaultGuid)
        {
            Name = name;
            VaultGuid = vaultGuid;
        }

        public string Name { get; private set; }

        public Guid VaultGuid { get; private set; }
    }
}
