using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace WhatAndWhen.Web.Middleware
{
    public class LastVisitMiddleware
    {
        private readonly RequestDelegate _next;
        private const string LastVisitCookieName = "LastVisit";

        public LastVisitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey(LastVisitCookieName))
            {
                var lastVisit = context.Request.Cookies[LastVisitCookieName];
                context.Items["LastVisit"] = lastVisit;
            }

            // Ustawienie nowej daty wizyty
            context.Response.Cookies.Append(LastVisitCookieName, DateTime.UtcNow.ToString("O"));

            await _next(context);
        }
    }

    public static class LastVisitMiddlewareExtensions
    {
        public static IApplicationBuilder UseLastVisit(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LastVisitMiddleware>();
        }
    }
}