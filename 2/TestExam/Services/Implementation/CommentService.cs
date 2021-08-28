using Data.Base.Repositories;
using Data.Base.UnitOfWork;
using Data.Entities;
using Model.Request;
using Services.Interfaces;
using Services.Paging;
using Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CommentService : BaseService, ICommentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Comment> _commentReps;
        private readonly IRepository<User> _userReps;

        public CommentService(IUnitOfWork uow,
            IRepository<Comment> commentReps,
            IRepository<User> userReps)
        {
            _uow = uow;
            _commentReps = commentReps;
            _userReps = userReps;
        }

        public async Task<TResponse<bool>> Add(AddComment request)
        {
            try
            {
                if (request == null
                    || request.ArticleId < 1
                    || request.UserId < 1
                    || string.IsNullOrEmpty(request.Content))
                    return await Fail<bool>("Invalid param");

                var user = _userReps.Get(x => x.Id == request.UserId &&
                    (x.Status == null || x.Status != (int)Data.Enum.Status.Deleted))?.FirstOrDefault();

                if (user == null || user.Id < 1)
                {
                    return await Fail<bool>("Invalid user");
                }
                var comment = new Comment
                {
                    ArticleId = request.ArticleId,
                    UserId = request.UserId,
                    Content = request.Content,
                    CreatedBy = request.UserId,
                    CreatedDate = DateTime.Now
                };

                _uow.BeginTransaction();

                await _commentReps.Add(comment);

                _uow.Commit();

                return await Ok(true);
            }
            catch (Exception ex)
            {
                _uow.Rollback();

                return await Fail<bool>(ex.Message);
            }
        }

        public async Task<TResponse<PagedResult<Model.Response.Comment>>> GetListAsync(int articleId, int page, int pageSize)
        {
            try
            {
                var query = _commentReps.Get(x => x.ArticleId == articleId &&
                            (x.Status == null || x.Status != (int)Data.Enum.Status.Deleted)).OrderByDescending(x => x.Id);

                var paging = await query.ToPagedResultAsync(page, pageSize);

                if (paging.Data == null || paging.Data.Count < 1)
                    return await Ok(new PagedResult<Model.Response.Comment>());

                var lstUserId = paging.Data.Select(x => x.UserId).Distinct();

                var lstUser = _userReps.Get(x => lstUserId.Any(z => z == x.Id) &&
                                (x.Status == null || x.Status != (int)Data.Enum.Status.Deleted)).ToList();

                var lstComment = new List<Model.Response.Comment>();

                foreach (var x in paging.Data)
                {
                    lstComment.Add(new Model.Response.Comment
                    {
                        Content = x.Content,
                        User = lstUser.Where(z => z.Id == x.UserId).Select(x => new Model.Response.User
                        {
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            UserName = x.UserName
                        })?.FirstOrDefault()
                    });
                }

                return await Ok(new PagedResult<Model.Response.Comment>
                {
                    CurrentPage = paging.CurrentPage,
                    Data = lstComment,
                    TotalCount = paging.TotalCount,
                    TotalPages = paging.TotalPages,
                    ResultsPerPage = paging.ResultsPerPage
                });
            }
            catch (Exception ex)
            {
                return await Fail<PagedResult<Model.Response.Comment>>(ex.Message);
            }
        }
    }
}