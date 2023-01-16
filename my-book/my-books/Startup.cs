using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using my_books.Data;
using my_books.Data.Services;
using my_books.Exceptions;

namespace my_books
{
    public class Startup
    {
        public string ConnectionString { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //esta conexion es Con Windows
            ConnectionString = Configuration.GetConnectionString("DefaultConnectionString2");
            //Esta conexion es en la Mac con Docker
            //ConnectionString = Configuration.GetConnectionString("ConnStringDocker");

        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            //Configure DbContex wtih SQL
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));


            //Configure the services
            services.AddTransient<BooksServices>();
            services.AddTransient<AuthorsService>();
            services.AddTransient<PublishersService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "my_books_updates_tittle", Version = "v2" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "my_books v2"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Exception Handling
            //app.ConfigureBuildInExceptionHandler();
            app.ConfigureCustomExceptionHandler();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AppDbInitialer.Seed(app);
        }
    }
}
