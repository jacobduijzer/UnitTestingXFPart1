using System;
using NUnit.Framework;
using UnitTestingXF.ViewModels;

namespace UnitTestingXF.Tests.ViewModelsTests
{
    [TestFixture]
    public class LoginViewModelTests
    {
        [Test]
        public void VMCanConstruct()
        {
            var vm = new LoginViewModel();
            Assert.AreEqual(typeof(LoginViewModel), vm.GetType());
        }

        [Test]
        public void CannotLoginWithEmptyFormTest()
        {
            var vm = new LoginViewModel();
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));
        }

        [Test]
        public void CanLoginWithValidFormTest()
        {
            var vm = new LoginViewModel();
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Username = "testuser";
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Password = "testpassword";
            Assert.IsTrue(vm.LoginCommand.CanExecute(null));

            vm.Username = string.Empty;
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Username = "     ";
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Password = "      ";
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));
        }

        [Test]
        public void FormValidationTest()
        {
			var vm = new LoginViewModel();

            vm.Username = "test";
            vm.Password = "test";
            Assert.IsFalse(vm.IsFormValid);

            vm.Username = "test@test";
            vm.Password = "test";
            Assert.IsFalse(vm.IsFormValid);

            vm.Username = "test@test.com";
            vm.Password = "test123";
            Assert.IsFalse(vm.IsFormValid);

            vm.Username = "test@test";
            vm.Password = "test123!";
            Assert.IsFalse(vm.IsFormValid);

            vm.Username = "test";
            vm.Password = "test123!";
            Assert.IsFalse(vm.IsFormValid);

            vm.Username = "    ";
            vm.Password = "    ";
            Assert.IsFalse(vm.IsFormValid);

            vm.Username = "test@test.com";
            vm.Password = "test123!";
			Assert.IsTrue(vm.IsFormValid);
        }
    }
}
