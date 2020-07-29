using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using WebAPiFindCEP.Models;
using WebAPiFindCEP.Services;

namespace WebAPiFindCEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindCEPController : ControllerBase
    {
        [HttpPost("Processa")]
        public async Task<IActionResult> LocalizarCEP(IFormFile file)
        {
            //Start Bot
            ExcelRead.ReadExcel(file);

            return Ok("Seu Arquivo será processado.");
        }
    }
}
