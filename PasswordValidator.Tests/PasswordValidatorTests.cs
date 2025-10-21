using Xunit;

namespace PasswordValidator.Tests
{
    /// <summary>
    /// Тесты для валидатора паролей
    /// </summary>
    public class PasswordValidatorTests
    {
        /// <summary>
        /// Тестирование базовой валидации пароля
        /// </summary>
        public class BasicValidationTests
        {
            [Theory]
            [InlineData("Password1", true)]    // валидный пароль
            [InlineData("Passw0rd", true)]     // валидный пароль
            [InlineData("Test1234", true)]     // валидный пароль
            public void Validate_ValidPassword_ReturnsTrue(string password, bool expected)
            {
                // Act
                var result = PasswordValidator.Validate(password);
                
                // Assert
                Assert.Equal(expected, result);
            }

            [Theory]
            [InlineData("short1", false)]      // меньше 8 символов
            [InlineData("nopassword", false)]  // нет цифр
            [InlineData("12345678", false)]    // нет букв
            [InlineData("", false)]            // пустая строка
            [InlineData(null, false)]          // null
            [InlineData("паrol1", false)]      // не латинские буквы
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
        /// Тестирование усовершенствованной валидации пароля
        /// </summary>
        public class EnhancedValidationTests
        {
            [Theory]
            [InlineData("Password1!", true)]           // валидный пароль
            [InlineData("Test123$", true)]             // валидный пароль
            [InlineData("Hello123@World", true)]       // валидный пароль
            public void ValidateEnhanced_ValidPassword_ReturnsTrue(string password, bool expected)
            {
                // Act
                var result = PasswordValidator.ValidateEnhanced(password);
                
                // Assert
                Assert.Equal(expected, result);
            }

            [Theory]
            [InlineData("password1!", false)]          // нет верхнего регистра
            [InlineData("PASSWORD1!", false)]          // нет нижнего регистра
            [InlineData("Password!", false)]           // нет цифр
            [InlineData("Password1", false)]           // нет спецсимволов
            [InlineData("Pass1!", false)]              // меньше 8 символов
            [InlineData("", false)]                    // пустая строка
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