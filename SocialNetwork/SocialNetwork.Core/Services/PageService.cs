using SocialNetwork.Core.Constants;
using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Model.Page;
using SocialNetwork.Domain.Model.Post;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Interfaces.Services;

namespace SocialNetwork.Core.Services
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;
        private readonly IRepository<Post> _repository;
        public PageService(IPageRepository pageRepository, IRepository<Post> repository)
        {
            _pageRepository = pageRepository;
            _repository = repository;
        }
        public async Task<Response<string>> CreatePageAsync(PageRequestModel pageRequest, long userId)
        {
            await _pageRepository.CreateAsync(new Page
            {
                Name = pageRequest.Name,
                CreatorId = userId
            });
            int rows = await _pageRepository.SaveChangesAsync();
            if (rows > 0)
                return new Response<string>
                {
                    Success = true,
                    Message = ReposneMessageConstant.PAGE_CREATED,
                    Result = pageRequest.Name
                };

            return new Response<string>
            {
                Success = false,
                Message = ReposneMessageConstant.PAGE_CREATE_FAILED,
                Result = null
            };

        }

        public async Task<Response<long>> PostPageStatusAsync(long pageId, long userId, PostRequestModel postRequest)
        {
            var page = await _pageRepository.GetPageAsync(pageId, userId);
            if (page == null)
                return new Response<long>
                {
                    Success = false,
                    Message = ReposneMessageConstant.PAGE_NOT_FOUND,
                    Result = 0
                };
            Post post = new()
            {
                Status = postRequest.Post,
                CreatedByPage = pageId
            };
            await _repository.CreateAsync(post);
            int rows = await _pageRepository.SaveChangesAsync();
            if (rows > 0)
                return new Response<long>
                {
                    Success = true,
                    Message = ReposneMessageConstant.POST_CREATED,
                    Result = post.Id
                };

            return new Response<long>
            {
                Success = false,
                Message = ReposneMessageConstant.POST_CREATE_FAILED,
                Result = 0
            };

        }
    }
}
