using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Model;
using MiniBank.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MiniBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IService _IService;
        private static IWebHostEnvironment _webHostEnviroment;
        public HomeController(IService IService, IWebHostEnvironment webHostEnvironment )
        {
            _IService = IService;
            _webHostEnviroment = webHostEnvironment;
        }
        [HttpPost("CreateAccount")]
        public async Task<ActionResult<KYCResponse>> AccountCreateion([FromForm] KYC kYC)
        {
            //var file = kYC.Image;
            KYCResponse response = new KYCResponse();
            if (!ModelState.IsValid)
            {
                response.ResponseCode = "-99";
                response.ResponseMessage = "invalid model";
                return BadRequest(response);
            }

            //string path = _webHostEnviroment.WebRootPath + "\\upload\\";
            //if(!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path); 
            //}


            //using (FileStream fileStream = System.IO.File.Create(path + kYC.Image.FileName))
            //{
            //    kYC.Image.CopyTo(fileStream);
            //    fileStream.Flush();

            //}

                try
                {
                    var acct = await _IService.AccountCreation(kYC);
                    if (acct != null)
                    {
                        response.Nuban = acct.Nuban;
                        response.ResponseMessage = "Account Create Successfully";
                        response.ResponseCode = "00";

                    }
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    response.ResponseMessage = ex.Message;
                    response.ResponseCode = "-999";
                    return StatusCode(-999, response);

                }
           
        }
        [HttpPost("Topup")]
        public async Task<ActionResult<KYCResponse>> Topup ([FromBody] topup topup)
        {
            // 2518617082
            KYCResponse response = new KYCResponse();
            try
            {
                var q = await _IService.Topup(topup);
                return Ok(q);
            }
            catch (Exception ex)
            {
                response.ResponseMessage = ex.Message;
                response.ResponseCode = "-999";
                return StatusCode(-999, response);
            }
        }
         [HttpPost("FundTransfer")]
        public async Task<ActionResult<KYCResponse>> fund ([FromBody] topup topup)
        {
            // 2518617082
            KYCResponse response = new KYCResponse();
            try
            {
                var q = await _IService.FundTransfer(topup);
                return Ok(q);
            }
            catch (Exception ex)
            {
                response.ResponseMessage = ex.Message;
                response.ResponseCode = "-999";
                return StatusCode(-999, response);
            }
        }

    }
}
