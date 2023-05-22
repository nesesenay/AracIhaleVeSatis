using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.CORE.Entities;
using IkinciElAracSatis.CORE.Entities;
using IkınciElAracSatis.UI.Models.VM;
using IkınciElAracSatis.UI.Models.VM.AracTramer;
using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IkınciElAracSatis.UI.DAL.AracTramerIslemleri
{
    public class AracTramerDAL
    {

        IkinciElAracSatisContext db = new IkinciElAracSatisContext();

        public List<AracParcaVM> AracParcalariniGetir()
        {
            return (from p in db.AracParcalari
                    select new AracParcaVM()
                    {
                        AracParcaAdi = p.AracParcaAdi,
                        AracParcaID = p.AracParcaID,
                    }).ToList();
        }

        public List<AracParcaDurumuVM> AracParcaDurumlariniGetir()
        {
            return (from p in db.AracParcaDurumlari
                    select new AracParcaDurumuVM()
                    {
                        AracParcaDurumID = p.AracParcaDurumID,
                        ParcaDurumu = p.ParcaDurumu
                    }).ToList();
        }

        public bool DBAracDurumuEkle(AracDurumVM vm)
        {

            db.AracDurumlari.Add(new AracDurum()
            {

                AracParcaDurumID = vm.AracParcaDurumID,
                AracID = vm.AracID,
                AracParcaID = vm.AracParcaID,
            });

            return db.SaveChanges() > 0;

        }

        public AracTramerUcretVM AracTramerUcretGetir(int aracID)
        {

            return (from a in db.AracUcretleri.Where(a => a.AracID == aracID && a.AracUcretTipID == 3)
                    select new AracTramerUcretVM()
                    {
                        AracID = aracID,
                        Ucret = a.Ucret
                    }).FirstOrDefault();

        }



        public List<AracDurumVM> AracDurumGetir(int aracID)
        {

            return (from a in db.AracDurumlari.Where(a => a.AracID == aracID)
                    select new AracDurumVM()
                    {
                        AracID = aracID,
                        AracParcaDurumID = a.AracParcaDurumID,
                        AracParcaID = a.AracParcaID,
                    }).ToList();

        }

        public bool DBAracTramerUcretiEkle(AracTramerUcretVM vm)
        {

            db.AracUcretleri.Add(new AracUcret()
            {
                 AracID= vm.AracID,
                 AracUcretTipID = vm.AracUcretTipID,
                 ParaBirimiID = vm.ParaBirimiID,
                 Ucret = vm.Ucret
            });

            return db.SaveChanges() > 0;

        }


    }
}