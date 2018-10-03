using MySystem_admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem_admin.Controllers
{
    public class VendorController : Controller
    {
        public MySystemDBEntities db = new MySystemDBEntities();
        // GET: Vendor
        public ActionResult ArchitectureVendorInfo()
        {
            return View();
        }
        public JsonResult ArchitectureData()
        {
            //List<Vendor> vendorslist = db.Vendor.ToList();

            //VendorViewModel vendorlistVM = new VendorViewModel();

            List<VendorViewModel> vendorlist = db.Vendor.Where(x => x.VendorId.Contains("A")).Select(x => new VendorViewModel
            {
                VendorId = x.VendorId,
                VendorName = x.VendorName,
                Establishment = x.Establishment,
                LawRepresentative = x.LawRepresentative,
                BusinessLicense = x.BusinessLicense,
                ExpirationDate = x.ExpirationDate,
                Tariff = x.Tariff,
                LY_Renvenue = x.LY_Renvenue,

                SalesAmounts = x.SalesAmounts,
                ManagementType = x.ManagementType,
                ManagementCategory = x.ManagementCategory,
                Subsidiary = x.Subsidiary,
                IsFTA = x.IsFTA,
                System = x.System,
                EmpHeadcount = x.EmpHeadcount

            }).ToList();

            return Json(vendorlist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddArchitecture()
        {
            return PartialView("AddArchitectureAddPartial");
        }
        [HttpPost]
        public ActionResult AddArchitectureData(VendorViewModel model)
        {
            try
            {
                string status;
                string vendorid;

                Random rnd = new Random();

                string num = Enumerable.Range(0, 10000).OrderBy(n => rnd.Next()).ToArray().GetValue(1).ToString();

                vendorid = "A" + num.PadLeft(15, '0');

                model.VendorId = vendorid;

                var result = db.Vendor.Where(x => x.VendorId == model.VendorId || x.VendorName == model.VendorName).Select(x => x).FirstOrDefault();

                if (result == null)
                {
                    Vendor vd = new Vendor();
                    vd.VendorId = model.VendorId;
                    vd.VendorName = model.VendorName;
                    db.Vendor.Add(vd);
                    db.SaveChanges();

                    VendorTradeTerm vtt = new VendorTradeTerm();
                    vtt.VendorId = model.VendorId;
                    db.VendorTradeTerm.Add(vtt);
                    db.SaveChanges();

                    //VendorCertification vcf = new VendorCertification();
                    //vcf.VendorId = model.VendorId;
                    //db.VendorCertification.Add(vcf);
                    //db.SaveChanges();

                    //VendorContact vc = new VendorContact();
                    //VendorMainCustomer vmc = new VendorMainCustomer();
                    //VendorManufacture vmf = new VendorManufacture();

                    //VendorMainProduct vmp = new VendorMainProduct();




                    //vc.VendorId = vendorid;
                    //vmc.VendorId = vendorid;
                    //vmf.VendorId = vendorid;

                    //vmp.VendorId = vendorid;



                    //db.VendorContact.Add(vc);
                    //db.VendorMainCustomer.Add(vmc);
                    //db.VendorManufacture.Add(vmf);
                    //
                    //db.VendorMainProduct.Add(vmp);


                    status = "true";
                }
                else
                {
                    status = "false";
                }
                return Json(status, JsonRequestBehavior.AllowGet);

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult EditArchitecture(string vendorId)
        {
            VendorViewModel model = new VendorViewModel();

            if (vendorId != null)
            {
                Vendor vendor = db.Vendor.SingleOrDefault(v => v.VendorId == vendorId);
                model.VendorName = vendor.VendorName;
            }

            //#region Trade Term List Data
            //List<SelectListItem> tradelist = new List<SelectListItem>();

            //tradelist.Add(new SelectListItem()
            //{
            //    Text = "EXW(Ex Work)",
            //    Value = "EXW"
            //});
            //tradelist.Add(new SelectListItem()
            //{
            //    Text = "EXF(Ex Factory)",
            //    Value = "EXF"
            //});
            //tradelist.Add(new SelectListItem()
            //{
            //    Text = "FOB(Free On Board)",
            //    Value = "FOB"
            //});
            //tradelist.Add(new SelectListItem()
            //{
            //    Text = "FAS(Free Alongside Ship)",
            //    Value = "FAS"
            //});
            //tradelist.Add(new SelectListItem()
            //{
            //    Text = "FCA(Free Carrier)",
            //    Value = "FCA"
            //});
            //tradelist.Add(new SelectListItem()
            //{
            //    Text = "CIP(Carriage and Insurance Paid to)",
            //    Value = "CIP"
            //});
            //tradelist.Add(new SelectListItem()
            //{
            //    Text = "(Carriage Paid to)",
            //    Value = "CPT"
            //});
            //tradelist.Add(new SelectListItem()
            //{
            //    Text = "(Cost, Insurance & Freight)",
            //    Value = "CIF"
            //});
            //tradelist.Add(new SelectListItem()
            //{
            //    Text = "CIF&C(Cost, Insurance & Freight & Commission)",
            //    Value = "CIF&C"
            //});

            //ViewBag.TradeTermList = tradelist;

            //#endregion


            return PartialView("EditArchitectureAddPartial", model);

        }

    }
}