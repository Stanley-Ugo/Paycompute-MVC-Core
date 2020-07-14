using Microsoft.AspNetCore.Mvc;
using Paycompute.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paycompute.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayComputationService _payComputationService;

        public PayController(IPayComputationService payComputationService)
        {
            _payComputationService = payComputationService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
