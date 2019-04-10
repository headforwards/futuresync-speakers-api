using FutureSyncSpeakersAPI.Models;
using FutureSyncSpeakersAPI.Providers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace FutureSyncSpeakersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        public ISpeakerCacheProvider SpeakerCacheProvider { get; set; }

        public SpeakersController(IHostingEnvironment hostingEnvironment)
        {
            SpeakerCacheProvider = new SpeakerCacheProvider(
                Path.Combine(
                    hostingEnvironment.ContentRootPath,
                    "Data",
                    Constants.CacheFileName));
        }

        [HttpGet]
        public IEnumerable<Speaker> Get()
        {
            return SpeakerCacheProvider.Get();
        }

        [HttpGet("{update}")]
        public IEnumerable<Speaker> Get(string update)
        {
            bool updateCache = update?.ToLower() == "update";

            return updateCache
                ? SpeakerCacheProvider.Update()
                : SpeakerCacheProvider.Get();
        }
    }
}