using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.DTOs;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Model.Post;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Interfaces.Services;

namespace SocialNetwork.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;
        private readonly IPostRepository _postRepository;

        public PersonService(IRepository<Person> repository, IPostRepository postRepository)
        {
            _repository = repository;
            _postRepository = postRepository;
        }

        public async Task<Response<long>> PostStatusAsync(long userId, PostRequestModel postRequest)
        {
            var person = await _repository.GetByIdAsync(userId);
            if (person == null)
                return new Response<long>
                {
                    Success = false,
                    Message = "User not found",
                    Result = 0
                };
            Post post = new()
            {
                Status = postRequest.Post,
                CreatedByPage = userId
            };
            await _postRepository.CreateAsync(post);
            int rows = await _postRepository.SaveChangesAsync();
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

        public async Task<Response<IEnumerable<PostResponseModel>>> GetFeedPostsAsync(long userId)
        {
            var person = await _repository.GetByIdAsync(userId);
            if (person == null)
                return new Response<IEnumerable<PostResponseModel>>
                {
                    Success = false,
                    Message = "User not found",
                    Result = null
                };
            IEnumerable<PostDto> posts = await _postRepository.GetFeedPostsAsync(userId);

            return new Response<IEnumerable<PostResponseModel>>
            {
                Success = true,
                Message = "Suceess",
                Result = posts.Select(s => new PostResponseModel
                {
                    Post = s.Status,
                    Author = s.CreatedBy,
                    PublishDate = s.CreatedDate
                })
            };

        }
    }
}
