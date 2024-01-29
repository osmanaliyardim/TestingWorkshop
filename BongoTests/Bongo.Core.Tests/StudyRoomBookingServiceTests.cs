using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Moq;

namespace Bongo.Core.Tests
{
    [TestFixture]
    public class StudyRoomBookingServiceTests
    {
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepositoryMock;
        private Mock<IStudyRoomRepository> _studyRoomRepositoryMock;
        private StudyRoomBookingService _bookingService;
        private StudyRoomBooking _request;
        private List<StudyRoom> _availableStudyRoom;

        // Arrange
        [SetUp]
        public void Setup()
        {
            _studyRoomBookingRepositoryMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepositoryMock = new Mock<IStudyRoomRepository>();
            _bookingService = new StudyRoomBookingService(_studyRoomBookingRepositoryMock.Object, _studyRoomRepositoryMock.Object);

            _request = new StudyRoomBooking
            {
                FirstName = "Osman",
                LastName = "Yardim",
                Email = "osmanaliyardim@gmail.com",
                Date = new DateTime(2024, 1, 1)
            };
            _availableStudyRoom = new List<StudyRoom>
            {
                new StudyRoom
                {
                    Id = 10,
                    RoomName = "Michigan",
                    RoomNumber = "A202"
                }
            };
            _studyRoomRepositoryMock.Setup(x => x.GetAll()).Returns(_availableStudyRoom);
        }

        [Test]
        public void GetAllBooking_InvokeMethod_CheckIfRepositoryIsCalled()
        {
            // Act
            _bookingService.GetAllBooking();

            // Assert
            _studyRoomBookingRepositoryMock.Verify(x => x.GetAll(null), Times.Once);
            //_studyRoomBookingRepositoryMock.Verify(x => x.GetAll(null), Times.Never); // will fail
        }

        [Test]
        public void BookingException_NullRequest_ThrowsException()
        {
            // Act
            var exception = Assert.Throws<ArgumentNullException>(
                () => _bookingService.BookStudyRoom(null));

            // Assert
            Assert.That(exception.Message, Is.EqualTo("Value cannot be null. (Parameter 'request')"));
            Assert.That(exception.ParamName, Is.EqualTo("request"));
        }

        [Test]
        public void StudyRoomBooking_SaveBookingWithAvailableRoom_ReturnsResultWithAllValues()
        {
            // Arrange
            StudyRoomBooking savedStudyRoomBooking = null;
            _studyRoomBookingRepositoryMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking =>
                 {
                     savedStudyRoomBooking = booking;
                 });

            // Act
            _bookingService.BookStudyRoom(_request);

            // Assert
            _studyRoomBookingRepositoryMock.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Once);
            Assert.NotNull(savedStudyRoomBooking);
            Assert.That(savedStudyRoomBooking.FirstName, Is.EqualTo(_request.FirstName));
            Assert.That(savedStudyRoomBooking.LastName, Is.EqualTo(_request.LastName));
            Assert.That(savedStudyRoomBooking.Email, Is.EqualTo(_request.Email));
            Assert.That(savedStudyRoomBooking.Date, Is.EqualTo(_request.Date));
            Assert.That(savedStudyRoomBooking.StudyRoomId, Is.EqualTo(_availableStudyRoom.First().Id));
        }

        [Test]
        public void StudyRoomBookingResultCheck_InputRequest_ValuesMatchInResult()
        {
            // Act
            StudyRoomBookingResult actualResult = _bookingService.BookStudyRoom(_request);

            // Assert
            Assert.NotNull(actualResult);
            Assert.That(actualResult.FirstName, Is.EqualTo(_request.FirstName));
            Assert.That(actualResult.LastName, Is.EqualTo(_request.LastName));
            Assert.That(actualResult.Email, Is.EqualTo(_request.Email));
            Assert.That(actualResult.Date, Is.EqualTo(_request.Date));
        }

        // Assert
        [TestCase(true, ExpectedResult = StudyRoomBookingCode.Success)]
        [TestCase(false, ExpectedResult = StudyRoomBookingCode.NoRoomAvailable)]
        public StudyRoomBookingCode ResultCodeSuccess_RoomAvailability_ReturnSuccessResultCode(bool roomAvailability)
        {
            // Arrange
            if (!roomAvailability)
            {
                _availableStudyRoom.Clear();
            }

            // Act
            return _bookingService.BookStudyRoom(_request).Code;
        }

        [TestCase(0, false)]
        [TestCase(55, true)]
        public void StudyRoomBooking_BookRoomWithAvailability_ReturnsBookingId(int expectedBookingId, bool roomAvailability)
        {
            // Arrange
            if (!roomAvailability)
            {
                _availableStudyRoom.Clear();
            }

            _studyRoomBookingRepositoryMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking =>
                {
                    booking.BookingId = 55;
                });

            // Act
            var actualResult = _bookingService.BookStudyRoom(_request);

            // Assert
            Assert.That(actualResult.BookingId, Is.EqualTo(expectedBookingId));
        }

        [Test]
        public void BookNotInvoked_SaveBookingWithoutAvailableRoom_BookMethodNotInvoked()
        {
            // Arrange
            _availableStudyRoom.Clear();

            // Act
            var actualResult = _bookingService.BookStudyRoom(_request);

            // Assert
            _studyRoomBookingRepositoryMock.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Never);
        }
    }
}