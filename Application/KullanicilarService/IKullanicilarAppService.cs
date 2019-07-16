using Application.KullanicilarService.DTO;
using Application.WordService.DTO;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.KullanicilarService
{
    public interface IKullanicilarAppService
    {
        List<Kullanicilar> UserList();
        Kullanicilar UserFind(KullaniciRequest kullaniciRequest);
        BaseResponse UserInit(KullaniciRequest kullaniciRequest);
        BaseResponse UserDelete(KullaniciRequest kullaniciRequest);
        BaseResponse UserUpdate(KullaniciUpdateRequest kullaniciUpdateRequest);
        BaseResponse Login(LoginRequest loginRequest);
    }
}
