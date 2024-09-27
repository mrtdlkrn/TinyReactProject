namespace TinyProjectHelper
{
    /// <summary>
    /// CommonMessageHelper
    /// </summary>
    public static class CommonMessageHelper
    {
        /// <summary>
        /// DbSetDataIsEmpty
        /// </summary>
        /// <param name="dbSetName">Table Name</param>
        /// <returns>Error Message</returns>
        public static string DbSetDataIsEmpty(string dbSetName) => $"{dbSetName} not has any data.";

        /// <summary>
        /// DbSetDataIsNull
        /// </summary>
        /// <param name="dbSetName">Table Name</param>
        /// <param name="id">Item id</param>
        /// <returns>Error Message</returns>
        public static string DbSetDataIsNull(string dbSetName, int id) => $"{dbSetName} with Id : {id} was not found.";

        /// <summary>
        /// UserNotAuthorized
        /// </summary>
        /// <param name="username">User's name</param>
        /// <returns>Error Message</returns>
        public static string UserNotAuthorized(string username) => $"User {username} is not authorized to perform this action.";

        /// <summary>
        /// InvalidPageNumber
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <returns>Error Message</returns>
        public static string InvalidPageNumber(string pageNumber) => $"Invalid page number : {pageNumber} for pagining.";

        /// <summary>
        /// InvalidPageSize
        /// </summary>
        /// <param name="pageSize">Page data size</param>
        /// <returns>Error Message</returns>
        public static string InvalidPageSize(string pageSize) => $"Invalid page size : {pageSize} for pagining.";
    }
}
