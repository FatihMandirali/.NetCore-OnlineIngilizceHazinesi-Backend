using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.KullanicilarService;
using Application.KullanicilarService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineIngilizceHazinesi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KullanicilarController : ControllerBase
    {
        private readonly IKullanicilarAppService _kullanicilarAppService;
        public KullanicilarController(IKullanicilarAppService kullanicilarAppService)
        {
            _kullanicilarAppService = kullanicilarAppService;
        }

        [HttpGet]
        public IActionResult GetKullanicilarList()
        {
            var users = _kullanicilarAppService.UserList();
            return Ok(users);

        }
        [HttpPost]
        public IActionResult PostKullaniciInit(KullaniciRequest kullaniciRequest)
        {
            var users = _kullanicilarAppService.UserInit(kullaniciRequest);
            return Ok(users);

        }
        [HttpPost]
        public IActionResult PostKullaniciUpdate(KullaniciUpdateRequest kullaniciUpdateRequest)
        {
            var users = _kullanicilarAppService.UserUpdate(kullaniciUpdateRequest);
            return Ok(users);

        }
    }
}