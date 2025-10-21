using System;
using System.Linq;

namespace PasswordValidator
{
    /// <summary>
    /// Статический класс для валидации паролей
    /// </summary>
    public static class PasswordValidator
    {
        /// <summary>
        /// Проверяет валидность пароля согласно требованиям
        /// </summary>
        /// <param name="password">Пароль для проверки</param>
        /// <returns>True если пароль валиден, иначе False</returns>
        public static bool Validate(string password)
        {
            // Проверка на null или пустую строку
            if (string.IsNullOrEmpty(password))
                return false;

            // Проверка минимальной длины
            if (password.Length < 8)
                return false;

            // Проверка наличия цифры
            bool hasDigit = password.Any(char.IsDigit);

            // Проверка наличия латинской буквы
            bool hasLatinLetter = password.Any(ch =>
                (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'));

            return hasDigit && hasLatinLetter;
        }

        /// <summary>
        /// Усовершенствованная проверка пароля с дополнительными требованиями
        /// </summary>
        /// <param name="password">Пароль для проверки</param>
        /// <returns>True если пароль валиден, иначе False</returns>
        public static bool ValidateEnhanced(string password)
        {
            // Проверка на null или пустую строку
            if (string.IsNullOrEmpty(password))
                return false;

            // Проверка минимальной длины
            if (password.Length < 8)
                return false;

            // Проверка наличия цифры
            bool hasDigit = password.Any(char.IsDigit);

            // Проверка наличия буквы в нижнем регистре
            bool hasLower = password.Any(char.IsLower);

            // Проверка наличия буквы в верхнем регистре
            bool hasUpper = password.Any(char.IsUpper);

            // Проверка наличия специального символа
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasDigit && hasLower && hasUpper && hasSpecial;
        }
    }
}