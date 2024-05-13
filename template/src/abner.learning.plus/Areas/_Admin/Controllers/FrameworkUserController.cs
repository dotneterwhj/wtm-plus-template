﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;
using Abner.Learning.Plus.Model;


namespace Abner.Learning.Plus._Admin.Controllers
{
    [AuthorizeJwtWithCookie]
    public partial class FrameworkUserController : BaseApiController
    {
                                                        
        [ActionDescription("Sys.Search")]
        [HttpPost("[action]")]
        public IActionResult SearchFrameworkUser(Abner.Learning.Plus.ViewModel._Admin.FrameworkUserVMs.FrameworkUserSearcher searcher)
        {
            if (ConfigInfo.HasMainHost && Wtm.LoginUserInfo?.CurrentTenant == null)
            {
                return Request.RedirectCall(Wtm).Result;
            }
            if (ModelState.IsValid)
            {
                var vm = Wtm.CreateVM<Abner.Learning.Plus.ViewModel._Admin.FrameworkUserVMs.FrameworkUserListVM>();
                vm.Searcher = searcher;
                return Content(vm.GetJson());
            }
            else
            {
                return BadRequest(ModelState.GetErrorJson());
            }
        }

        [ActionDescription("Sys.Export")]
        [HttpPost("[action]")]
        public IActionResult FrameworkUserExportExcel(Abner.Learning.Plus.ViewModel._Admin.FrameworkUserVMs.FrameworkUserSearcher searcher)
        {
            if (ConfigInfo.HasMainHost && Wtm.LoginUserInfo?.CurrentTenant == null)
            {
                ModelState.AddModelError(" mh", Localizer["_Admin.HasMainHost"]);
                return BadRequest(ModelState.GetErrorJson());
            }
            var vm = Wtm.CreateVM<Abner.Learning.Plus.ViewModel._Admin.FrameworkUserVMs.FrameworkUserListVM>();
            vm.Searcher = searcher;
            vm.SearcherMode = ListVMSearchModeEnum.Export;
            return vm.GetExportData();
        }

        [ActionDescription("Sys.CheckExport")]
        [HttpPost("[action]")]
        public IActionResult FrameworkUserExportExcelByIds(string[] ids)
        {
            if (ConfigInfo.HasMainHost && Wtm.LoginUserInfo?.CurrentTenant == null)
            {
                ModelState.AddModelError(" mh", Localizer["_Admin.HasMainHost"]);
                return BadRequest(ModelState.GetErrorJson());
            }
            var vm = Wtm.CreateVM<Abner.Learning.Plus.ViewModel._Admin.FrameworkUserVMs.FrameworkUserListVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = new List<string>(ids);
                vm.SearcherMode = ListVMSearchModeEnum.CheckExport;
            }
            return vm.GetExportData();
        }
    
    }
}


