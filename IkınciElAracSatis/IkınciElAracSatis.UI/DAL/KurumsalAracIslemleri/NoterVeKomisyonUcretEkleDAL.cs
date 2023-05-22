using IkınciElAracSatis.UI.Models.VM.AracUcretBilgileri;
using IkinciElAracSatis.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IkınciElAracSatis.CORE.Context;
using IkınciElAracSatis.DAL.KurumsalAracIslemleri;
using IkınciElAracSatis.UI.Models.VM.KurumsalAracBilgileri;
using IkınciElAracSatis.UI.Models.VM;
using System.Transactions;

namespace IkınciElAracSatis.UI.DAL.KurumsalAracIslemleri
{
    public class NoterVeKomisyonUcretEkleDAL
    {

        public void DBKomisyonVeNoterUcretEkle(NoterVeKomisyonUcretVM vm, int komisyonID, int id)
        {
            IkinciElAracSatisContext db = new IkinciElAracSatisContext();


            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    KurumsalAracDAL kurumsalArac = new KurumsalAracDAL();

                    kurumsalArac.DBKomisyonUcretEkle(new KomisyonUcretVM()
                    {
                        AracID = id,
                        BaslangicTarihi = vm.KomisyonUcreti.BaslangicTarihi,
                        BitisTarihi = vm.KomisyonUcreti.BitisTarihi,
                        BelirlenenKomisyonID = komisyonID,
                    });

                    kurumsalArac.DBNoterUcretEkle(new NoterUcretVM()
                    {
                        AracID = id,
                        BaslangicTarihi = vm.NoterUcreti.BaslangicTarihi,
                        BitisTarihi = vm.NoterUcreti.BitisTarihi,
                        Ucret = vm.NoterUcreti.Ucret,
                        ParaBirimID = vm.NoterUcreti.ParaBirimID
                    });



                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                }
            }
        }


    }
}