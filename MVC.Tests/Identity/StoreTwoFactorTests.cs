﻿using System.Diagnostics.CodeAnalysis;
using MVC.Identity;
using NSubstitute;
using NUnit.Framework;

namespace MVC.Tests.Identity
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class StoreTwoFactorTests : BaseRepositoryTest
    {
        private Store uut;

        [SetUp]
        public void Setup()
        {
            uut = new Store(Factory);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void SetTwoFactorEnabled_NoMatterTheInput_DoesNothing(bool input)
        {
            string userName = "test";

            // Setup the repository.
            var user = new IdentityUser()
            {
                UserName = userName
            };

            uut.SetTwoFactorEnabledAsync(user, input).Wait();

            Assert.That(UserRepository.ReceivedCalls(), Is.Empty);
        }

        [Test]
        public void GetTwoFactorEnabled_NoMatterTheInput_ReturnsFalse()
        {
            string userName = "test";

            // Setup the repository.
            var user = new IdentityUser()
            {
                UserName = userName
            };

            var result = uut.GetTwoFactorEnabledAsync(user).Result;

            Assert.That(result, Is.False);
        }
    }
}
