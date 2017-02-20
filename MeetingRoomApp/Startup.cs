using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingRoomApp.Startup))]
namespace MeetingRoomApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
