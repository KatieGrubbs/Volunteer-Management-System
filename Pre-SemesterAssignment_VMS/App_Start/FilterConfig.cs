using System.Web;
using System.Web.Mvc;

namespace Pre_SemesterAssignment_VMS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
