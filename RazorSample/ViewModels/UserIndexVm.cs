using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorSample.ViewModels
{
    public class UserIndexVm
    {
        public SelectList Roles { get; set; }
        public PaginatedList<UserDto> Users { get; set; }
    }
}