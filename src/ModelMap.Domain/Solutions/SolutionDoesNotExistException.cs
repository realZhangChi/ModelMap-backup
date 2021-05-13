using Volo.Abp;

namespace ModelMap.Solutions
{
    public class SolutionDoesNotExistException : UserFriendlyException
    {
        public SolutionDoesNotExistException()
        : base("Solution does not exist!")
        {

        }
    }
}
