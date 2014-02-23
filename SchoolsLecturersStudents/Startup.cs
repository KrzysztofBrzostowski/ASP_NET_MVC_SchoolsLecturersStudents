using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolsLecturersStudents.Startup))]
namespace SchoolsLecturersStudents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
