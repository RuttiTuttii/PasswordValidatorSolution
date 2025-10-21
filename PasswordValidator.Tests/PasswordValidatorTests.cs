using Xunit;

namespace PasswordValidator.Tests
{
    /// <summary>
    /// ����� ��� ���������� �������
    /// </summary>
    public class PasswordValidatorTests
    {
        /// <summary>
        /// ������������ ������� ��������� ������
        /// </summary>
        public class BasicValidationTests
        {
            [Theory]
            [InlineData("Password1", true)]    // �������� ������
            [InlineData("Passw0rd", true)]     // �������� ������
            [InlineData("Test1234", true)]     // �������� ������
            public void Validate_ValidPassword_ReturnsTrue(string password, bool expected)
            {
                // Act
                var result = PasswordValidator.Validate(password);

                // Assert
                Assert.Equal(expected, result);
            }

            [Theory]
            [InlineData("short1", false)]      // ������ 8 ��������
            [InlineData("nopassword", false)]  // ��� ����
            [InlineData("12345678", false)]    // ��� ����
            [InlineData("", false)]            // ������ ������
            [InlineData(null, false)]          // null
            [InlineData("��rol1", false)]      // �� ��������� �����
            public void Validate_InvalidPassword_ReturnsFalse(string password, bool expected)
            {
                // Act
                var result = PasswordValidator.Validate(password);

                // Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public void Validate_Exactly8Characters_ReturnsTrue()
            {
                // Arrange
                var password = "Abc12345";

                // Act
                var result = PasswordValidator.Validate(password);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void Validate_Only7Characters_ReturnsFalse()
            {
                // Arrange
                var password = "Abc1234";

                // Act
                var result = PasswordValidator.Validate(password);

                // Assert
                Assert.False(result);
            }
        }

        /// <summary>
        /// ������������ ������������������� ��������� ������
        /// </summary>
        public class EnhancedValidationTests
        {
            [Theory]
            [InlineData("Password1!", true)]           // �������� ������
            [InlineData("Test123$", true)]             // �������� ������
            [InlineData("Hello123@World", true)]       // �������� ������
            public void ValidateEnhanced_ValidPassword_ReturnsTrue(string password, bool expected)
            {
                // Act
                var result = PasswordValidator.ValidateEnhanced(password);

                // Assert
                Assert.Equal(expected, result);
            }

            [Theory]
            [InlineData("password1!", false)]          // ��� �������� ��������
            [InlineData("PASSWORD1!", false)]          // ��� ������� ��������
            [InlineData("Password!", false)]           // ��� ����
            [InlineData("Password1", false)]           // ��� ������������
            [InlineData("Pass1!", false)]              // ������ 8 ��������
            [InlineData("", false)]                    // ������ ������
            [InlineData(null, false)]                  // null
            public void ValidateEnhanced_InvalidPassword_ReturnsFalse(string password, bool expected)
            {
                // Act
                var result = PasswordValidator.ValidateEnhanced(password);

                // Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public void ValidateEnhanced_AllRequirementsMet_ReturnsTrue()
            {
                // Arrange
                var password = "Test123!";

                // Act
                var result = PasswordValidator.ValidateEnhanced(password);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ValidateEnhanced_MissingSpecialCharacter_ReturnsFalse()
            {
                // Arrange
                var password = "Test1234";

                // Act
                var result = PasswordValidator.ValidateEnhanced(password);

                // Assert
                Assert.False(result);
            }
        }
    }
}