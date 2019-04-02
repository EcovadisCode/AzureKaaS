#r "Newtonsoft.Json"
#load "../shared/GuidHelper.cs"
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using AutoMapper;

using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    var connection = "(connection string here)";
    Mapper.Initialize(cfg => cfg.AddProfile<Map>());

    string result;

    //// get data from shared class
    //result = GuidHelper.GetRandomGuid();

    //// Automapper
    //var customer = new Customer();
    //customer.FirstName = "Azure";
    //customer.LastName = "Functions";
    //var output = Mapper.Map<Output>(customer);
    //result = output.FullName;

    //// query DB via Dapper
    //var query = "select * from [salesLT].[Customer] order by newid()";
    //using (var db = new SqlConnection(connection))
    //{
    //    var customer = db.Query<Customer>(query).FirstOrDefault();
    //    var output = Mapper.Map<Output>(customer);
    //    result = output.FullName;
    //}

    return (ActionResult)new OkObjectResult($"{result}");
}

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Output
{
    public string FullName { get; set; }
}

public class Map : Profile
{
    public Map()
    {
        CreateMap<Customer, Output>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(z => $"{z.FirstName} {z.LastName}"));
    }
}