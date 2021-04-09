using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Yellfage.Wst.Internal
{
    internal interface IRequestProcessor
    {
        Task ProcessAsync(HttpContext context, Func<Task> next);
    }
}
