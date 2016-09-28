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

        public static List<DealerVM> ToViewModel(this IEnumerable<AspNetUsers> source_list)
        {
            List<DealerVM> dealers = new List<DealerVM>();
            foreach (var item in source_list)
            {
                dealers.Add(new DealerVM
                {
                    Id = item.Id,
                    DealerCode = item.DealerCode,
                    DealerType = item.DealerType,
                    UserName = item.UserName,
                    SerNum = item.SerNum,
                    PreName = item.PreName,
                    FullName = item.FullName,
                    TaxId = item.TaxId,
                    Addr01 = item.Addr01,
                    Addr02 = item.Addr02,
                    Addr03 = item.Addr03,
                    ZipCod = item.ZipCod,
                    TelNum = item.TelNum,
                    FaxNum = item.FaxNum,
                    PriceCode = item.PriceCode,
                    DlvProfile = item.DlvProfile,
                    Disc = item.Disc,
                    DiscPerc = item.DiscPerc,
                    Disc2 = item.Disc2,
                    DiscPerc2 = item.DiscPerc2,
                    Status = item.Status,
                    ChgBy = item.ChgBy,
                    ChgDate = item.ChgDate
                });
            }

            return dealers;
        }

        public static DealerVM ToViewModel(this AspNetUsers item)
        {
            if (item == null)
                return null;

            DealerVM dealer = new DealerVM()
            {
                Id = item.Id,
                DealerCode = item.DealerCode,
                DealerType = item.DealerType,
                UserName = item.UserName,
                SerNum = item.SerNum,
                PreName = item.PreName,
                FullName = item.FullName,
                TaxId = item.TaxId,
                Addr01 = item.Addr01,
                Addr02 = item.Addr02,
                Addr03 = item.Addr03,
                ZipCod = item.ZipCod,
                TelNum = item.TelNum,
                FaxNum = item.FaxNum,
                PriceCode = item.PriceCode,
                DlvProfile = item.DlvProfile,
                Disc = item.Disc,
                DiscPerc = item.DiscPerc,
                Disc2 = item.Disc2,
                DiscPerc2 = item.DiscPerc2,
                Status = item.Status,
                ChgBy = item.ChgBy,
                ChgDate = item.ChgDate
            };

            return dealer;
        }

        public static List<StpriVM> ToViewModel(this IEnumerable<Stpri> source_list)
        {
            List<StpriVM> stpri = new List<StpriVM>();
            foreach (var item in source_list)
            {
                stpri.Add(new StpriVM
                {
                    Id = item.Id,
                    PriceCode = item.PriceCode,
                    Description = item.Description,
                    TabPr = item.TabPr,
                    Disc1 = item.Disc1,
                    DiscPerc1 = item.DiscPerc1,
                    Disc2 = item.Disc2,
                    DiscPerc2 = item.DiscPerc2,
                    RecBy = item.CreBy,
                    RecDate = item.CreDate,
                    ChgBy = item.ChgBy,
                    ChgDate = item.ChgDate
                });
            }

            return stpri;
        }

        public static StpriVM ToViewModel(this Stpri item)
        {
            if (item == null)
                return null;

            StpriVM stpri = new StpriVM()
            {
                Id = item.Id,
                PriceCode = item.PriceCode,
                Description = item.Description,
                TabPr = item.TabPr,
                Disc1 = item.Disc1,
                DiscPerc1 = item.DiscPerc1,
                Disc2 = item.Disc2,
                DiscPerc2 = item.DiscPerc2,
                RecBy = item.CreBy,
                RecDate = item.CreDate,
                ChgBy = item.ChgBy,
                ChgDate = item.ChgDate
            };

            return stpri;
        }

        public static List<IstabVM> ToViewModel(this IEnumerable<Istab> source_list)
        {
            List<IstabVM> istab = new List<IstabVM>();
            foreach (var item in source_list)
            {
                istab.Add(new IstabVM()
                {
                    Id = item.Id,
                    TabTyp = item.TabTyp,
                    TypCod = item.TypCod,
                    AbbreviateEn = item.AbbreviateEn,
                    AbbreviateTh = item.AbbreviateTh,
                    TypDesEn = item.TypDesEn,
                    TypDesTh = item.TypDesTh,
                    Rate = item.Rate,
                    CreBy = item.CreBy,
                    CreDate = item.CreDate,
                    ChgBy = item.ChgBy,
                    ChgDate = item.ChgDate
                });
            }

            return istab;
        }

        public static IstabVM ToViewModel(this Istab item)
        {
            if (item == null)
                return null;

            IstabVM istab = new IstabVM()
            {
                Id = item.Id,
                TabTyp = item.TabTyp,
                TypCod = item.TypCod,
                AbbreviateEn = item.AbbreviateEn,
                AbbreviateTh = item.AbbreviateTh,
                TypDesEn = item.TypDesEn,
                TypDesTh = item.TypDesTh,
                Rate = item.Rate,
                CreBy = item.CreBy,
                CreDate = item.CreDate,
                ChgBy = item.ChgBy,
                ChgDate = item.ChgDate
            };

            return istab;
        }

        public static List<DlvProfileVM> ToDlvProfileViewModel(this IEnumerable<Istab> source_list)
        {
            List<DlvProfileVM> dlv_profile = new List<DlvProfileVM>();
            foreach (var profile in source_list)
            {
                dlv_profile.Add(profile.ToDlvProfileViewModel());
            }

            return dlv_profile;
        }

        public static DlvProfileVM ToDlvProfileViewModel(this Istab item)
        {
            if (item == null)
                return null;

            OMApiEntities db = new OMApiEntities();

            DlvProfileVM dlv_profile = new DlvProfileVM()
            {
                Id = item.Id,
                TabTyp = item.TabTyp,
                TypCod = item.TypCod,
                AbbreviateEn = item.AbbreviateEn,
                AbbreviateTh = item.AbbreviateTh,
                TypDesEn = item.TypDesEn,
                TypDesTh = item.TypDesTh,
                CreBy = item.CreBy,
                CreDate = item.CreDate,
                ChgBy = item.ChgBy,
                ChgDate = item.ChgDate,
                dlv = new List<IstabVM>()
            };
            var profile_member = db.Dlvprofile.Where(p => p.ProfileId == item.Id);
            foreach (var member in profile_member)
            {
                var dlv = db.Istab.Where(i => i.Id == member.DlvId).FirstOrDefault();
                if (dlv == null)
                    continue;

                dlv_profile.dlv.Add(dlv.ToViewModel());
            }

            return dlv_profile;
        }
    }
}