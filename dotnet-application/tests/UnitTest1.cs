
namespace ProgramClass
{
    public class ProgramTest
    {
        [Fact]
        public void TestPersonNameProperty()
        {
            // Arrange
            Person person = new Person();
            string expectedName = "Liam";

            // Act
            person.Name = expectedName;
            string actualName = person.Name;

            // Assert
            Xunit.Assert.Matches(expectedName, actualName);
        }

        [Fact]
        public void TestMainMethodWithSingleArgument()
        {
            // Arrange
            string[] args = { "Liam" };
            string expectedOutput = "Liam";
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Program.Main(args);

                // Assert
                var result = sw.ToString().Trim();
                 Xunit.Assert.Matches(expectedOutput, result);
            }
        }

        [Fact]
        public void TestMainMethodWithMultipleArguments()
        {
            // Arrange
            string[] args = { "Liam", "Emma", "Noah" };
            string expectedOutput = "Noah";
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Program.Main(args);

                // Assert
                var result = sw.ToString().Trim();
                 Xunit.Assert.Matches(expectedOutput, result);
            }
        }

        [Fact]
        public void TestMainMethodWithNoArguments()
        {
            // Arrange
            string[] args = { };
            string expectedOutput = "";
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Program.Main(args);

                // Assert
                var result = sw.ToString().Trim();
                 Xunit.Assert.Matches(expectedOutput, result);
            }
        }
    }
}

