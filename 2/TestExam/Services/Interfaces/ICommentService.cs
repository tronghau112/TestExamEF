using Model.Request;
using Services.Paging;
using Services.Result;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICommentService
    {
        Task<TResponse<bool>> Add(AddComment request);

        Task<TResponse<PagedResult<Model.Response.Comment>>> GetListAsync(int articleId, int page, int pageSize);
    }
}