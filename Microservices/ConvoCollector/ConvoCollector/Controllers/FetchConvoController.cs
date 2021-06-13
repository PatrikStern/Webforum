using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvoCollector.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConvoCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetchConvoController : ControllerBase
    {
        private WebforumContext _context;

        public FetchConvoController(WebforumContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CollectConversation([FromBody] ThreadIDModel ThreadID)
        {
            var conversation = await _context.Posts.Where(x => x.PostThreadId == ThreadID.ThreadID).ToListAsync();

            if (conversation == null) 
            {
                return NotFound();
            }
            else
            {
                return Ok(conversation);
            }
        }
    }
}
