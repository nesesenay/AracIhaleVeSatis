using IkınciElAracSatis.UI.Models.VM.AracTramer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IkınciElAracSatis.UI.DAL.AracTramerIslemleri
{
    public class AracTramerBilgileriGetirDAL
    {

        AracTramerDAL aracTarmerIslemleri = new AracTramerDAL();

        public AracTramerVM AracTramerBilgileriniGetir()
        {
            var aracParcaDurumlari = aracTarmerIslemleri.AracParcaDurumlariniGetir();
            var aracParcalari = aracTarmerIslemleri.AracParcalariniGetir();

           

            return new AracTramerVM()
            {
                AracParcaDurumlari = aracParcaDurumlari,
                AracParcalari = aracParcalari,
                AracTramerUcreti = new AracTramerUcretVM()
            };
        }

        public void AracTramerBilgisiEkle(FormCollection form, int id, AracTramerVM vm)
        {
            var selectedIds1 = form.GetValues("selectedItems1");
            var selectedIds2 = form.GetValues("selectedItems2");
            var selectedIds3 = form.GetValues("selectedItems3");

            vm.AracTramerUcreti.AracID = id;

            var tramerUcretVM = new AracTramerUcretVM
            {
                AracID = id,
                Ucret = vm.AracTramerUcreti.Ucret
            };

            new AracTramerDAL().DBAracTramerUcretiEkle(tramerUcretVM);

            if (selectedIds1 != null)
            {
                foreach (var item in selectedIds1)
                {
                    var aracDurumu = new AracDurumVM()
                    {
                        AracID = id,
                        AracParcaDurumID = 1,
                        AracParcaID = Convert.ToInt32(item)
                    };

                    new AracTramerDAL().DBAracDurumuEkle(aracDurumu);
                }

            }

            if (selectedIds2 != null)
            {
                foreach (var item in selectedIds2)
                {
                    var aracDurumu = new AracDurumVM()
                    {
                        AracID = id,
                        AracParcaDurumID = 2,
                        AracParcaID = Convert.ToInt32(item)
                    };

                    new AracTramerDAL().DBAracDurumuEkle(aracDurumu);
                }

            }

            if (selectedIds3 != null)
            {
                foreach (var item in selectedIds3)
                {
                    var aracDurumu = new AracDurumVM()
                    {
                        AracID = id,
                        AracParcaDurumID = 3,
                        AracParcaID = Convert.ToInt32(item)
                    };

                    new AracTramerDAL().DBAracDurumuEkle(aracDurumu);
                }

            }
        }
    }

 
}