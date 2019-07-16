using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.KullanicilarService;
using Application.KullanicilarService.DTO;
using Application.WordService;
using Application.WordService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineIngilizceHazinesi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class YonetimController : ControllerBase
    {
        private readonly IKullanicilarAppService _kullanicilarAppService;
        private readonly IWordAppService _wordAppService;
        public YonetimController(IWordAppService wordAppService,IKullanicilarAppService kullanicilarAppService)
        {
            _kullanicilarAppService = kullanicilarAppService;
            _wordAppService = wordAppService;
        }

        [HttpGet]
        public IActionResult GetKullanicilarList()
        {
            var users = _kullanicilarAppService.UserList();
            return Ok(users);

        }
        [HttpGet]
        public IActionResult GetKelimelerList()
        {
            var users = _wordAppService.KelimelerListesiAll();
            return Ok(users);

        }

        [HttpPost]
        public IActionResult GetKullaniciFind(KullaniciRequest kullaniciRequest)
        {
            var users = _kullanicilarAppService.UserFind(kullaniciRequest);
            return Ok(users);

        }
        [HttpPost]
        public IActionResult GetKelimeFind(IdRequest idRequest)
        {
            var users = _wordAppService.KelimeFind(idRequest);
            return Ok(users);

        }

        [HttpPost]
        public IActionResult GetKullaniciUpdate(KullaniciUpdateRequest kullaniciUpdateRequest)
        {
            var users = _kullanicilarAppService.UserUpdate(kullaniciUpdateRequest);
            return Ok(users);

        }
        [HttpPost]
        public IActionResult GetKelimeUpdate(WordResponse idRequest)
        {
            var users = _wordAppService.KelimeUpdate(idRequest);
            return Ok(users);

        }

        [HttpPost]
        public IActionResult GetKullaniciDelete(KullaniciRequest kullaniciRequest)
        {
            var users = _kullanicilarAppService.UserDelete(kullaniciRequest);
            return Ok(users);

        }
        [HttpPost]
        public IActionResult GetKelimeDelete(IdRequest kullaniciRequest)
        {
            var users = _wordAppService.KelimeDelete(kullaniciRequest);
            return Ok(users);

        }


        [HttpPost]
        public IActionResult GetKelimeOnay(IdRequest kullaniciRequest)
        {
            var users = _wordAppService.KelimeOnay(kullaniciRequest);
            return Ok(users);

        }

        [HttpGet]
        public IActionResult GetGenel()
        {
            var users = _wordAppService.Genel();
            return Ok(users);

        }

    }
}