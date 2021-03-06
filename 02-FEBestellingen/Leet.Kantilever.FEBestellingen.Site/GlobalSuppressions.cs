//Zie: Daniel
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant")]

//Namespaces passen we niet aan.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Leet.Kantilever.FEBestellingen.Site.Controllers")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Leet.Kantilever.FEBestellingen.Site")]


//Gaan over generated code.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.MvcApplication.#Application_Start()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Scope = "type", Target = "Leet.Kantilever.FEBestellingen.Site.BundleConfig")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Scope = "type", Target = "Leet.Kantilever.FEBestellingen.Site.RouteConfig")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Scope = "type", Target = "Leet.Kantilever.FEBestellingen.Site.FilterConfig")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.BundleConfig.#RegisterBundles(System.Web.Optimization.BundleCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.FilterConfig.#RegisterGlobalFilters(System.Web.Mvc.GlobalFilterCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Decimal.Parse(System.String)", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.BtwHelper.#GetCurrentBtw()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.ViewModels.BestellingsRegelVM.#PrijsInclusiefBtw")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.ViewModels.BestellingsRegelVM.#Totaalprijs")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.ViewModels.BestellingVM.#Totaalprijs")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.ViewModels.BestellingVM.#TotaalprijsInclusiefBtw")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.Mapper.#MapBestellingToVMList(minorcase3pcsbestellen.v1.schema.BestellingCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface", Scope = "type", Target = "Leet.Kantilever.FEWebwinkel.Site.TariefCollection", Justification = "ConfigSection collection. Werkt niet anders.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Leet.Kantilever.FEBestellingen.Site.ViewModels")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Leet.Kantilever.FEWebwinkel.Site")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.ViewModels.BestellingVM.#.ctor(System.Collections.Generic.List`1<Leet.Kantilever.FEBestellingen.Site.ViewModels.BestellingsregelVM>)", Justification = "List is nodig voor de AddRange methode.")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "Leet.Kantilever.FEBestellingen.Site.ViewModels.BestellingVM.#Bestellingsregels", Justification = "List is nodig voor de AddRange methode.")]

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

