using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomInitializer : DropCreateDatabaseIfModelChanges<DataAccessContext>
    {
        protected override void Seed(DataAccessContext context)
        {
            UserDetails ud = new UserDetails();
            ud.about = "null"; ud.address = "null"; ud.contact = "null"; ud.education = "null";  ud.name = "null"; ud.occupation = "null"; ud.skills = "null";
            Footer ft = new Footer();
            ft.copyright = "null"; ft.fbUrl = "null"; ft.gitUrl = "null";
            Login lg = new Login();
            lg.username = "admin"; lg.password = "admin";
            Image img = new Image();
            img.imageUrl = "~/Image/default.jpeg";

            context.ImageInfo.Add(img);
            context.UserDetailsInfo.Add(ud);
            context.FooterInfo.Add(ft);
            context.LoginInfo.Add(lg);
            context.SaveChanges();
            
        }
    }
}
