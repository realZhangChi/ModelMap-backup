using Volo.Abp;

namespace ModelMap.Diagrams
{
    public class SolutionDoesNotExistException : UserFriendlyException
    {
        public SolutionDoesNotExistException()
        : base("The solution where the entity is located does not exist!")
        {

        }
    }
}
