using LegacyApp;
using LegacyApp.Implementations;

namespace LegacyAppTests
{
    public class UserServiceTests
    {
        [Fact]
        public void Add_User_Should_Return_True_When_Everything_OK()
        {
            //Arrange
            string firstName = "John";
            string lastName = "Doe";
            string email = "johndoe@gmail.com";
            DateTime bdate = DateTime.Parse("1982-03-21");
            int clientId = 1;
            var userService = new UserService(new Validator(), new UserCreditService(), new ClientRepository(new UserCreditService()));


            //Act
            bool result = userService.AddUser(firstName, lastName, email, bdate, clientId);


            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_User_Should_Return_False_When_Email_Without_Dot_And_At()
        {
            //Arrange
            string firstName = "John";
            string lastName = "Doe";
            string email = "johndoegmailcom";
            DateTime bdate = DateTime.Parse("1982-03-21");
            int clientId = 1;
            var userService = new UserService(new Validator(), new UserCreditService(), new ClientRepository(new UserCreditService()));


            //Act
            bool result = userService.AddUser(firstName, lastName, email, bdate, clientId); 


            //Assert
            Assert.False(result);
        }
        [Fact]
        public void Add_User_Should_Return_False_When_Name_Is_Null()
        {
            //Arrange
            string firstName = null;
            string lastName = "Doe";
            string email = "johndoe@gmail.com";
            DateTime bdate = DateTime.Parse("1982-03-21");
            int clientId = 1;
            var userService = new UserService(new Validator(), new UserCreditService(), new ClientRepository(new UserCreditService()));


            //Act
            bool result = userService.AddUser(firstName, lastName, email, bdate, clientId);


            //Assert
            Assert.False(result);
        }
        [Fact]
        public void Add_User_Should_Return_False_When_Surename_Is_Null()
        {
            //Arrange
            string firstName = "John";
            string lastName = null;
            string email = "johndoe@gmail.com";
            DateTime bdate = DateTime.Parse("1982-03-21");
            int clientId = 1;
            var userService = new UserService(new Validator(), new UserCreditService(), new ClientRepository(new UserCreditService()));


            //Act
            bool result = userService.AddUser(firstName, lastName, email, bdate, clientId);


            //Assert
            Assert.False(result);
        }
        [Fact]
        public void Add_User_Should_Return_False_When_User_Is_Not_Old_Enough()
        {
            //Arrange
            string firstName = "John";
            string lastName = "Doe";
            string email = "johndoe@gmail.com";
            DateTime bdate = DateTime.Parse("2023-03-21");
            int clientId = 1;
            var userService = new UserService(new Validator(), new UserCreditService(), new ClientRepository(new UserCreditService()));


            //Act
            bool result = userService.AddUser(firstName, lastName, email, bdate, clientId);


            //Assert
            Assert.False(result);
        }
        [Fact]
        public void Add_User_Should_Return_False_When_User_Has_Credit_Limit_Less_Than_500()
        {
            //Arrange
            string firstName = "Jan";
            string lastName = "Kowalski";
            string email = "kowalski@wp.pl";
            DateTime bdate = DateTime.Parse("1980-03-21");
            int clientId = 1;
            var userService = new UserService(new Validator(), new UserCreditService(), new ClientRepository(new UserCreditService()));


            //Act
            bool result = userService.AddUser(firstName, lastName, email, bdate, clientId);


            //Assert
            Assert.False(result);
        }
        [Fact]
        public void Add_User_Should_Return_True_When_User_Is_Very_Important_Client()
        {
            //Arrange
            string firstName = "Micha³";
            string lastName = "Malewski";
            string email = "malewski@gmail.pl";
            DateTime bdate = DateTime.Parse("1980-03-21");
            int clientId = 2;
            var userService = new UserService(new Validator(), new UserCreditService(), new ClientRepository(new UserCreditService()));


            //Act
            bool result = userService.AddUser(firstName, lastName, email, bdate, clientId);


            //Assert
            Assert.True(result);
        }
        [Fact]
        public void Add_User_Should_Return_True_When_User_Is_Important_Client_And_Limit_Greater_Than_500()
        {
            //Arrange
            string firstName = "Will";
            string lastName = "Smith";
            string email = "smith@gmail.pl";
            DateTime bdate = DateTime.Parse("1980-03-21");
            int clientId = 3;
            var userService = new UserService(new Validator(), new UserCreditService(), new ClientRepository(new UserCreditService()));


            //Act
            bool result = userService.AddUser(firstName, lastName, email, bdate, clientId);


            //Assert
            Assert.True(result);
        }
    }
}