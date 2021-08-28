using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(Model.Request.AddComment request)
        {
            return Ok(await _commentService.Add(request));
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetList(int articleId, int page, int pageSize)
        {
            return Ok(await _commentService.GetListAsync(articleId, page, pageSize));
        }
    }
}