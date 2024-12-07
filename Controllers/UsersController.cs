using Microsoft.AspNetCore.Mvc;
using AnhTran.RedactingSensitiveData.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnhTran.RedactingSensitiveData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        public UsersController(ILogger<UsersController> logger)
        {
            this.logger = logger;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Adddress = "123 Ho Chi Minh",
                    CreditCardNumbers = "0520123456789",
                    DateOfBirth = new DateTime(1990,01,01),
                    Email = "myemail@mycompany.com",
                    Ethnic  = "Kinh",
                    FavouritSport = "Football",
                    FullName = "Philip Nguyen",
                    Id = 1,
                    JoinDate = new DateTime(2024,01,01),
                    Religious ="Chritiant",
                    Salary  = 10000
                },
                 new User()
                {
                    Adddress = "456 Ho Chi Minh",
                    CreditCardNumbers = "0529876543210",
                    DateOfBirth = new DateTime(2000,11,11),
                    Email = "Codedao@codedao.com",
                    Ethnic  = "Khơ Me",
                    FavouritSport = "Football",
                    FullName = "Phan Van Santos",
                    Id = 1,
                    JoinDate = new DateTime(2024,01,01),
                    Religious ="Buddist",
                    Salary  = 60000
                }
            };

            foreach (var user in users)
            {
                LogHelper.LogInfoUser(logger, user);
            }
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = new User()
            {
                Adddress = "123 Ho Chi Minh",
                CreditCardNumbers = "0520123456789",
                DateOfBirth = new DateTime(1990, 01, 01),
                Email = "myemail@mycompany.com",
                Ethnic = "Kinh",
                FavouritSport = "Football",
                FullName = "Philip Nguyen",
                Id = 1,
                JoinDate = new DateTime(2024, 01, 01),
                Religious = "Chritiant",
                Salary = 10000
            };

            LogHelper.LogInfoUser(logger, user);
            return user;
        }
    }
}
