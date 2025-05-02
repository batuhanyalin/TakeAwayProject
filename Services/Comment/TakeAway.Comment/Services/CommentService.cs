using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TakeAway.Comment.Context;
using TakeAway.Comment.Dtos;
using TakeAway.Comment.Entities;

namespace TakeAway.Comment.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentContext _commentContext;
        private readonly IMapper _mapper;
        public CommentService(CommentContext commentContext, IMapper mapper)
        {
            _commentContext = commentContext;
            _mapper = mapper;
        }

        public async Task CreateUserCommentAsync(CreateUserCommentDto userCommentDto)
        {
            var value = _mapper.Map<UserComment>(userCommentDto);
            await _commentContext.UserComments.AddAsync(value);
            await _commentContext.SaveChangesAsync();
        }

        public async Task DeleteUserCommentAsync(int id)
        {
            var value = await _commentContext.UserComments.FindAsync(id);
            _commentContext.UserComments.Remove(value);
            await _commentContext.SaveChangesAsync();
        }

        public async Task<List<GetByProductIdUserCommandDto>> GetAllByProductIdUserCommandAsync(string id)
        {
            var values = await _commentContext.UserComments.Where(x => x.ProductId == id).ToListAsync();
            var map = _mapper.Map<List<GetByProductIdUserCommandDto>>(values);
            return map;
        }

        public async Task<List<ResultUserCommentDto>> GetAllUserCommentAsync()
        {
            var values = await _commentContext.UserComments.ToListAsync();
            var map = _mapper.Map<List<ResultUserCommentDto>>(values);
            return map;

        }

        public async Task<GetByIdUserCommentDto> GetByIdUserCommentAsync(int id)
        {
            var values = await _commentContext.UserComments.FindAsync(id);
            var map = _mapper.Map<GetByIdUserCommentDto>(values);
            return map;
        }

        public async Task UpdateUserCommentAsync(UpdateUserCommentDto userCommentDto)
        {
            var map = _mapper.Map<UserComment>(userCommentDto);
            _commentContext.UserComments.Update(map);
            await _commentContext.SaveChangesAsync();

            
        }
    }
}
