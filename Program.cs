using RESTCountries.Services;

// Get all countries
Console.WriteLine("... All counties ...");
var countries = await RESTCountriesAPI.GetAllCountriesAsync();
countries.ForEach(country => Console.WriteLine(country.Name));


// Search by regional bloc
Console.WriteLine("... All counties in African Union ...");
var countriesInAU = await RESTCountriesAPI.GetCountriesByRegionalBlocAsync("AU"); // "AU" stands for "African Union"
countriesInAU.ForEach(country => Console.WriteLine(country.Name));


// Search by ISO 4217 currency code
Console.WriteLine("... Countries using the currency Euro ...");
var countriesUsingEur = await RESTCountriesAPI.GetCountriesByCurrencyCodeAsync("eur");
countriesUsingEur.ForEach(country => Console.WriteLine(country.Name));


// Names of countries in Spanish language
Console.WriteLine("... Countries name using Spanish language ...");
var allCountries = await RESTCountriesAPI.GetAllCountriesAsync();
List<string> countriesInSpanish = allCountries.Select(c => c.Translations.Fr).ToList();
countriesInSpanish.ForEach(country => Console.WriteLine(country));

// Name of Europe's countries in French language
Console.WriteLine("... Europe counties name in French language ...");
var europeCountries = countries.Where(c => c.Region.Equals("Europe")).OrderBy(c => c.Name).ToList(); ;
List<string> europeCountriesInFrench = europeCountries.Select(c => c.Translations.Fr).ToList();
europeCountriesInFrench.ForEach(country => Console.WriteLine(country));