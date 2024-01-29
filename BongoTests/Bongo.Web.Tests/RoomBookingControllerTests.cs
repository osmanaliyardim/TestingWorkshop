using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Bongo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Bongo.Web.Tests
{
    [TestFixture]
    public class RoomBookingControllerTests
    {
        private Mock<IStudyRoomBookingService> _studyRoomBookingServiceMock;
        private RoomBookingController _bookingController;

        [SetUp]
        public void Setup()
        {
            _studyRoomBookingServiceMock = new Mock<IStudyRoomBookingService>();
            _bookingController = new RoomBookingController(_studyRoomBookingServiceMock.Object);
        }

        [Test]
        public void IndexPage_CallRequest_VerifyGetAllInvoked()
        {
            // Arrange moved to SetUp() method

            // Act
            _bookingController.Index();

            // Assert
            _studyRoomBookingServiceMock.Verify(x => x.GetAllBooking(), Times.Once);
        }

        [Test]
        public void BookRoomCheck_ModelStateInvalid_ReturnView()
        {
            // Arrange
            _bookingController.ModelState.AddModelError("test", "test");

            // Act
            var actualResult = _bookingController.Book(new StudyRoomBooking());
            ViewResult viewResult = actualResult as ViewResult;

            // Assert
            Assert.That(viewResult?.ViewName, Is.EqualTo("Book"));
        }

        [Test]
        public void BookRoomCheck_NotSuccessful_NoRoomCode()
        {
            // Arrange
            _studyRoomBookingServiceMock.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
                .Returns(new StudyRoomBookingResult()
                {
                    Code = StudyRoomBookingCode.NoRoomAvailable
                });

            // Act
            var actualResult = _bookingController.Book(new StudyRoomBooking());
            ViewResult viewResult = actualResult as ViewResult;

            // Assert
            Assert.That(viewResult?.ViewData["Error"], Is.EqualTo("No Study Room available for selected date"));
            Assert.IsInstanceOf<ViewResult>(actualResult);
        }

        [Test]
        public void BookRoomCheck_Successful_SuccessCodeAndRedirect()
        {
            // Arrange
            _studyRoomBookingServiceMock.Setup(x => x.BookStudyRoom(It.IsAny<StudyRoomBooking>()))
                .Returns((StudyRoomBooking booking) => new StudyRoomBookingResult()
                {
                    Code = StudyRoomBookingCode.Success,
                    FirstName = booking.FirstName,
                    LastName = booking.LastName,
                    Date = booking.Date,
                    Email = booking.Email
                });

            // Act
            var actualResult = _bookingController.Book(new StudyRoomBooking()
            {
                Date = DateTime.Now,
                Email = "osmanaliyardim@gmail.com",
                FirstName = "Osman",
                LastName = "Yardim",
                StudyRoomId = 1
            });
            RedirectToActionResult viewResult = actualResult as RedirectToActionResult;

            // Assert
            Assert.That(viewResult?.RouteValues["FirstName"], Is.EqualTo("Osman"));
            Assert.That(viewResult?.RouteValues["LastName"], Is.EqualTo("Yardim"));
            Assert.That(viewResult?.RouteValues["Email"], Is.EqualTo("osmanaliyardim@gmail.com"));
            Assert.That(viewResult?.RouteValues["Code"], Is.EqualTo(StudyRoomBookingCode.Success));
            Assert.IsInstanceOf<RedirectToActionResult>(actualResult);
        }
    }
}