using System;
using FabPonto.Models;
using FabPonto.Tests;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestName()
        {
            UserObjectMother objectMother = new UserObjectMother();
            User user = objectMother.CreateCommomUser();

            Assert.True(user.Name == "Carson");
        }

        [Test]
        public void TestChangeWorkingState()
        {
            UserObjectMother objectMother = new UserObjectMother();
            User user = objectMother.CreateCommomUser();

            user.ChangeWorkingState();

            Assert.IsInstanceOf(typeof(WorkingState), user.WorkingState);
        }
    }
}