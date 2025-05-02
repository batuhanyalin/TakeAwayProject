namespace TakeAway.Comment.Dtos
{
    public class GetByProductIdUserCommandDto
    {
        public int UserCommandId { get; set; }
        public string NameSurname { get; set; }
        public string UserId { get; set; }
        public string CommentDetail { get; set; }
        public string ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
