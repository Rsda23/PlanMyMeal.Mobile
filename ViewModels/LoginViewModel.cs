using PlanMyMeal_Domain.Services;

namespace PlanMyMeal_Domain.ViewModels
{

    public partial class LoginViewModel
    {
        private readonly UsersService _usersService;
        public LoginViewModel(UsersService usersService)
        {
            _usersService = usersService;
        }
    }
}
