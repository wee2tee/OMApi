using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMApi.Models;

namespace OMApi.MiscClass
{
    public static class Helper
    {
        public static List<PopritVM> ToViewModel(this IEnumerable<Poprit> source_list)
        {
            List<PopritVM> poprit_vm = new List<PopritVM>();
            foreach (var item in source_list)
            {
                poprit_vm.Add(new PopritVM
                {
                    Id = item.Id,
                    PoNum = item.Popr.PoNum,
                    PoDat = item.Popr.PoDat,
                    DlvBy = item.Popr.Istab1.TypDesTh,
                    DlvDat1 = item.Popr.DlvDate1,
                    DlvDat2 = item.Popr.DlvDate2,
                    Remark = item.Popr.Remark,
                    StkCod = item.Stmas.Stkcod,
                    StkDes = item.StkDes,
                    OrdQty = item.OrdQty,
                    TquCod = item.Istab.TypDesTh,
                    UnitPrice = item.UnitPrice,
                    DiscAmt = item.DiscAmt,
                    TrnVal = item.TrnVal,
                    VatAmt = item.Popr.VatAmt,
                    TaxAmt = item.Popr.TaxAmt,
                    NetAmt = item.Popr.NetAmt,
                    CreBy = item.Popr.AspNetUsers2.FullName,
                    CreDate = item.Popr.CreDate,
                    CustPreName = item.Popr.CustPreName,
                    CustName = item.Popr.CustName,
                    CustAddr01 = item.Popr.CustAddr01,
                    CustAddr02 = item.Popr.CustAddr02,
                    CustAddr03 = item.Popr.CustAddr03,
                    CustZipCod = item.Popr.CustZipCod,
                    CustTelNum = item.Popr.CustTelNum,
                    CustFaxNum = item.Popr.CustFaxNum,
                    CustTaxId = item.Popr.CustTaxId,
                    Status = item.Popr.Status,
                    SlipFileName = item.Popr.SlipFileName,
                    TaxFileName = item.Popr.TaxFileName,
                });
            }

            return poprit_vm;
        }

        public static PopritVM ToViewModel(this Poprit source)
        {
            if (source == null)
                return null;

            PopritVM poprit_vm = new PopritVM
            {
                Id = source.Id,
                PoNum = source.Popr.PoNum,
                PoDat = source.Popr.PoDat,
                DlvBy = source.Popr.Istab1.TypDesTh,
                DlvDat1 = source.Popr.DlvDate1,
                DlvDat2 = source.Popr.DlvDate2,
                Remark = source.Popr.Remark,
                StkCod = source.Stmas.Stkcod,
                StkDes = source.StkDes,
                OrdQty = source.OrdQty,
                TquCod = source.Istab.TypDesTh,
                UnitPrice = source.UnitPrice,
                DiscAmt = source.DiscAmt,
                TrnVal = source.TrnVal,
                VatAmt = source.Popr.VatAmt,
                TaxAmt = source.Popr.TaxAmt,
                NetAmt = source.Popr.NetAmt,
                CreBy = source.Popr.AspNetUsers2.FullName,
                CreDate = source.Popr.CreDate,
                CustPreName = source.Popr.CustPreName,
                CustName = source.Popr.CustName,
                CustAddr01 = source.Popr.CustAddr01,
                CustAddr02 = source.Popr.CustAddr02,
                CustAddr03 = source.Popr.CustAddr03,
                CustZipCod = source.Popr.CustZipCod,
                CustTelNum = source.Popr.CustTelNum,
                CustFaxNum = source.Popr.CustFaxNum,
                CustTaxId = source.Popr.CustTaxId,
                Status = source.Popr.Status,
                SlipFileName = source.Popr.SlipFileName,
                TaxFileName = source.Popr.TaxFileName
            };

            return poprit_vm;
        }
    }
}