//Eduarda Vitória; Stefany Tam
using Microsoft.AspNetCore.Hosting;
using TP01E02;
using TP01E02.Repositorio;
using TP01E02.Model;

BookCSV bookCSV = new BookCSV();
Console.WriteLine(bookCSV.Library.ToString());
IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
host.Run();

