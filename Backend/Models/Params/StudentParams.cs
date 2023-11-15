using Backend.Utils;

namespace Backend.Models.Params
{
    public record StudentParams : RequestParams
    {
        public StudentFilterBy? FilterBy { get; init; }
        public StudentSortBy? SortBy { get; set; }
    }
}
