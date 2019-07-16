using Application.WordService.DTO;
using Core.DataBaseContext;
using Core.Repositories.KelimelerRepository;
using Core.Repositories.KullanicilarRepository;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.WordService
{
    public class WordAppService : IWordAppService
    {

        private readonly IKelimeRepository _kelimeRepository;
        private readonly IKullaniciRepository _kullaniciRepository;
        private readonly OnlineDatabaseContext _context;
        public WordAppService(OnlineDatabaseContext context, IKullaniciRepository kullaniciRepository, IKelimeRepository kelimeRepository)
        {
            _kelimeRepository = kelimeRepository;
            _kullaniciRepository = kullaniciRepository;
            _context = context;
        }

        public BaseResponse KelimeEkle(WordRequest wordRequest)
        {
            var user = _kullaniciRepository.Find(x => x.KullaniciAdi == wordRequest.kullanici && x.isOKey == true);
            BaseResponse baseResponse = new BaseResponse();
            if (user != null)
            {
                Kelimeler kelimeler = new Kelimeler();
                kelimeler.Kelime = wordRequest.kelime;
                kelimeler.KelimeAnlami = wordRequest.anlami;
                kelimeler.isOKey = false;
                kelimeler.KullanicilarId = user.Id;
                _kelimeRepository.Insert(kelimeler);
                baseResponse.isOkey = true;
                baseResponse.message = "Kayıt Başarılı";
            }
            else
            {
                baseResponse.isOkey = false;
                baseResponse.message = "Lütfen kullanıcı adınızı düzenledikten sonra kelime ekleyin";
            }

            return baseResponse;
        }

        public List<WordResponse> KelimelerListesi()
        {
            List<WordResponse> wordResponses = new List<WordResponse>();
            List<Kelimeler> kelimelers = _kelimeRepository.List(x => x.isOKey == true).OrderByDescending(x => x.Id).ToList();

            foreach (var item in kelimelers)
            {
                var user = _kullaniciRepository.Find(x => x.Id == item.KullanicilarId);
                if (user.isOKey == false) continue;
                wordResponses.Add(new WordResponse()
                {
                    userName = user.KullaniciAdi,
                    wordEn = item.KelimeAnlami,
                    wordTr = item.Kelime

                });
            }
            return wordResponses;

        }

        public List<WordResponse> KelimelerListesiAll()
        {
            List<WordResponse> wordResponses = new List<WordResponse>();
            List<Kelimeler> kelimelers = _kelimeRepository.List(x => x.isOKey == true).OrderByDescending(x => x.Id).ToList();

            foreach (var item in kelimelers)
            {
                var user = _kullaniciRepository.Find(x => x.Id == item.KullanicilarId);
                wordResponses.Add(new WordResponse()
                {
                    userName = user.KullaniciAdi,
                    wordEn = item.Kelime,
                    id = item.Id,
                    wordTr = item.KelimeAnlami

                });
            }
            return wordResponses;

        }

        public List<SoruIndexResponse> KelimelerListAyar()
        {
            int kelimesayisi = _kelimeRepository.List(x => x.isOKey == true).Count();
            //  List<int> sayilar = new List<int>();
            List<SoruIndexResponse> sayilar = new List<SoruIndexResponse>();
            Random rastgele = new Random();
            int i = 0;
            int sayi;
            int indexNo;
            //while (i < 15)
            //{
            //    int sayi = rastgele.Next(3, kelimesayisi-3);
            //    if (sayilar.Contains(sayi))
            //        continue;
            //    sayilar.Add(sayi);
            //    i++;
            //}
            //return sayilar;
            while (i < 15)
            {
                sayi = rastgele.Next(3, kelimesayisi - 3);
                var ss = new SoruIndexResponse();
                ss.soru = sayi;
                ss.yanlis1 = sayi - 2;
                ss.yanlis2 = sayi - 1;
                ss.yanlis3 = sayi + 1;
                var s = sayilar.Find(x=>x.soru==sayi);
                if (s != null)
                {
                    while (true)
                    {
                        sayi = rastgele.Next(3, kelimesayisi - 3);
                        var sss = sayilar.Find(x => x.soru == sayi);
                        if (sss == null)
                        {

                        break;
                        }
                    }
                }
                sayilar.Add(new SoruIndexResponse()
                {
                    soru = sayi,
                    yanlis1 = sayi - 2,
                    yanlis2 = sayi - 1,
                    yanlis3 = sayi + 1,


                });
                i++;
            }
            return sayilar;
        }



        public List<WordTestResponse> KelimelerListesiTr()
        {
            List<WordTestResponse> wordResponses = new List<WordTestResponse>();
            List<Kelimeler> kelimelers = _kelimeRepository.List(x => x.isOKey == true).ToList();
            List<SoruIndexResponse> soruIndexResponses = KelimelerListAyar();
            foreach (var item in soruIndexResponses)
            {
                var user = _kullaniciRepository.Find(x => x.Id == kelimelers[item.soru].KullanicilarId);
                if (user.isOKey == false) continue;
                wordResponses.Add(new WordTestResponse()
                {
                    userName = user.KullaniciAdi,
                    wordTrue = kelimelers[item.soru].KelimeAnlami,
                    word = kelimelers[item.soru].Kelime,
                    wordFalse1 = kelimelers[item.yanlis1].KelimeAnlami,
                    wordFalse2 = kelimelers[item.yanlis2].KelimeAnlami,
                    wordFalse3 = kelimelers[item.yanlis3].KelimeAnlami

                });
            }
            return wordResponses;
        }

        public List<WordTestResponse> KelimelerListesiEng()
        {
            List<WordTestResponse> wordResponses = new List<WordTestResponse>();
            List<Kelimeler> kelimelers = _kelimeRepository.List(x => x.isOKey == true).ToList();

            foreach (var item in KelimelerListAyar())
            {
                var user = _kullaniciRepository.Find(x => x.Id == kelimelers[item.soru].KullanicilarId);
                if (user.isOKey == false) continue;
                wordResponses.Add(new WordTestResponse()
                {
                    userName = user.KullaniciAdi,
                    wordTrue = kelimelers[item.soru].Kelime,
                    word = kelimelers[item.soru].KelimeAnlami,
                    wordFalse1 = kelimelers[item.yanlis1].Kelime,
                    wordFalse2 = kelimelers[item.yanlis2].Kelime,
                    wordFalse3 = kelimelers[item.yanlis3].Kelime

                });
            }
            return wordResponses;
        }

        public BilgiResponse Bilgi()
        {
            BilgiResponse bilgiResponse = new BilgiResponse();
            bilgiResponse.kullaniciSayisi = _kullaniciRepository.List().Count().ToString();
            bilgiResponse.kelimeSayisi = _kelimeRepository.List(x => x.isOKey == true).Count().ToString();
            return bilgiResponse;
        }

        public List<LiderlikResponse> KelimeLiderList()
        {
            List<Kelimeler> liderlikResponses = _kelimeRepository.List(x => x.isOKey == true).ToList();



            var data1 = liderlikResponses.GroupBy(x => x.KullanicilarId)
        .Select(x => new LiderlikResponse
        {

            id = 1,
            kelimeSayisi = x.Count(),
            kullaniciAdi = _kullaniciRepository.Find(k => k.Id == x.Key).KullaniciAdi
        }).OrderByDescending(x => x.kelimeSayisi).ToList();

            return data1;
        }

        public WordResponse KelimeFind(IdRequest idRequest)
        {
            var kelime = _kelimeRepository.Find(x => x.Id == idRequest.id);
            var word = new WordResponse
            {
                id = kelime.Id,
                userName = _kullaniciRepository.Find(x => x.Id == kelime.KullanicilarId).KullaniciAdi,
                wordEn = kelime.KelimeAnlami,
                wordTr = kelime.Kelime
            };
            return word;
        }

        public BaseResponse KelimeUpdate(WordResponse idRequest)
        {
            var kelime = _kelimeRepository.Find(x => x.Id == idRequest.id);
            kelime.Kelime = idRequest.wordTr;
            kelime.KelimeAnlami = idRequest.wordEn;
            _kelimeRepository.Update(kelime);
            var res = new BaseResponse
            {
                isOkey = true,
                message = "Güncelleme Başarılı"

            };
            return res;
        }

        public BaseResponse KelimeDelete(IdRequest idRequest)
        {
            var kelime = _kelimeRepository.Find(x => x.Id == idRequest.id);
            _kelimeRepository.Delete(kelime);
            var kk = new BaseResponse
            {
                isOkey = true,
                message = "Kelime Silindi"
            };
            return kk;
        }

        public BaseResponse KelimeOnay(IdRequest idRequest)
        {
            var kelime = _kelimeRepository.Find(x => x.Id == idRequest.id);
            var kelimeFind = _kelimeRepository.List(x => x.Kelime.Trim().Replace(" ", string.Empty).ToLower() == kelime.Kelime.Trim().Replace(" ", string.Empty).ToLower() && x.Id != kelime.Id).ToList();
            BaseResponse res;
            if (kelimeFind.Count() <=0)
            {
                kelime.isOKey = true;
                _kelimeRepository.Update(kelime);
                res = new BaseResponse
                {
                    isOkey = true,
                    message = "Onaylama Başarılı"

                };
            }
            else
            {
                res = new BaseResponse
                {
                    isOkey = true,
                    message = "Bu Kelime Zaten Var"

                };
            }



            return res;
        }

        public List<WordResponse> KelimelerListesiFalse()
        {
            List<WordResponse> wordResponses = new List<WordResponse>();
            List<Kelimeler> kelimelers = _kelimeRepository.List(x => x.isOKey == false).OrderByDescending(x => x.Id).ToList();

            foreach (var item in kelimelers)
            {
                var user = _kullaniciRepository.Find(x => x.Id == item.KullanicilarId);
                wordResponses.Add(new WordResponse()
                {
                    userName = user.KullaniciAdi,
                    wordEn = item.Kelime,
                    wordTr = item.KelimeAnlami,
                    id = item.Id

                });
            }
            return wordResponses;
        }

        public GenelBilgiResponse Genel()
        {
            GenelBilgiResponse genelBilgiResponse = new GenelBilgiResponse();
            genelBilgiResponse.KelimeSayisi = _kelimeRepository.List().Count.ToString();
            genelBilgiResponse.KullaniciSayisi = _kullaniciRepository.List().Count.ToString();
            return genelBilgiResponse;
        }
    }
}
