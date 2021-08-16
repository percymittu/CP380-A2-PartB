using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        private readonly BlockList _blocklist;
        public BlocksController(BlockList blockList)
        {
            _blocklist = blockList;
        }

        /// <summary>
        /// Retrieve all the blocks in the chain
        /// </summary>
        /// <returns></returns>
        [Route("/Blocks")]
        [HttpGet]        
        public IActionResult Get()
        {
            DateTime dt = DateTime.Now;
            var block = new Block(dt, null, new List<Payload>());
            var result = new List<BlockSummary>()
            {
                new BlockSummary()
                {
                    Hash = block.Hash,
                    PreviousHash = block.PreviousHash,
                    TimeStamp = block.TimeStamp
                }
            };
            return Ok(result);
        }

        /// <summary>
        /// Retrieve a specific block
        /// </summary>
        /// <returns></returns>
        [Route("/Blocks/{hash}")]
        [HttpGet]
        public IActionResult GetHash(string hash)
        {
            DateTime dt = DateTime.Now;
            var block = new Block(dt, null, new List<Payload>());
            block.Hash = hash;
            return Ok(block);
        }

        /// <summary>
        /// Retrieve all payloads for a given block
        /// </summary>
        /// <returns></returns>
        [Route("/Blocks/{hash}/Payloads")]
        [HttpGet]
        public IActionResult GetPayload(string hash)
        {
            DateTime dt = DateTime.Now;
            var block = new Block(dt, null, new List<Payload>());
            block.Hash = hash;
            return Ok(block.Data);
        }
    }
}
