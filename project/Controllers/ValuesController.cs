﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FabioSereno.App_awsDotNetCoreAsyncCoffeeMachine.Interfaces;
using FabioSereno.App_awsDotNetCoreAsyncCoffeeMachine.Models;

namespace FabioSereno.App_awsDotNetCoreAsyncCoffeeMachine.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private ITaskRunner _coffeeMakerUtil;
        public ValuesController(ITaskRunner coffeeMakerUtil)
        {
            _coffeeMakerUtil = coffeeMakerUtil;
        }

        [HttpGet("RunAsync")]
        public async Task<List<LogItem>> RunAsync()
        {
            Log log;

            try
            {
                log = await _coffeeMakerUtil.RunAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to run process: " + exception.Message);
            }
            return log?.Get();
        }

        [HttpGet("Run")]
        public List<LogItem> Run()
        {
            Log log;

            try
            {
                log = _coffeeMakerUtil.Run();
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to run process: " + exception.Message);
            }
            return log?.Get();
        }
    }
}
