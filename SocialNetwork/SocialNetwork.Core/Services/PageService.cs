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
        private readonly IRepository _repository;
        public PageService(IPageRepository pageRepository, IRepository repository)
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
                    Message = "Page created",
                    Result = pageRequest.Name
                };

            return new Response<string>
            {
                Success = false,
                Message = "Failed to create page",
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
                    Message = "Page not found",
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
                    Message = "Post created",
                    Result = post.Id
                };

            return new Response<long>
            {
                Success = false,
                Message = "Failed to create post",
                Result = 0
            };

        }
    }
}
