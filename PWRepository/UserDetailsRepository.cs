using PWEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class UserDetailsRepository : Repository<UserDetails>, IUserDetailsRepository
    {
        public int Update(UserDetails userDet)
        {
            UserDetails userDetails = this.Get(1);
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
