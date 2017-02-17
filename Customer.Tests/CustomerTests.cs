namespace Customer.Tests
{
    using NUnit.Framework;
    using System;
    using Moq;
    using App.Customer.Services;
    using App.Customer.Services.Concretes;


    [TestFixture]
    public class CustomerTests
    {

        [Test]
        public void GivenRequestIsNull_WhenAddCustomerIsCalled_ThenAnArgumentNullExceptionIsThrown()
        {
            // Given
            var passThrough = new Mock<ICustomerService>();
            var svc = new ValidatingCustomerService(passThrough.Object);

            // When
            TestDelegate td = () => svc.AddCustomer(null);

            // Then
            Assert.Throws<ArgumentNullException>(td.Invoke);
        }


        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GivenFirstNameIsEmpty_WhenAddCustomerIsCalled_ThenAnArgumentOutOfRangeExceptionIsThrown(string firstName)
        {
            var passThrough = new Mock<ICustomerService>();
            var request = new Mock<AddCustomerRequest>();
            request.Setup(x => x.SurName).Returns("surname");
            request.Setup(x => x.Email).Returns("email");
            request.Setup(x => x.DateOfBirth).Returns(DateTime.Now);
            request.Setup(x => x.CompanyId).Returns(0);
            request.Setup(x => x.FirstName).Returns(firstName);
            var svc = new ValidatingCustomerService(passThrough.Object);

            // When
            TestDelegate td = () => svc.AddCustomer(request.Object);

            // Then
            Assert.Throws<ArgumentOutOfRangeException>(td.Invoke);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GivenSurNameIsEmpty_WhenAddCustomerIsCalled_ThenAnArgumentOutOfRangeExceptionIsThrown(string surName)
        {
            var passThrough = new Mock<ICustomerService>();
            var request = new Mock<AddCustomerRequest>();
            request.Setup(x => x.FirstName).Returns("firstname");
            request.Setup(x => x.Email).Returns("email");
            request.Setup(x => x.DateOfBirth).Returns(DateTime.Now);
            request.Setup(x => x.CompanyId).Returns(0);
            request.Setup(x => x.SurName).Returns(surName);
            var svc = new ValidatingCustomerService(passThrough.Object);

            // When
            TestDelegate td = () => svc.AddCustomer(request.Object);

            // Then
            Assert.Throws<ArgumentOutOfRangeException>(td.Invoke);
        }

       
        [TestCase("01/01/2000")]
        public void GivenDateOfBirthIsNotValid_WhenAddCustomerIsCalled_ThenAnArgumentOutOfRangeExceptionIsThrown(string dob)
        {
            DateTime dateOfBirthInput = DateTime.Parse(dob);

            var ptResponse = new Mock<IAddCustomerResponse>();
            var passThrough = new Mock<ICustomerService>();
            passThrough.Setup(x => x.AddCustomer(It.IsAny<IAddCustomerRequest>())).Returns(ptResponse.Object);

            var request = new Mock<IAddCustomerRequest>();
            request.Setup(x => x.FirstName).Returns("firstname");
            request.Setup(x => x.SurName).Returns("surname");
            request.Setup(x => x.CompanyId).Returns(0);
            request.Setup(x => x.DateOfBirth).Returns(dateOfBirthInput);
            var svc = new ValidatingCustomerService(passThrough.Object);

            // When
            TestDelegate td = () => svc.AddCustomer(request.Object);

            // Then
            Assert.Throws<ArgumentOutOfRangeException>(td.Invoke);
        }

        [Test]
        public void GivenRequestIsPopulated_WhenAddCustomerIsCalled_ThenCallIsPassedThrough()
        {
            // Given
            var response = new Mock<IAddCustomerResponse>();
            var passThrough = new Mock<ICustomerService>();
            passThrough.Setup(x => x.AddCustomer(It.IsAny<IAddCustomerRequest>())).Returns(response.Object);

            var svc = new ValidatingCustomerService(passThrough.Object);
            var request = new Mock<IAddCustomerRequest>();
            request.Setup(x => x.FirstName).Returns("Test fn");
            request.Setup(x => x.SurName).Returns("surname test");
            request.Setup(x => x.DateOfBirth).Returns(new DateTime(2010, 12, 5));
            request.Setup(x => x.CompanyId).Returns(33);
            request.Setup(x => x.Email).Returns("test@test.com");

            // When
            var r = svc.AddCustomer(request.Object);

            // Then
            passThrough.Verify(x => x.AddCustomer(request.Object));
            Assert.AreEqual(response.Object, r);
        }

    }

}
