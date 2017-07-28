﻿using System;
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
            Assert.IsFalse(vm.IsFormValid);
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Username = "testuser";
            Assert.IsFalse(vm.IsFormValid);
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Password = "testpassword";
            Assert.IsFalse(vm.IsFormValid);
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Username = string.Empty;
            Assert.IsFalse(vm.IsFormValid);
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Username = "     ";
            Assert.IsFalse(vm.IsFormValid);
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Password = "      ";
            Assert.IsFalse(vm.IsFormValid);
            Assert.IsFalse(vm.LoginCommand.CanExecute(null));

            vm.Username = "test@test.com";
            vm.Password = "test123!";
            Assert.IsTrue(vm.IsFormValid);
            Assert.IsTrue(vm.LoginCommand.CanExecute(null));
        }
    }
}
