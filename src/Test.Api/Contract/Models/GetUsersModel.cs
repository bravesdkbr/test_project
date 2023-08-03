using Test.Api.Domain.Enums;

namespace Test.Api.Contract.Models
{
    public class GetUsersModel
    {
        /// <summary>
        /// OrderType: 1 - ascending; 2 - descending
        /// </summary>
        public OrderType OrderType { get; set; }
        /// <summary>
        /// count of users
        /// </summary>
        public int Count { get; set; }
    }
}
