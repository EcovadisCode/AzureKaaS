using System;
using System.Linq;
using Microsoft.Azure.Search;

namespace Kaas1
{
    class Program
    {
        private const string PrimaryApiKey = "primary-api-key-goes-here-:)";
        private const string IndexName = "azuresql-index";
        private const string SearchServiceName = "kaas";

        static void Main(string[] args)
        {
            var query = "robert";
            Search(query);

            Console.ReadKey();
        }

        private static void Search(string query)
        {
            var serviceClient = new SearchServiceClient(SearchServiceName, new SearchCredentials(PrimaryApiKey));
            var indexClientApi = serviceClient.Indexes.GetClient(IndexName);
            var results = indexClientApi.Documents.Search<Customer>(query).Results.Select(x => x.Document).ToList();
            results.ForEach(PrintResult);
        }

        private static void PrintResult(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerID} {customer.FirstName} {customer.LastName}");
        }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
