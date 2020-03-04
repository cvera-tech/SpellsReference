using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpellsReferenceCore.Data;

namespace SpellsReferenceCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddTransient<ISpellsReferenceContext, SpellsReferenceContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Default}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ISpellsReferenceContext>();
                if (!context.Spells.Any())
                {
                    var fileName = @"spells.txt";
                    var databaseModel = SeedData.ReadDatabaseModel(fileName);

                    // Reset the Ids to add entities into the database.
                    foreach (var spell in databaseModel.Spells)
                    {
                        spell.Id = 0;
                    }
                    foreach (var spellbook in databaseModel.Spellbooks)
                    {
                        spellbook.Id = 0;
                    }
                    
                    context.Spells.AddRange(databaseModel.Spells);
                    context.SaveChanges();
                    context.Spellbooks.AddRange(databaseModel.Spellbooks);
                    context.SaveChanges();
                    context.SpellbookSpells.AddRange(databaseModel.SpellbookSpells);
                    context.SaveChanges();
                }
            }
        }
    }
}
