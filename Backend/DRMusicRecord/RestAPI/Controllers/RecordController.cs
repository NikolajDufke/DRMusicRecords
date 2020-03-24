﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private List<Record> Records = new List<Record>()
        {
            new Record(){Artist = "JAAIIL", Duration = new TimeSpan(0,2,53),Title = "Superhelten", YearOfPublication = 2020},
            new Record(){Artist = "Karla og Liva", Duration = new TimeSpan(0,2,57), Title = "Brug din fantasi", YearOfPublication = 2020},
            new Record(){Artist = "Julie", Duration = new TimeSpan(0,2,57), Title = "Stjernen i det blå", YearOfPublication = 2020},
            new Record(){Artist = "Siff", Duration = new TimeSpan(0, 2,41), Title = "Mit hjerte der griner", YearOfPublication = 2020},
            new Record(){Artist = "Mynthe", Duration = new TimeSpan(0,2,36), Title = "Syng det ud", YearOfPublication = 2020},
            new Record(){Artist = "Liva", Duration = new TimeSpan(0,2,54), Title = "Ingen plan B", YearOfPublication = 2020},
            new Record(){Artist = "William", Duration = new TimeSpan(0,2,59), Title = "Stjerneskud", YearOfPublication=2020 },
            new Record(){Artist = "D&A", Duration = new TimeSpan(0,2,58), Title = "Boombadah basta", YearOfPublication = 2020}
        };

        // GET: api/Record
        [HttpGet]
        public IEnumerable<Record> Get()
        {
            return Records;
        }

        // GET: api/Record/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Record
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Record/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
