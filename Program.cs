
using Microsoft.Extensions.Compliance.Classification;
using Microsoft.Extensions.Compliance.Redaction;
using AnhTran.RedactingSensitiveData.Redactors;
using AnhTran.RedactingSensitiveData.Taxonomy;
using Serilog;
using Serilog.Filters;
using System.Text;

namespace AnhTran.RedactingSensitiveData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Logging.ClearProviders();

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            //.WriteTo.Console()
            .WriteTo.File(
                new Serilog.Formatting.Json.JsonFormatter(),
                "logs/Application_.log",
                rollingInterval: RollingInterval.Day)
            .Filter.ByExcluding(Matching.FromSource("Microsoft"))  // Exclude all Microsoft logs
            .Filter.ByExcluding(Matching.FromSource("System"))     // Exclude all System logs
            .CreateLogger();
            
            builder.Services.AddLogging(opts =>
            {
                opts.AddSerilog(Log.Logger, dispose: true);
                opts.EnableRedaction();
            });            

            // Add the redaction services
            builder.Services.AddRedaction(x =>
            {
                //x.SetRedactor<ErasingRedactor>(new DataClassificationSet(MyTaxonomy.PersonalData));
                x.SetRedactor<MarkSubStringRedactor>(new DataClassificationSet(MyTaxonomy.PersonalData));
                //  Enable the custom redactor for sensive data
                x.SetRedactor<MarkAllRedactor>(new DataClassificationSet(MyTaxonomy.SensitiveData));

                // Enable the HMAC256 redactor for Security data
                x.SetHmacRedactor(hmacOpts =>
                {
                    hmacOpts.Key = Convert.ToBase64String(Encoding.UTF8.GetBytes("TRieTOraNHERMILatENceLeMANiCKsIoUSETCARjoGyN"));
                    hmacOpts.KeyId = 123;
                }, new DataClassificationSet(MyTaxonomy.FinancialData));
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
