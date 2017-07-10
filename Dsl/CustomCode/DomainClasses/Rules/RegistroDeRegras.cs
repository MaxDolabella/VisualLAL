using Maxsys.VisualLAL.CustomCode.Rules;
using System;
using System.Collections.Generic;

namespace Maxsys.VisualLAL
{
    // The rule must be registered:  
    public partial class VisualLALDomainModel
    {
        protected override Type[] GetCustomDomainModelTypes()
        {
            var types = new List<Type>(base.GetCustomDomainModelTypes());

            types.Add(typeof(SimboloAddRule));
            types.Add(typeof(SimboloChangeRule));
            types.Add(typeof(SimboloDeleteRule));

            types.Add(typeof(SinonimoAddRule));
            types.Add(typeof(SinonimoChangeRule));
            types.Add(typeof(SinonimoDeleteRule));

            types.Add(typeof(NocaoAddRule));
            types.Add(typeof(NocaoChangeRule));
            types.Add(typeof(NocaoDeleteRule));

            types.Add(typeof(ImpactoAddRule));
            types.Add(typeof(ImpactoChangeRule));
            types.Add(typeof(ImpactoDeleteRule));

            return types.ToArray();
        }
    }
}
