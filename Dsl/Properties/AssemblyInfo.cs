#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"Maxsys")]
[assembly: AssemblyProduct(@"VisualLAL")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the DslPackage assembly
//
[assembly: InternalsVisibleTo(@"Maxsys.VisualLAL.DslPackage, PublicKey=00240000048000009400000006020000002400005253413100040000010001000D3B86404FC80EF39A66E5E956CFD468E4DFD6A3A6F9E0F7F138A0D6B610559AC4A193AC2A4B6F760AD7ADCBC9AE029FC6AC22E59A4E536E46944A58B1AB2CFA666FD23F6620656530A9651EED4C0FDA064B618FC19550A364D5A19A1F4CF7BF8C10B8EBC057D13CBEDE60129D1058E8B9BF7BE66AA3CDBE78925A98C278BEA0")]