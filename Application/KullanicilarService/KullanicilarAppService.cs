using Application.KullanicilarService.DTO;
using Application.WordService.DTO;
using Core.Repositories.KullanicilarRepository;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.KullanicilarService
{
    public class KullanicilarAppService : IKullanicilarAppService
    {

        private readonly IKullaniciRepository _kullaniciRepository;
        public KullanicilarAppService(IKullaniciRepository kullaniciRepository)
        {
            _kullaniciRepository = kullaniciRepository;
        }

        public Kullanicilar UserFind(KullaniciRequest kullaniciRequest)
        {
            return _kullaniciRepository.Find(x => x.KullaniciAdi == kullaniciRequest.kullaniciAdi);

        }

        public BaseResponse UserDelete(KullaniciRequest kullaniciRequest)
        {

            var k = _kullaniciRepository.Find(x => x.KullaniciAdi == kullaniciRequest.kullaniciAdi);
            k.isOKey = false;
            _kullaniciRepository.Update(k);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.isOkey = true;
            baseResponse.message = "başarılı silme";
            return baseResponse;
        }

        public BaseResponse UserInit(KullaniciRequest kullaniciRequest)
        {
            string kAdi = kullaniciRequest.kullaniciAdi;
            Kullanicilar kullanicilar = new Kullanicilar();
            if (kullaniciRequest.kullaniciAdi == "admin")
            {
                int countUser = _kullaniciRepository.List().Count + 1;
                kullanicilar.KullaniciAdi = "User" + countUser;
                kullanicilar.isOKey = true;
                _kullaniciRepository.Insert(kullanicilar);
                kAdi = kullanicilar.KullaniciAdi;

            }
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.isOkey = true;
            baseResponse.message = kAdi;
            return baseResponse;
        }

        public List<Kullanicilar> UserList()
        {
            return _kullaniciRepository.List();
        }

        public BaseResponse UserUpdate(KullaniciUpdateRequest kullaniciUpdateRequest)
        {
            // Kullanicilar kullanicilar1=kullaniciUpdateRequest.kullaniciAdiYeni
            Kullanicilar kullanicilar1 = _kullaniciRepository.Find(x => x.KullaniciAdi == kullaniciUpdateRequest.kullaniciAdiYeni);
            BaseResponse baseResponse = new BaseResponse();
            if (kullanicilar1 == null)
            {

                if (kullaniciUpdateRequest.kullaniciAdiYeni == "admin")
                {
                    baseResponse.isOkey = false;
                    baseResponse.message = "Lütfen farklı bir kullanıcı adı girin.";
                    return baseResponse;
                }
                Kullanicilar kullanicilar = _kullaniciRepository.Find(x => x.KullaniciAdi == kullaniciUpdateRequest.kullaniciAdiEski);

                kullanicilar.KullaniciAdi = kullaniciUpdateRequest.kullaniciAdiYeni;
                kullanicilar.isOKey = true;
                _kullaniciRepository.Update(kullanicilar);

                baseResponse.isOkey = true;
                baseResponse.message = "Güncelleme Başarılı";
            }
            else
            {
                baseResponse.isOkey = false;
                baseResponse.message = "Zaten böyle bir kullanıcı var.";
            }

            return baseResponse;
        }

        public BaseResponse Login(LoginRequest loginRequest)
        {
            BaseResponse baseResponse = new BaseResponse();
            // Kullanicilar kullanicilar = _kullaniciRepository.Find(x => x.KullaniciAdi == loginRequest.username && x.Sifre == loginRequest.password);

            //  if (kullanicilar.Id == 2659 && kullanicilar != null)
            if (loginRequest.username == "fth" && loginRequest.password == "fth")
            {
                baseResponse.isOkey = true;
                baseResponse.message = loginRequest.username;
            }
            else
            {
                baseResponse.isOkey = false;
                baseResponse.message = "Giriş Başarısız";
            }


            return baseResponse;
        }

    }
}
