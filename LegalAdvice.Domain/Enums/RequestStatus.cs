namespace LegalAdvice.Domain.Enums
{
    public enum RequestStatus
    {
        /// After The Client Creation For The Request, And Before The Admin Check It. 
        New = 1,
        
        /// The Request Can Be Approved Or Rejected Only By The Admin.
        Approved,

        /// The Request Can Be Approved Or Rejected Only By The Admin.
        Rejected,

        /// After The Request Assignment From The Admin To A Lawyer.
        Assigned,
        
        /// After The First Lawyer's Comment.
        Active,

        /// Only Admin and Lawyer Can Change The Request Status To Closed.
        Closed,
    }
}