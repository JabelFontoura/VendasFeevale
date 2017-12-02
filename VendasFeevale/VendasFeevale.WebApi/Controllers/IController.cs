using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasFeevale_WebApi.Controllers
{
    public interface IController<T>
    {
        IActionResult FindAll();
        IActionResult FindById(string id);
        IActionResult Add(T entity);
        IActionResult Update(T entity);
        IActionResult Delete(string id);
    }
}
