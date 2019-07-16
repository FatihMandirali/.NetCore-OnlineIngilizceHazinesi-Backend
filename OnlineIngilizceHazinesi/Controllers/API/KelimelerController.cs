using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.WordService;
using Application.WordService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineIngilizceHazinesi.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KelimelerController : ControllerBase
    {
        private readonly IWordAppService _wordAppService;
        public KelimelerController(IWordAppService wordAppService)
        {
            _wordAppService = wordAppService;
        }

        [HttpPost]
        public IActionResult PostKelimeEkle(WordRequest wordRequest)
        {
            var users = _wordAppService.KelimeEkle(wordRequest);
            return Ok(users);

        }
        [HttpGet]
        public IActionResult GetKelimeList()
        {
            var users = _wordAppService.KelimelerListesi();
            return Ok(users);

        }
        [HttpGet]
        public IActionResult GetKelimeListFalse()
        {
            var users = _wordAppService.KelimelerListesiFalse();
            return Ok(users);

        }
        [HttpGet]
        public IActionResult GetKelimeList1()
        {
            var users = _wordAppService.KelimelerListAyar();
            return Ok(users);
        }
        [HttpGet]
        public IActionResult GetKelimeListTr()
        {
            var users = _wordAppService.KelimelerListesiTr();
            return Ok(users);

        }
        [HttpGet]
        public IActionResult GetKelimeListEng()
        {
            var users = _wordAppService.KelimelerListesiEng();
            return Ok(users);

        }
        [HttpGet]
        public IActionResult GetBilgi()
        {
            var users = _wordAppService.Bilgi();
            return Ok(users);

        }
        [HttpGet]
        public IActionResult GetKelimeLiderList()
        {
            var users = _wordAppService.KelimeLiderList();
            return Ok(users);

        }
    }
}