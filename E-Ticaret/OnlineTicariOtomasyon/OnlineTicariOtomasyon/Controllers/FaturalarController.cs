using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturalarController : Controller
    {
        // GET: Faturalar
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);//f den gelen değeri ekle
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var ftr = c.Faturalars.Find(id);
            return View("FaturaGetir",ftr);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var ftr = c.Faturalars.Find(f.FaturaID);
            ftr.FaturaSerino = f.FaturaSerino;
            ftr.FaturaSırano = f.FaturaSırano;
            ftr.VergiDairesi = f.VergiDairesi;
            ftr.Tarih = f.Tarih;
            ftr.Saat = f.Saat;
            ftr.Toplam = f.Toplam;
            ftr.TeslimEden = f.TeslimEden;
            ftr.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);//f den gelen değeri ekle
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}