using Northwind.Web;
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    }).Build().Run();
Console.WriteLine("Tihs executes after the web server has stopped!");