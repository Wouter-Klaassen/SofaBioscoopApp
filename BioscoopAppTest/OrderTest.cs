using BioscoopApp;


namespace BioscoopTest
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void CalculatePrice_1NotStudentWeekendPremium()
        {
            //Arrange
            Order testOrder = new Order(1, false);
            Movie testMovie = new Movie("testMovie");
            MovieScreening testMovieScreening = new MovieScreening(new DateTime(2024, 02, 04), 4.5M, testMovie);
            MovieTicket testTicket = new MovieTicket(testMovieScreening, true, 1, 1);
            testOrder.addSeatReservation(testTicket);

            //Act 
            decimal totalPrice = testOrder.calculatePrice();

            //Assert
            Assert.AreEqual(totalPrice, 7.5M);
        }

        [TestMethod]
        public void CalculatePrice_6NotStudentWeekendNotPremium()
        {
            //Arrange
            Order testOrder = new Order(1, false);
            Movie testMovie = new Movie("testMovie");
            MovieScreening testMovieScreening = new MovieScreening(new DateTime(2024, 02, 04), 4.5M, testMovie);
            MovieTicket testTicket = new MovieTicket(testMovieScreening, false, 1, 1);
            MovieTicket testTicket2 = new MovieTicket(testMovieScreening, false, 1, 1);
            MovieTicket testTicket3 = new MovieTicket(testMovieScreening, false, 1, 1);
            MovieTicket testTicket4 = new MovieTicket(testMovieScreening, false, 1, 1);
            MovieTicket testTicket5 = new MovieTicket(testMovieScreening, false, 1, 1);
            MovieTicket testTicket6 = new MovieTicket(testMovieScreening, false, 1, 1);
            testOrder.addSeatReservation(testTicket);
            testOrder.addSeatReservation(testTicket2);
            testOrder.addSeatReservation(testTicket3);
            testOrder.addSeatReservation(testTicket4);
            testOrder.addSeatReservation(testTicket5);
            testOrder.addSeatReservation(testTicket6);

            //Act 
            decimal totalPrice = testOrder.calculatePrice();

            //Assert
            Assert.AreEqual(totalPrice, 24.3M);
        }

        [TestMethod]
        public void CalculatePrice_2NotStudentNotWeekendNotPremium()
        {
            //Arrange
            Order testOrder = new Order(1, false);
            Movie testMovie = new Movie("testMovie");
            MovieScreening testMovieScreening = new MovieScreening(new DateTime(2024, 02, 01), 4.5M, testMovie);
            MovieTicket testTicket = new MovieTicket(testMovieScreening, false, 1, 1);
            MovieTicket testTicket2 = new MovieTicket(testMovieScreening, false, 1, 1);
            testOrder.addSeatReservation(testTicket);
            testOrder.addSeatReservation(testTicket2);

            //Act 
            decimal totalPrice = testOrder.calculatePrice();

            //Assert
            Assert.AreEqual(totalPrice, 4.5M);
        }

        [TestMethod]
        public void CalculatePrice_1StudentPremium()
        {
            //Arrange
            Order testOrder = new Order(1, true);
            Movie testMovie = new Movie("testMovie");
            MovieScreening testMovieScreening = new MovieScreening(new DateTime(2024, 02, 01), 4.5M, testMovie);
            MovieTicket testTicket = new MovieTicket(testMovieScreening, true, 1, 1);
            testOrder.addSeatReservation(testTicket);

            //Act 
            decimal totalPrice = testOrder.calculatePrice();

            //Assert
            Assert.AreEqual(totalPrice, 6.5M);
        }
    }
}