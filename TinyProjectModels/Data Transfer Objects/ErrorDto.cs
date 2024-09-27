
using TinyProjectModels.Enums;

namespace TinyProjectModels.Data_Transfer_Objects
{
    /// <summary>
    /// ErrorDto
    /// </summary>
    /// <param name="statusCode">Http Status Code</param>
    /// <param name="message">Error Message</param>
    public class ErrorDto(StatusCode statusCode, string message, string stackTrace, string innerException)
    {
        /// <summary>
        /// StatusCode
        /// </summary>
        public StatusCode StatusCode { get; set; } = statusCode;

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; } = message;

        /// <summary>
        /// StackTrace
        /// </summary>
        public string StackTrace { get; set; } = stackTrace;

        /// <summary>
        /// InnerException
        /// </summary>
        public string InnerException { get; set; } = innerException;
    }
}
