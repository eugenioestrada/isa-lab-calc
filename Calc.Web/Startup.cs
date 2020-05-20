using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calc.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        private string HtmlDocument(string content) {
            return $"<!DOCTYPE html><html><head><title>Calculadora</title><meta charset=\"UTF-8\"></head><body>{content}</body></html>";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/sumar", async context =>
                {
                    if (context.Request.Query.ContainsKey("operando1") && context.Request.Query.ContainsKey("operando2")) {
                        if (double.TryParse(context.Request.Query["operando1"], out double operando1) &&
                            double.TryParse(context.Request.Query["operando2"], out double operando2)) {
                            var calcService = new CalcService();
                            await context.Response.WriteAsync(HtmlDocument($"Resultado de sumar: {calcService.Sumar(operando1, operando2)}"));
                        }
                    }
                });

                endpoints.MapGet("/restar", async context =>
                {
                    if (context.Request.Query.ContainsKey("operando1") && context.Request.Query.ContainsKey("operando2")) {
                        if (double.TryParse(context.Request.Query["operando1"], out double operando1) &&
                            double.TryParse(context.Request.Query["operando2"], out double operando2)) {
                            var calcService = new CalcService();
                            await context.Response.WriteAsync(HtmlDocument($"Resultado de restar: {calcService.Restar(operando1, operando2)}"));
                        }
                    }
                });

                endpoints.MapGet("/multiplicar", async context =>
                {
                    if (context.Request.Query.ContainsKey("multiplicando") && context.Request.Query.ContainsKey("multiplicador")) {
                        if (double.TryParse(context.Request.Query["multiplicando"], out double multiplicando) &&
                            double.TryParse(context.Request.Query["multiplicador"], out double multiplicador)) {
                            var calcService = new CalcService();
                            await context.Response.WriteAsync(HtmlDocument($"Resultado de multiplicar: {calcService.Multiplicar(multiplicando, multiplicador)}"));
                        }
                    }
                });

                endpoints.MapGet("/dividir", async context =>
                {
                    if (context.Request.Query.ContainsKey("dividendo") && context.Request.Query.ContainsKey("divisor")) {
                        if (double.TryParse(context.Request.Query["dividendo"], out double dividendo) &&
                            double.TryParse(context.Request.Query["divisor"], out double divisor)) {
                            var calcService = new CalcService();
                            await context.Response.WriteAsync(HtmlDocument($"Resultado de dividir: {calcService.Dividir(dividendo, divisor)}"));
                        }
                    }
                });

                endpoints.MapGet("/raiz", async context =>
                {
                    if (context.Request.Query.ContainsKey("numero")) {
                        if (int.TryParse(context.Request.Query["numero"], out int numero)) {
                            var calcService = new CalcService();
                            await context.Response.WriteAsync(HtmlDocument($"Resultado de raíz cuadrada: {calcService.RaizCuadrada(numero)}"));
                        }
                    }
                });
            });
        }
    }
}
