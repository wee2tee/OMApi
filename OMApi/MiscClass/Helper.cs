using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMApi.Models;

namespace OMApi.MiscClass
{
    public enum DEALER_TYPE : int
    {
        ไม่ระบุ = 0,
        ตัวแทนจำหน่ายทั่วไป = 1,
        ตัวแทนจำหน่ายรายใหญ่ = 2,
        สำนักงานบัญชีไฮเทค = 3
    }

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
                    SoNum = item.SoNum,
                    SoDat = item.SoDat,
                    SoBy = item.SoBy, //(item.InternalUsers == null ? "" : item.InternalUsers.FullName),
                    SoRemark = item.SoRemark,
                    IvNum = item.IvNum,
                    IvDat = item.IvDat,
                    IvBy = item.IvBy, //(item.InternalUsers1 == null ? "" : item.InternalUsers1.FullName),
                    IvRemark = item.IvRemark,
                    EmsTracking = item.EmsTracking,
                    FlgVat = item.Popr.VatAmt > 0 ? "2" : "0",
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
                    DealerCode = item.Popr.AspNetUsers2.DealerCode,
                    DealerType = item.Popr.AspNetUsers2.DealerType,
                    //CustPreName = item.Popr.CustPreName,
                    //CustName = item.Popr.CustName,
                    //CustAddr01 = item.Popr.CustAddr01,
                    //CustAddr02 = item.Popr.CustAddr02,
                    //CustAddr03 = item.Popr.CustAddr03,
                    //CustZipCod = item.Popr.CustZipCod,
                    //CustTelNum = item.Popr.CustTelNum,
                    //CustFaxNum = item.Popr.CustFaxNum,
                    //CustTaxId = item.Popr.CustTaxId,
                    Status = item.Popr.Status,
                    SlipFileName = item.Popr.SlipFileName,
                    TaxFileName = item.Popr.TaxFileName,

                    cust = new List<CustVM>
                    {
                        new CustVM
                        {
                            PreName = item.Popr.CustPreName,
                            Name = item.Popr.CustName,
                            Addr01 = item.Popr.CustAddr01,
                            Addr02 = item.Popr.CustAddr02,
                            Addr03 = item.Popr.CustAddr03,
                            ZipCod = item.Popr.CustZipCod,
                            TelNum = item.Popr.CustTelNum,
                            FaxNum = item.Popr.CustFaxNum,
                            TaxId = item.Popr.CustTaxId
                        }
                    }
                });
            }

            return poprit_vm;
        }

        public static PopritVM ToViewModel(this Poprit item)
        {
            if (item == null)
                return null;

            PopritVM poprit_vm = new PopritVM
            {
                Id = item.Id,
                PoNum = item.Popr.PoNum,
                PoDat = item.Popr.PoDat,
                SoNum = item.SoNum,
                SoDat = item.SoDat,
                SoBy = item.SoBy, //(item.InternalUsers == null ? "" : item.InternalUsers.FullName),
                SoRemark = item.SoRemark,
                IvNum = item.IvNum,
                IvDat = item.IvDat,
                IvBy = item.IvBy, //(item.InternalUsers1 == null ? "" : item.InternalUsers1.FullName),
                IvRemark = item.IvRemark,
                EmsTracking = item.EmsTracking,
                FlgVat = item.Popr.VatAmt > 0 ? "2" : "0",
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
                DealerCode = item.Popr.AspNetUsers2.DealerCode,
                DealerType = item.Popr.AspNetUsers2.DealerType,
                //CustPreName = item.Popr.CustPreName,
                //CustName = item.Popr.CustName,
                //CustAddr01 = item.Popr.CustAddr01,
                //CustAddr02 = item.Popr.CustAddr02,
                //CustAddr03 = item.Popr.CustAddr03,
                //CustZipCod = item.Popr.CustZipCod,
                //CustTelNum = item.Popr.CustTelNum,
                //CustFaxNum = item.Popr.CustFaxNum,
                //CustTaxId = item.Popr.CustTaxId,
                Status = item.Popr.Status,
                SlipFileName = item.Popr.SlipFileName,
                TaxFileName = item.Popr.TaxFileName,

                cust = new List<CustVM>
                {
                    new CustVM
                    {
                        PreName = item.Popr.CustPreName,
                        Name = item.Popr.CustName,
                        Addr01 = item.Popr.CustAddr01,
                        Addr02 = item.Popr.CustAddr02,
                        Addr03 = item.Popr.CustAddr03,
                        ZipCod = item.Popr.CustZipCod,
                        TelNum = item.Popr.CustTelNum,
                        FaxNum = item.Popr.CustFaxNum,
                        TaxId = item.Popr.CustTaxId
                    }
                }
            };

            return poprit_vm;
        }

        public static List<InternalUsersVM> ToViewModel(this IEnumerable<InternalUsers> source_list)
        {
            List<InternalUsersVM> users = new List<InternalUsersVM>();
            foreach (InternalUsers item in source_list)
            {
                users.Add(new InternalUsersVM
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Email = item.Email,
                    PasswordHash = item.PasswordHash,
                    FullName = item.FullName,
                    Department = item.Department,
                    Status = item.Status,
                    CreDate = item.CreDate
                });
            }

            return users;
        }

        public static InternalUsersVM ToViewModel(this InternalUsers item)
        {
            if (item == null)
                return null;

            InternalUsersVM user = new InternalUsersVM()
            {
                Id = item.Id,
                UserName = item.UserName,
                Email = item.Email,
                PasswordHash = item.PasswordHash,
                FullName = item.FullName,
                Department = item.Department,
                Status = item.Status,
                CreDate = item.CreDate
            };

            return user;
        }
    }
}