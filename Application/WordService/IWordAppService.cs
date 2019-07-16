using Application.WordService.DTO;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.WordService
{
   public interface IWordAppService
    {
        BaseResponse KelimeEkle(WordRequest wordRequest);
        List<WordResponse> KelimelerListesi();
        List<WordResponse> KelimelerListesiFalse();
        List<WordResponse> KelimelerListesiAll();
        List<WordTestResponse> KelimelerListesiTr();
        List<WordTestResponse> KelimelerListesiEng();
        List<SoruIndexResponse> KelimelerListAyar();
        List<LiderlikResponse> KelimeLiderList();
        BilgiResponse Bilgi();
        WordResponse KelimeFind(IdRequest idRequest);
        BaseResponse KelimeUpdate(WordResponse idRequest);
        BaseResponse KelimeDelete(IdRequest idRequest);
        BaseResponse KelimeOnay(IdRequest idRequest);
        GenelBilgiResponse Genel();
    }
}
