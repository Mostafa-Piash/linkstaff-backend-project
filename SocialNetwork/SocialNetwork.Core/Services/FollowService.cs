using SocialNetwork.Core.Constants;
using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Interfaces.Services;

namespace SocialNetwork.Core.Services
{
    public class FollowService : IFollowService
    {
        private readonly IRepository<Follower> _repository;

        public FollowService(IRepository<Follower> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> FollowePageAsync(long pageId, long userId)
        {
            Follower follower = new()
            {
                FollowerId = userId,
                PageId = pageId,
            };
            await _repository.CreateAsync(follower);
            int rows = await _repository.SaveChangesAsync();
            if (rows > 0)
                return new Response<long>
                {
                    Success = true,
                    Message = ReposneMessageConstant.SUCCESS,
                    Result = follower.Id
                };

            return new Response<long>
            {
                Success = false,
                Message = ReposneMessageConstant.FAILED_TO_FOLLOW,
                Result = follower.Id
            };
        }

        public async Task<Response<long>> FollowePersonAsync(long personId, long userId)
        {
            Follower follower = new()
            {
                FollowerId = userId,
                PersonId = personId,
            };
            await _repository.CreateAsync(follower);
            int rows = await _repository.SaveChangesAsync();
            if (rows > 0)
                return new Response<long>
                {
                    Success = true,
                    Message = ReposneMessageConstant.SUCCESS,
                    Result = follower.Id
                };

            return new Response<long>
            {
                Success = false,
                Message = ReposneMessageConstant.FAILED_TO_FOLLOW,
                Result = follower.Id
            };
        }
    }
}
