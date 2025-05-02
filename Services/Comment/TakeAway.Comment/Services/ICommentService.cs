using TakeAway.Comment.Dtos;

namespace TakeAway.Comment.Services
{
    public interface ICommentService
    {
        Task<List<ResultUserCommentDto>> GetAllUserCommentAsync();
            Task CreateUserCommentAsync(CreateUserCommentDto userCommentDto);
        Task UpdateUserCommentAsync(UpdateUserCommentDto userCommentDto);
        Task DeleteUserCommentAsync(int id);
        Task<GetByIdUserCommentDto> GetByIdUserCommentAsync(int id);
        Task<List<GetByProductIdUserCommandDto>> GetAllByProductIdUserCommandAsync(string id);
    }
}
