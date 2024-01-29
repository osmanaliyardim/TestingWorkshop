using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections;

namespace Bongo.DataAccess.Tests
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking studyRoomBooking_One;
        private StudyRoomBooking studyRoomBooking_Two;
        private DbContextOptions<ApplicationDbContext> options;

        [SetUp]
        public void Setup()
        {
            studyRoomBooking_One = new StudyRoomBooking()
            {
                FirstName = "Osman",
                LastName = "Yardim1",
                Date = new DateTime(2023, 1, 1),
                Email = "osmanaliyardim@gmail.com",
                BookingId = 11,
                StudyRoomId = 1
            };

            studyRoomBooking_Two = new StudyRoomBooking()
            {
                FirstName = "Ali",
                LastName = "Veli",
                Date = new DateTime(2023, 2, 2),
                Email = "aliveli@gmail.com",
                BookingId = 22,
                StudyRoomId = 2
            };

            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_Bongo").Options;
        }

        [Test]
        [Order(1)]
        public void SaveBooking_BookingOne_CheckTheValuesFromDatabase()
        {
            // Arrange moved to SetUp() method
            //var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            //    .UseInMemoryDatabase(databaseName: "temp_Bongo").Options;

            // Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);

                repository.Book(studyRoomBooking_One);
            }

            // Assert
            using (var context = new ApplicationDbContext(options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(u => u.BookingId == 11);
                Assert.That(bookingFromDb?.BookingId, Is.EqualTo(studyRoomBooking_One.BookingId));
                Assert.That(bookingFromDb?.FirstName, Is.EqualTo(studyRoomBooking_One.FirstName));
                Assert.That(bookingFromDb?.LastName, Is.EqualTo(studyRoomBooking_One.LastName));
                Assert.That(bookingFromDb?.Email, Is.EqualTo(studyRoomBooking_One.Email));
                Assert.That(bookingFromDb?.Date, Is.EqualTo(studyRoomBooking_One.Date));
            }
        }

        [Test]
        [Order(2)]
        public void GetAllBookings_BookingOneAndTwo_CheckBothBookingsFromDatabase()
        {
            // Arrange
            var expectedResult = new List<StudyRoomBooking> { studyRoomBooking_One, studyRoomBooking_Two };

            // Act
            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureDeleted();

                var repository = new StudyRoomBookingRepository(context);

                repository.Book(studyRoomBooking_One);
                repository.Book(studyRoomBooking_Two);
            }

            var actualResult = new List<StudyRoomBooking>();
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);

                actualResult = repository.GetAll(null).ToList();
            }

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult, new BookingCompare());
        }

        private class BookingCompare : IComparer
        {
            public int Compare(object? x, object? y)
            {
                var booking1 = (StudyRoomBooking)x;
                var booking2 = (StudyRoomBooking)y;

                if (booking1?.BookingId != booking2?.BookingId) return 1;
                else return 0;
            }
        }
    }
}