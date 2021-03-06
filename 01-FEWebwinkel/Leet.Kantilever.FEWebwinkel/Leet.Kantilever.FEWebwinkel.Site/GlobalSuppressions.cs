//Op aanraden van Daniel genegeerd. 
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant")]

//Het is veiliger om namespaces niet te mergen of anders aan te passen. 
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Leet.Kantilever.FEWebwinkel.Site.ViewModels")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "Leet.Kantilever.FEWebwinkel.Site.Controllers")]

//Zie "when to surpress" bij CA1002
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Mapper.#MapToProductVMList(Kantilever.BsCatalogusbeheer.Product.V1.ProductCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.ViewModels.WinkelmandVM.#Producten")]

//Er worden later items aan de collection toegevoegd dus readonly is geen goed idee.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.ViewModels.WinkelmandVM.#Producten")]

//De applicatie zal alleen in Nederland draaien, ondersteuning voor verschillende
// regios is niet nuttig.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Decimal.Parse(System.String)", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.BtwHelper.#GetCurrentBtw()")]

//Als ik deze doe werkt de code niet meer goed.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.BtwConfigSection.#Tarieven")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1010:CollectionsShouldImplementGenericInterface", Scope = "type", Target = "Leet.Kantilever.FEWebwinkel.Site.TariefCollection")]

//Gaan allemaal over generated code, negeren.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Startup.#ConfigureAuth(Owin.IAppBuilder)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.MvcApplication.#Application_Start()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "type", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.LoginViewModel")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "type", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.ExternalLoginConfirmationViewModel")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "type", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.ExternalLoginListViewModel")]
//Een spellingsfout in generated code. Als je dit in de dictionary zou zetten, zou het genegeerd worden als je het ook zelf verkeerd doet, dus surpressed.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Auth", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Startup.#ConfigureAuth(Owin.IAppBuilder)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.ApplicationSignInManager.#Create(Microsoft.AspNet.Identity.Owin.IdentityFactoryOptions`1<Leet.Kantilever.FEWebwinkel.Site.ApplicationSignInManager>,Microsoft.Owin.IOwinContext)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.FilterConfig.#RegisterGlobalFilters(System.Web.Mvc.GlobalFilterCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.BundleConfig.#RegisterBundles(System.Web.Optimization.BundleCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.ApplicationUserManager.#Create(Microsoft.AspNet.Identity.Owin.IdentityFactoryOptions`1<Leet.Kantilever.FEWebwinkel.Site.ApplicationUserManager>,Microsoft.Owin.IOwinContext)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.ApplicationSignInManager.#CreateUserIdentityAsync(Leet.Kantilever.FEWebwinkel.Site.Models.ApplicationUser)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.VerifyCodeViewModel.#ReturnUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.SendCodeViewModel.#ReturnUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.SendCodeViewModel.#Providers")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.ExternalLoginListViewModel.#ReturnUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Scope = "type", Target = "Leet.Kantilever.FEWebwinkel.Site.RouteConfig")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Scope = "type", Target = "Leet.Kantilever.FEWebwinkel.Site.FilterConfig")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Scope = "type", Target = "Leet.Kantilever.FEWebwinkel.Site.BundleConfig")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.IndexViewModel.#Logins")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.ConfigureTwoFactorViewModel.#Providers")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.ManageLoginsViewModel.#CurrentLogins")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.ApplicationUserManager.#Create(Microsoft.AspNet.Identity.Owin.IdentityFactoryOptions`1<Leet.Kantilever.FEWebwinkel.Site.ApplicationUserManager>,Microsoft.Owin.IOwinContext)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Scope = "member", Target = "Leet.Kantilever.FEWebwinkel.Site.Models.ManageLoginsViewModel.#OtherLogins")]







// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

