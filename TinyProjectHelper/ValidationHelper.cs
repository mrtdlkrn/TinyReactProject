using System.Data;
using System.Text.RegularExpressions;

namespace TinyProjectHelper
{
    /// <summary>
    /// ValidationHelper
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// IsNullOrEmpty
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>bool result</returns>
        public static bool IsNullOrEmpty(string input) => string.IsNullOrWhiteSpace(input);

        /// <summary>
        /// IsValidEmail
        /// </summary>
        /// <param name="email">Email data for check.</param>
        /// <returns>Answer for Is email valid question.</returns>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        /// <summary>
        /// IsValidPhoneNumber
        /// </summary>
        /// <param name="phoneNumber">Phone number data for check.</param>
        /// <returns>Answer for Is phone number valid question.</returns>
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return false;
            }

            var phoneRegex = new Regex(@"^\d+$");
            return phoneRegex.IsMatch(phoneNumber);
        }

        /// <summary>
        /// IsPositiveNumber
        /// </summary>
        /// <param name="number">Number data for check.</param>
        /// <returns>Answer for Is number positive question.</returns>
        public static bool IsPositiveNumber(int number) => number > 0;

        /// <summary>
        /// IsDateInPast
        /// </summary>
        /// <param name="date">Date data for check.</param>
        /// <returns>Answer for Is date in past question.</returns>
        public static bool IsDateInPast(DateTime date) => date < DateTime.Now;

        /// <summary>
        /// IsValidPaginingNumbers
        /// </summary>
        /// <param name="pageNumber">Page number data for check.</param>
        /// <param name="pageSize">Page size data for check.</param>
        /// <returns>Answer for Is pagining numbers valid question.</returns>
        public static bool IsValidPaginingNumbers(int pageNumber, int pageSize)
        {
            if (!IsPositiveNumber(pageNumber))
            {
                throw new DataException(CommonMessageHelper.InvalidPageNumber(pageNumber.ToString()));
            }

            if (!IsPositiveNumber(pageSize))
            {
                throw new DataException(CommonMessageHelper.InvalidPageSize(pageSize.ToString()));
            }

            return true;
        }
    }
}
