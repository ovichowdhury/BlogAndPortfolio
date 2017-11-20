using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private DataAccessContext context;

        public UserDetailsRepository()
        {
            this.context = new DataAccessContext();
        }
        public UserDetails Get()
        {
            List<UserDetails> ud = this.context.UserDetailsInfo.ToList();
            return ud[0];
        }

        public int Update(UserDetails userDet)
        {
            UserDetails userDetails = this.Get();
            userDetails.about = userDet.about;
            userDetails.address = userDet.address;
            userDetails.contact = userDet.contact;
            userDetails.education = userDet.education;
            userDetails.name = userDet.name;
            userDetails.occupation = userDet.occupation;
            userDetails.skills = userDet.skills;

            return this.context.SaveChanges();
        }
    }
}
